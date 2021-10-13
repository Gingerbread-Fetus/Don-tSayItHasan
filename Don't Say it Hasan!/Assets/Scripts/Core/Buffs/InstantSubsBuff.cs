using System.Collections;
using System.Collections.Generic;
using Core;
using UI;
using UnityEngine;

public class InstantSubsBuff : Buff
{
    private readonly SceneDirector _dirComponent;
    int subChange;
    public InstantSubsBuff(ScriptableBuff buff, int subs) : base(buff)
    {
        _dirComponent = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
        subChange = subs;
    }

    public override void End()
    {
    }

    protected override void ApplyEffect()
    {
        _dirComponent.AddScore(subChange);
    }
}
