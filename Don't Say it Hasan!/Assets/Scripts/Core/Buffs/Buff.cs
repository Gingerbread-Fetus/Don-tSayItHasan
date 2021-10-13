using UnityEngine;

namespace Core
{
    public abstract class Buff
    {
        public ScriptableBuff thisBuff { get; }
        protected readonly GameObject Obj;

        public Buff(ScriptableBuff buff)
        {
            thisBuff = buff;
        }

        /* Activates the buff*/
        public void Activate()
        {
            ApplyEffect();
        }

        protected abstract void ApplyEffect();
        public abstract void End();
    }
}
