using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public abstract class SimpleButton : MonoBehaviour 
{
    [SerializeField] private Health _health;

    private Button _button;

    protected Health Health {  get { return _health; } }

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeHealthValue);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeHealthValue);
    }

    public abstract void ChangeHealthValue();
}