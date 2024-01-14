using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthSystem : MonoBehaviour {
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private TextMeshProUGUI currentHealthText;

    private void Start() {
        currentHealth = maxHealth;
        RefreshUI();
    }

    public bool CanBeHealed() {
        return currentHealth < maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        RefreshUI();

        if (currentHealth <= 0) {
            SceneManager.LoadScene(0);
        }
    }

    public void Heal(int value) {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        RefreshUI();
    }

    private void RefreshUI() {
        currentHealthText.text = $"{currentHealth}/{maxHealth}HP";
    }
}