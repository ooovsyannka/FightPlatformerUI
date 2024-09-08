using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class HealthBarText : HealthRenderer 
{
    private TextMeshProUGUI _bar;

    private void Awake()
    {
        _bar = GetComponent<TextMeshProUGUI>();
    }

    public override void ChangeHealthInfo(float currentHealth)
    {
        int maxHealthPrecentage = 100;
        _bar.text = $"HEALTH - {GetHealthPrecentage(currentHealth)}% / {maxHealthPrecentage}%";
    }
}
