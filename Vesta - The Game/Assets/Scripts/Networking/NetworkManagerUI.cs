using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField]
    private Button serverButton;
    
    [SerializeField]
    private Button hostButton;
    
    [SerializeField]
    private Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            LoadScene();
        });
        hostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            LoadScene();
        });
        clientButton.onClick.AddListener( () =>
        {
            NetworkManager.Singleton.StartClient();
            // LoadScene();
        });
    }

    private void LoadScene()
    {
        /*NetworkManager.Singleton.SceneManager.LoadScene(SceneNames.MultiplayerPlayground, LoadSceneMode.Single);*/
        // ProjectSceneManager.Singleton.LoadScene(SceneNames.MultiplayerPlayground);
    }
}