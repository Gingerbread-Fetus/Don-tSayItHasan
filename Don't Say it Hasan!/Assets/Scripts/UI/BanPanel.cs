using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace UI
{
    public class BanPanel : MonoBehaviour
    {
        [SerializeField] TwitchChat chat;
        [SerializeField] MessageData banMessages;
        [SerializeField] List<ScriptableBuff> buffs;

        private void OnEnable()
        {
            Chatter[] chatters = chat.transform.GetComponentsInChildren<Chatter>();
            ChatterBanButton[] buttons = transform.GetComponentsInChildren<ChatterBanButton>();
            List<ScriptableBuff> removedBuffs = new List<ScriptableBuff>();
            foreach (ChatterBanButton button in buttons)
            {
                int index = Random.Range(0, chatters.Length - 1);
                button.SetChatName(chatters[index].GetName());
                int randomBuff = Random.Range(0, buffs.Count - 1);
                button.buff = buffs[randomBuff];
                removedBuffs.Add(button.buff);
                buffs.RemoveAt(randomBuff);
                button.SetEffectDescription(button.buff.BuffDescription);
                button.SetChatMessage(banMessages.GetRandomMessage());
            }
            buffs.AddRange(removedBuffs);
        }
    }
}
