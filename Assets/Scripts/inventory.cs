using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private Playerhud hud;

    private void Start()
    {
        getref();
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;

        hud.UpdateWeaponUi(newItem);
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void InitVariables()
    {
        weapons = new Weapon[3];
    }

    private void getref()
    {
        hud = GetComponent<Playerhud>();
    }
}
