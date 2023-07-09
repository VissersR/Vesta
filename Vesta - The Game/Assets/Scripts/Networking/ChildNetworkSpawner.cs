using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ChildNetworkSpawner: NetworkBehaviour
{
    [SerializeField] private List<Transform> childPrefabs;

    #region Overrides of NetworkBehaviour

    /// <inheritdoc />
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        foreach (var childPrefab in childPrefabs)
        {
            var child = Instantiate(childPrefab, transform);
            var networkObject = child.GetComponent<NetworkObject>();
            Debug.Log(child.name);
            networkObject.TrySetParent(transform);
            networkObject.Spawn(true);
            networkObject.TrySetParent(transform);
        }
    }

    #endregion
}