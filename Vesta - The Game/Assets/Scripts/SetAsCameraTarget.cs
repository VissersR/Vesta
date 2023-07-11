using Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class SetAsCameraTarget: NetworkBehaviour
{
    #region Overrides of NetworkBehaviour

    /// <inheritdoc />
    public override void OnNetworkSpawn()
    {
        SetTarget();
        /*if (!IsOwner) return;
        var cameraController = GameObject.Find(ManagerConstants.ThirdPersonFreeLookCamera);
        var freeLook = cameraController.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = transform;
        freeLook.LookAt = transform;*/
    }
    
    /*void Awake()
    {
        if (ProjectSceneManager.Singleton != null)
        ProjectSceneManager.Singleton.Loaded += (sender, args) =>
        {
            Debug.Log($"SetAsCameraTarget Scene loaded");
            SetTarget();
        };
    }*/

    private void SetTarget()
    {
        Debug.Log($"SetAsCameraTarget {gameObject.name}, IsOwner {IsOwner} SetTarget");
        if (!IsOwner) return;
        
        var cameraController = GameObject.Find(ManagerConstants.ThirdPersonFreeLookCamera);
        var freeLook = cameraController.GetComponent<CinemachineFreeLook>();
        freeLook.Follow = transform;
        freeLook.LookAt = transform;
    }
    
    

    #endregion
}