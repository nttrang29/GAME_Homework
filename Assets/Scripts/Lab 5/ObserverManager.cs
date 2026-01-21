using UnityEngine;
using TMPro;

public class ObserverManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI healthText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    [Header("Audio References")]
    public AudioSource hitSound;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += HandleHealthUpdate;
        PlayerHealth.OnPlayerDeath += HandleDeath;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= HandleHealthUpdate;
        PlayerHealth.OnPlayerDeath -= HandleDeath;
    }

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void HandleHealthUpdate(float current, float max)
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {current} / {max}";
        }

        if (current < max && current > 0)
        {
            if (hitSound != null) hitSound.Play();
        }
    }

    void HandleDeath()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (gameOverText != null) gameOverText.text = "GAME OVER!";
        }
    }
}