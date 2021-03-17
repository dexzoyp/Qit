using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
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
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, weapon.range, mask))
        {
            Debug.Log("We hit" + hit.collider.name);
        }
    }
}
