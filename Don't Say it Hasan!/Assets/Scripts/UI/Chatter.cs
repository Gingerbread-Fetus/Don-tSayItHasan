using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Chatter : MonoBehaviour
    {
        TMP_Text m_TextComponent;
        string chatterName = "";
        private void Awake()
        {
            m_TextComponent = GetComponent<TMP_Text>();
        }

        public void SetName(string nameText)
        {
            var random = new System.Random();
            chatterName = nameText;
            var color = String.Format("#{0:X6}", random.Next(0x1000000));
            string newText = "<color=" + color + ">" + chatterName + "</color>";
            m_TextComponent.text = newText;
        }

        public string GetName()
        {
            return chatterName;
        }

        public void SetMessage(string chatMessage)
        {
            m_TextComponent.text += ": " + chatMessage;
        }
    }
}
