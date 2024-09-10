using UnityEngine;

public class ButtonDamage : SimpleButton
{
    [SerializeField] private int _damageCount;

    public override void ChangeHealthValue()
    { 
        Health.TakeDamage(_damageCount);
    }
}