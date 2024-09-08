using UnityEngine;
using UnityEngine.UI;

public class ButtonRecovery : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(RecoverHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RecoverHealth);
    }

    private void RecoverHealth()
    {
        _health.Recovery();
    }
}

