using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/ScoreBuff")]
public class ScoreMultBuff : ScriptableBuff
{
    [SerializeField] float newMultiplier = 1.1f;
    public override Buff InitializeBuff()
    {
        return new MultiplierBuff(this, newMultiplier);
    }
}
