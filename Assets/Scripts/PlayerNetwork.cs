using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(Player))]
public class PlayerNetwork : NetworkBehaviour
{

    [SerializeField]
    Behaviour[] ComponentsToDisable;
    [SerializeField]

    string remoteLayerName = "RemotePlayer";
    Camera sceneCamera;
    void Start()
    {
        if (!isLocalPlayer)
        {
            disableComponents();
            assigningRemoteLayer();
        }
        else
        {
            sceneCamera = Camera.main;
                if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
           
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netId = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netId, player);

    }
    void disableComponents()
    {
        for (int i = 0; i < ComponentsToDisable.Length; i++)
        {
            ComponentsToDisable[i].enabled = false;
        }
    }
    void assigningRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }
    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
        GameManager.UnregisterPlayer(transform.name);
    }

}
