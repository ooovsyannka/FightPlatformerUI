using UnityEngine;
using UnityEngine.UI;

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
        _button.onClick.AddListener(Action);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Action);
    }

    public abstract void Action();
}