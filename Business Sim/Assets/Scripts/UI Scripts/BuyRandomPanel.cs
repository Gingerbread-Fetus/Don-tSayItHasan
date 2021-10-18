using System.Collections;
using System.Collections.Generic;
using Girls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
        public class BuyRandomPanel : MonoBehaviour
    {
        [SerializeField] Roster roster;
        [SerializeField] TMP_Text salesText;
        RandomGirlButton[] girlButtons;
        // Start is called before the first frame update
        private void Awake() 
        {
            if(gameObject.activeInHierarchy) gameObject.SetActive(false);
        }

        private void OnEnable() 
        {
            girlButtons = GetComponentsInChildren<RandomGirlButton>();
            foreach (RandomGirlButton button in girlButtons)
            {
                button.SetGirl(GetNextRandom());
            }
        }

        private void OnDisable() 
        {
            girlButtons = GetComponentsInChildren<RandomGirlButton>();
            foreach (RandomGirlButton button in girlButtons)
            {
                button.ClearButton();
            }
        }

        public SlaveGirl GetNextRandom()
        {
            //Get random girl from the Roster
            int randGirlIdx = roster.GetRandomGirlIndex();
            print(randGirlIdx);
            //Set her image
            SlaveGirl randGirl = roster.GetGirl(randGirlIdx);
            return randGirl;
        }
    }
}
