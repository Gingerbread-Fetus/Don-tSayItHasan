using System.Collections;
using System.Collections.Generic;
using Core;
using UI;
using UnityEngine;

public class RemoveStressBuff : Buff
{
    private readonly StressBar _stressComponent;
    float stressReduction;
    public RemoveStressBuff(ScriptableBuff buff, float stressChange) : base(buff)
    {
        _stressComponent = GameObject.FindGameObjectWithTag("Stress").GetComponent<StressBar>();
        stressReduction = stressChange;
    }

    public override void End()
    {
    }

    protected override void ApplyEffect()
    {
        _stressComponent.CurrentStress -= stressReduction;
    }
}
