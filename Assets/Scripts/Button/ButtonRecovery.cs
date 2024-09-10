using UnityEngine;

public class ButtonRecovery : SimpleButton
{
    [SerializeField] private float _regenCount;

    public override void ChangeHealthValue()
    {
        Health.Regenerate(_regenCount);
    }
}