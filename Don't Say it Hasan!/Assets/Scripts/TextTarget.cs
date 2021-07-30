using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTarget : MonoBehaviour
{
    private TextMeshProUGUI gt;
    private RectTransform m_RectTransform;
    WordQueue queue;
    void Awake() 
    {
        queue = GameObject.FindGameObjectWithTag("Word Queue").GetComponent<WordQueue>();
        m_RectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        gt.text = queue.GetNextWord();
        GetComponent<KBInListener>().targetString = gt.text;
    }

    public void ChangeWord()
    {
        gt.text = queue.GetNextWord();
        GetComponent<KBInListener>().targetString = gt.text;
        //TODO: Play effect
        GetComponentInParent<ReactPanel>().MoveWord(m_RectTransform);
    }
}
