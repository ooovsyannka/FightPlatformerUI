using UnityEngine;

public class ButtonDamage : SimpleButton
{
    [SerializeField] private int _damageCount;

    public override void Action()
    { 
        Health.TakeDamage(_damageCount);
    }
}