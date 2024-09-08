using UnityEngine;

public abstract class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += ChangeHealthInfo;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeHealthInfo;
    }

    public abstract void ChangeHealthInfo(float currentHealth);

    public float GetHealthPrecentage(float currentHeatlh)
    {
        float maxPrecentage = 100;

        return currentHeatlh / _health.MaxValue * maxPrecentage;
    }
}
