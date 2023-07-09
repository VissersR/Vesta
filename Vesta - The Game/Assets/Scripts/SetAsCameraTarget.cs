using Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class SetAsCameraTarget: NetworkBehaviour
{
    #region Overrides of NetworkBehaviour

    /// <inheritdoc />
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;
        var cameraController = GameObject.Find(ManagerConstants.ThirdPersonFreeLookCamera);
        var freeLook = cameraController.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = transform;
        freeLook.LookAt = transform;
    }

    #endregion
}