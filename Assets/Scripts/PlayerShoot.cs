using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    private const string Player_tag = "Player";
    public PlayerWeapons weapon;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;

    private void Start()
    {
        if (cam == null)
        {
            Debug.Log("no cam");
            this.enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }   
    }
    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, weapon.range, mask))
        {
            if (hit.collider.tag == Player_tag)
            {
                CmdPlayerShot(hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot(string playerid)
    {
        Debug.Log(playerid + " has been shot");
    }
}
