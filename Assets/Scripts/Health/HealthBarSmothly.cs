using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBarSmothly : HealthRenderer
{
    [SerializeField] private float _updateValueSpeed;

    private Slider _bar;
    private Coroutine _smoothlyChangeHealthCoroutine;

    private void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    public override void ChangeHealthInfo(float currentHealth)
    {
        if (_smoothlyChangeHealthCoroutine != null)
            StopCoroutine(_smoothlyChangeHealthCoroutine);

        _smoothlyChangeHealthCoroutine = StartCoroutine(SmoothlyChangeRenderer(GetHealthPrecentage(currentHealth)));
    }

    private IEnumerator SmoothlyChangeRenderer(float currentHealth)
    {
        while (_bar.value != currentHealth)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, currentHealth, _updateValueSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
