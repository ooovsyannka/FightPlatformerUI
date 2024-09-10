using UnityEngine;

public class ButtonRecovery : SimpleButton
{
    [SerializeField] private float _regenCount;

    public override void Action()
    {
        Health.Regenerate(_regenCount);
    }
}