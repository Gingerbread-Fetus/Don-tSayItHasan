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
        public float multiplier = 1f;
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

        public void SetMultiplier(float newMultiplier)
        {
            multiplier = newMultiplier;
        }

        public void ChangeMultiplier(float deltaChange)
        {
            multiplier += deltaChange;
        }
    }
}


