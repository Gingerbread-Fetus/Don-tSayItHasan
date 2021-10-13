using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffs/RemoveStress")]
public class SORemoveStress : ScriptableBuff
{
    [SerializeField] float stressChange = 0.05f;
    public override Buff InitializeBuff()
    {
        return new RemoveStressBuff(this, stressChange);
    }
}
