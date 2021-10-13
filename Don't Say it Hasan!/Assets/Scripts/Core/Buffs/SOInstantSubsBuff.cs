using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/InstantSubs")]
public class SOInstantSubsBuff : ScriptableBuff
{
    [SerializeField] int gainedSubs = 10;
    public override Buff InitializeBuff()
    {
        return new InstantSubsBuff(this, gainedSubs);
    }
}
