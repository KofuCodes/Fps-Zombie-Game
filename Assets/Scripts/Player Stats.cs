using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Characterstats
{
    private Playerhud Hud;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        Hud = GetComponent<Playerhud>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        Hud.UpdateHealth(health, maxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
}
