using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChatterBanButton : MonoBehaviour
    {
        [HideInInspector] public ScriptableBuff buff;

        Button buttonCmp;
        [SerializeField] TMP_Text chatterName;
        [SerializeField] TMP_Text chatMessage;
        [SerializeField] TMP_Text banEffect;

        // Start is called before the first frame update
        void Start()
        {
            buttonCmp = GetComponent<Button>();
            buttonCmp.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            Time.timeScale = 1;
            buff.InitializeBuff().Activate();
        }

        public void SetChatName(string newName)
        {
            chatterName.text = newName;
        }

        public void SetEffectDescription(string banDescription)
        {
            banEffect.text = banDescription;
        }

        public void SetChatMessage(string newMessage)
        {
            chatMessage.text = newMessage;
        }
    }
}
