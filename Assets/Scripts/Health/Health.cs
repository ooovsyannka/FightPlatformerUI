using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private CharacterRenderer _characterRenderer;

    private float _regenerationDelay = 0.5f;
    private Coroutine _regenerationDelayCoroutine;

    public int MaxValue { get { return _maxValue; } }   
    public int CurrentValue { get; private set; }

    public event Action Died;
    public event Action<float> IncreasedCurrentValue;
    public event Action<float> DecreaseCurrentValue;

    private void Start()
    {
        Recovery();
    }

    public void Recovery()
    {
        CurrentValue = _maxValue;

        IncreasedCurrentValue?.Invoke(CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            damage *= -1;

        CurrentValue = Math.Clamp(CurrentValue - damage, 0, _maxValue);
        _characterRenderer.TakeDamageColor();

        DecreaseCurrentValue?.Invoke(CurrentValue);

        if (CurrentValue == 0)
        {
            Died?.Invoke();
        }
    }

    public void Regeneration(int desiredCount)
    {
        if (_regenerationDelayCoroutine != null)
            StopCoroutine(_regenerationDelayCoroutine);

        _regenerationDelayCoroutine = StartCoroutine(RegenerationDelay(desiredCount));
    }

    private IEnumerator RegenerationDelay(int desiredCount)
    {
        for (int i = 0; i < desiredCount; i++)
        {
            if (CurrentValue < _maxValue)
            {
                CurrentValue++;
                _characterRenderer.RegenerationColor();
                IncreasedCurrentValue?.Invoke(CurrentValue);
            }
            else
            {
                StopCoroutine(_regenerationDelayCoroutine);
            }

            yield return new WaitForSeconds(_regenerationDelay);
        }
    }
}
