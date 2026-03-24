using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public health health;
    public Slider slider;

    void Start()
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }

    void OnEnable()
    {
        health.onDamaged.AddListener(UpdateBar);
        health.onHealed.AddListener(UpdateBar);
    }

    void OnDisable()
    {
        health.onDamaged.RemoveListener(UpdateBar);
        health.onHealed.RemoveListener(UpdateBar);
    }

    void UpdateBar()
    {
        slider.maxValue = health.maxHealth;
        slider.value = health.currentHealth;
    }
}
