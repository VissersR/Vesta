using System;
using Unity.LEGO.Minifig;
using Unity.Netcode;
using UnityEngine;

public class NetworkGameManager: NetworkBehaviour
{
    private void Awake()
    {
        Debug.Log("NetworkGameController awake");
        ProjectSceneManager.Singleton.Loaded += (sender, args) =>
        {
            Debug.Log("NetworkGameController Loaded");
            var player = NetworkManager.SpawnManager.GetLocalPlayerObject();
            player.GetComponent<CharacterController>().enabled = true;
            var minifigController = player.GetComponent<MinifigController>();
            minifigController.enabled = true;
            minifigController.OnNetworkSceneLoaded();
        };
    }

    #region Overrides of NetworkBehaviour

    /// <inheritdoc />
    public override void OnNetworkSpawn()
    {
        Debug.Log("NetworkGameController OnNetworkSpawn");
    }

    #endregion
}
