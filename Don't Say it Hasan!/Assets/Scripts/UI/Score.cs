using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        SceneDirector director;
        TMP_Text m_textComponent;
        int score = 0;
        void Awake()
        {
            director = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
            m_textComponent = GetComponent<TMP_Text>();
        }

        // Update is called once per frame
        void Update()
        {
            score = director.score;
            m_textComponent.text = score.ToString() + "/";
        }

        public void AddScore(int change)
        {
            score += change;
        }
    }
}


