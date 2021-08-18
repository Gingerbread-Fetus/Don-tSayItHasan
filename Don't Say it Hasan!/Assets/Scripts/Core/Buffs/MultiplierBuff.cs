using Core;
using UI;
using UnityEngine;

public class MultiplierBuff : Buff
{
    private readonly Score _scoreComponent;
    float multiplier;
    public MultiplierBuff(ScriptableBuff buff, float newMultiplier) : base(buff)
    {
        //Get Score component
        _scoreComponent = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        multiplier = newMultiplier;
    }

    public override void End()
    {
        _scoreComponent.SetMultiplier(1);
    }

    protected override void ApplyEffect()
    {
        //TODO: Add activated buffs to a handler that can stop them.
        _scoreComponent.SetMultiplier(multiplier);
    }
}