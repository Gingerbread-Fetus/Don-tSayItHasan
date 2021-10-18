using System.Collections;
using System.Collections.Generic;
using Girls;
using UI;
using UnityEngine;

namespace Management
{    
    public class BrothelDirector : MonoBehaviour
    {
        [SerializeField]
        Canvas endDayCanvas;

        public Roster roster;
        // Start is called before the first frame update
        public void NextDay()
        {
            endDayCanvas.GetComponent<UIEndOfDay>().SetPictures(roster.GirlsRoster);
            endDayCanvas.gameObject.SetActive(true);
        }
    }
}
