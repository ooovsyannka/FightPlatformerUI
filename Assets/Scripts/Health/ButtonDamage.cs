using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]

public class ButtonDamage : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _damage;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(CauseDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CauseDamage);
    }

    private void CauseDamage()
    {
        _health.TakeDamage(_damage);
    }
}

