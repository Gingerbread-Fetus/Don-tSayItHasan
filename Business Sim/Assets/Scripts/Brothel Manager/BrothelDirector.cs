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
            Debug.Log(roster.GirlsRoster[0].cName + " got fucked and liked it! Made 10 gold.");
            endDayCanvas.GetComponent<UIEndOfDay>().SetPictures(roster.GirlsRoster);
            endDayCanvas.gameObject.SetActive(true);
        }
    }
}
