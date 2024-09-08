using UnityEngine;

public class ButtonDamage : SimpleButton
{
    [SerializeField] private int _count;

    public override void Action()
    { 
        Health.TakeDamage(_count);
    }
}