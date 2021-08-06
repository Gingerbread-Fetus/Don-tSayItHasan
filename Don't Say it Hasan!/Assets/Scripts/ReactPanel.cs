using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace CoreInput
{
    public class ReactPanel : MonoBehaviour
    {
        [SerializeField] int startingNumberOfWords = 3;
        [SerializeField] GameObject targetWordPrefab;
        [SerializeField] float yOffset = 100;
        [SerializeField] float xOffset = 100;
        private RectTransform m_RectTransform;
        // private List<TextTarget> targets;
        private CircleBuffer<TextTarget> targets;
        public static TextTarget selected;

        void Start()
        {
            m_RectTransform = GetComponent<RectTransform>();

            for (int i = 0; i < startingNumberOfWords; i++)
            {
                AddNewWord();
            }

            //Set the first TextTarget child of m_Rect to be the selected word.
            targets = new CircleBuffer<TextTarget>(transform.GetComponentsInChildren<TextTarget>());
            selected = targets.MoveNext();
            selected.isSelected = true;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Switch"))
            {
                SwitchForward();
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Input.GetButtonDown("Switch"))
                {
                    SwitchBackward();
                }
            }
        }

        private void SwitchForward()
        {
            selected.isSelected = false;
            selected = targets.MoveNext();
            selected.isSelected = true;
        }

        private void SwitchBackward()
        {
            selected.isSelected = false;
            selected = targets.MoveBack();
            selected.isSelected = true;
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
}

