using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform WeaponHolderR = null;
    private Animator anim;
    private inventory inv;

    // Start is called before the first frame update
    private void Start()
    {
        Getref();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeaponAnim(0, WeaponType.AR);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeaponAnim(1, WeaponType.Pistol);
            EquipWeapon(inv.GetItem(1).prefab, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeaponAnim(2, WeaponType.Melee);
        }
    }

    private void SetWeaponAnim(int weaponStyle, WeaponType weaponType)
    {
        Weapon weapon = inv.GetItem(weaponStyle);
        if (weapon != null)
        {
            if (weapon.weaponType == weaponType)
            {
                anim.SetInteger("weaponType", (int)weaponType);
            }
        }

    }

    private void EquipWeapon(GameObject weaponObject, int weaponStyle)
    {
        Weapon weapon = inv.GetItem(weaponStyle);
        if(weapon != null)
        {
            Instantiate(weaponObject, WeaponHolderR);
        }
    }

    private void Getref()
    {
        anim = GetComponentInChildren<Animator>();
        inv = GetComponent<inventory>();
    }
}
