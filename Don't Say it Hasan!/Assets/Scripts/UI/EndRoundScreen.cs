using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class EndRoundScreen : MonoBehaviour
    {
        [SerializeField] TMP_Text wordsPerMinuteText;
        [SerializeField] TMP_Text subsText;
        [SerializeField] TMP_Text reactsText;
        [SerializeField] SceneDirector director;
        private void OnEnable()
        {
            wordsPerMinuteText.text = ((float)director.wordCount / (director.levelTime / 60f)).ToString();
            subsText.text = director.score.ToString();
            reactsText.text = director.wordCount.ToString();
        }
    }
}
