using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Progressbar : MonoBehaviour
{
    private float baseValue;
    private float maxValue;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI amount;

    public void SetValues(float _baseValue, float _maxValue)
    {
        baseValue = _baseValue;
        maxValue = _maxValue;

        amount.text = baseValue.ToString("0.##") + "/" + maxValue.ToString("0.##");

        CalculateFillAmount();
    }

    private void CalculateFillAmount()
    {
        float fillAmount = baseValue / maxValue;
        fill.fillAmount = fillAmount;
    }
}