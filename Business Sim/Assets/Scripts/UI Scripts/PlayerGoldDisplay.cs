using System.Collections;
using System.Collections.Generic;
using Items;
using TMPro;
using UnityEngine;

namespace UI
{    
    public class PlayerGoldDisplay : MonoBehaviour
    {
        TMP_Text m_TextComponent;
        [SerializeField]Inventory inventory;
        private void Awake() 
        {
            m_TextComponent = GetComponent<TMP_Text>();
        }
        // Start is called before the first frame update
        void Start()
        {
            m_TextComponent.text = inventory.money.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            m_TextComponent.text = inventory.money.ToString();
        }
    }
}
