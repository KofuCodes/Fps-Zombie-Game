using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public items[] weapons;

    private void Start()
    {
        InitVariables();
    }

    private void InitVariables()
    {
        weapons = new items[1];
    }
}
