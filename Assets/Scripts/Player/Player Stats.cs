using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Characterstats
{
    private Playerhud Hud;
    private UiManager ui;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void GetReferences()
    {
        Hud = GetComponent<Playerhud>();
        ui = GetComponent<UiManager>();
    }
    public override void CheckHealth()
    {
        base.CheckHealth();
        Hud.UpdateHealth(health, maxHealth);
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
        ui.SetActiveHud(false);
    }
}
