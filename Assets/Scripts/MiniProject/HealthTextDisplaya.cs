using UnityEngine;
using TMPro;

public class HealthTextDisplaya : MonoBehaviour
{
    private TextMeshProUGUI healthText;

    void Awake()
    {
        healthText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText(float current, float max)
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + (int)current + " / " + (int)max;
        }
    }
}