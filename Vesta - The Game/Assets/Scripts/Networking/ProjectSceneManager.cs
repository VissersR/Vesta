using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectSceneManager : NetworkBehaviour
{
    private Scene loadedScene;
    private string sceneName;

    public event EventHandler Loaded;
    
    /// <summary>
    /// The singleton instance of the NetworkManager
    /// </summary>
    public static ProjectSceneManager Singleton { get; private set; }

    private void Awake()
    {
        if (!IsServer)
            return;
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #region Overrides of NetworkBehaviour

    /// <inheritdoc />
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    private void OnEnable()
    {
        if (Singleton == null)
            Singleton = this;
    }

    public bool SceneIsLoaded
    {
        get
        {
            if (loadedScene.IsValid() && loadedScene.isLoaded)
            {
                return true;
            }

            return false;
        }
    }

    private void CheckStatus(SceneEventProgressStatus status, bool isLoading = true)
    {
        var sceneEventAction = isLoading ? "load" : "unload";
        if (status != SceneEventProgressStatus.Started)
        {
            Debug.LogWarning($"Failed to {sceneEventAction} {sceneName} with" +
                             $" a {nameof(SceneEventProgressStatus)}: {status}");
        }
    }

    public void LoadScene(string newSceneName)
    {
        if (IsServer && !string.IsNullOrEmpty(newSceneName))
        {
            this.sceneName = newSceneName;
            NetworkManager.SceneManager.OnSceneEvent += SceneManager_OnSceneEvent;
            var status = NetworkManager.SceneManager.LoadScene(newSceneName, LoadSceneMode.Single);
            CheckStatus(status);
        }

    }

    public void UnloadScene()
    {
        // Assure only the server calls this when the NetworkObject is
        // spawned and the scene is loaded.
        if (!IsServer || !IsSpawned || !loadedScene.IsValid() || !loadedScene.isLoaded)
        {
            return;
        }

        // Unload the scene
        var status = NetworkManager.SceneManager.UnloadScene(loadedScene);
        CheckStatus(status, false);
    }

    /// <summary>
    /// Handles processing notifications when subscribed to OnSceneEvent
    /// </summary>
    /// <param name="sceneEvent">class that has information about the scene event</param>
    private void SceneManager_OnSceneEvent(SceneEvent sceneEvent)
    {
        var clientOrServer = sceneEvent.ClientId == NetworkManager.ServerClientId ? "server" : "client";
        switch (sceneEvent.SceneEventType)
        {
            case SceneEventType.LoadComplete:
            {
                // We want to handle this for only the server-side
                if (sceneEvent.ClientId == NetworkManager.ServerClientId)
                {
                    // *** IMPORTANT ***
                    // Keep track of the loaded scene, you need this to unload it
                    loadedScene = sceneEvent.Scene;
                }

                Debug.Log($"Loaded the {sceneEvent.SceneName} scene on " +
                          $"{clientOrServer}-({sceneEvent.ClientId}).");
                
                Loaded?.Invoke(this, EventArgs.Empty);
                break;
            }
            case SceneEventType.UnloadComplete:
            {
                Debug.Log($"Unloaded the {sceneEvent.SceneName} scene on " +
                          $"{clientOrServer}-({sceneEvent.ClientId}).");
                break;
            }
            case SceneEventType.LoadEventCompleted:
            case SceneEventType.UnloadEventCompleted:
            {
                var loadUnload = sceneEvent.SceneEventType == SceneEventType.LoadEventCompleted ? "Load" : "Unload";
                Debug.Log($"{loadUnload} event completed for the following client " +
                          $"identifiers:({sceneEvent.ClientsThatCompleted})");
                if (sceneEvent.ClientsThatTimedOut.Count > 0)
                {
                    Debug.LogWarning($"{loadUnload} event timed out for the following client " +
                                     $"identifiers:({sceneEvent.ClientsThatTimedOut})");
                }

                break;
            }
        }
    }
}