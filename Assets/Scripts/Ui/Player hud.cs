using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhud : MonoBehaviour
{
    [SerializeField] private Progressbar healthBar;
    //[SerializeField] private WeaponUI weaponUi;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthBar.SetValues(currentHealth, maxHealth);
    }

    /*public void UpdateWeaponUi(Weapon newWeapon)
    {
         weaponUi.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.magazineCount);
    }
    */
}
