using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI magazineSizeText;
    [SerializeField] private TextMeshProUGUI magazineCountText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfo(Sprite weaponIcon, int magazineSize, int magazineCount)
    {
        icon.sprite = weaponIcon;
        magazineSizeText.text = magazineSize.ToString();
        int magazineCountAmount = magazineSize* magazineCount;
        magazineCountText.text = magazineCountAmount.ToString();
    }

}
