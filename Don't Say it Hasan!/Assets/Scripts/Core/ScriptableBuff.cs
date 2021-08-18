using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class ScriptableBuff : ScriptableObject
    {
        [SerializeField] string buffDescription;

        public string BuffDescription { get => buffDescription; }

        public abstract Buff InitializeBuff();
    }
}
