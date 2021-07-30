using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactPanel : MonoBehaviour
{
    [SerializeField] int maxWordsOnScreen = 3;
    [SerializeField] GameObject targetWordPrefab;
    [SerializeField] float yOffset = 100;
    [SerializeField] float xOffset = 100;

    private RectTransform m_RectTransform;
    private TextTarget selected;//TODO: Only the selected should be receiving input.

    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();

        for (int i = 0; i < maxWordsOnScreen; i++)
        {
            AddNewWord();
        }

        //TODO: Set the first child of m_Rect to be the selected word.
    }

    public void AddNewWord()
    {
        GameObject newWord = Instantiate(targetWordPrefab, transform, false);
        MoveWord(newWord.GetComponent<RectTransform>());
    }

    public void MoveWord(RectTransform word)
    {
        float randX = Random.Range(m_RectTransform.rect.xMin + xOffset, m_RectTransform.rect.xMax - xOffset);
        float randY = Random.Range(m_RectTransform.rect.yMin + yOffset, m_RectTransform.rect.yMax - yOffset);
        word.localPosition = new Vector3(randX, randY, 0);
    }
}
