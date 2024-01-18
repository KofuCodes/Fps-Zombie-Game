using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private float pickUpRange;
    [SerializeField] private LayerMask pickUpLayer;

    private Camera cam;
    private inventory inv;


    private void Start()
    {
        GetRef();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, pickUpRange, pickUpLayer))
            {
                Debug.Log("Hit: " + hit.transform.name);
                Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                inv.AddItem(newItem);
                Destroy(hit.transform.gameObject);
            }
        }
    }
    private void GetRef()
    {
        cam = GetComponentInChildren<Camera>();
        inv = GetComponent<inventory>();
    }

}
