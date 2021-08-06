using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text m_textComponent;
    int score = 0;
    void Awake()
    {
        m_textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_textComponent.text = score.ToString() + "/";
    }

    public void AddScore(int change)
    {
        score += change;
    }
}
