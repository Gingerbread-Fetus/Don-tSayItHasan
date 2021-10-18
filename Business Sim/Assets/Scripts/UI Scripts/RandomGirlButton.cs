using System.Collections;
using System.Collections.Generic;
using Girls;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RandomGirlButton : MonoBehaviour
    {
        SlaveGirl hiddenGirl;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetGirl(SlaveGirl girl)
        {
            hiddenGirl = girl;
        }

        public void RevealGirl()
        {
            GetComponent<Image>().sprite = hiddenGirl.coverImage;
        }

        public void ClearButton()
        {
            GetComponent<Image>().sprite = null;
            hiddenGirl = null;
        }
    }
}
