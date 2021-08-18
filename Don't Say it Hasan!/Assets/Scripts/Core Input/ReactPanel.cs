using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Utility;

namespace CoreInput
{
    public class ReactPanel : MonoBehaviour, ITimed
    {
        [SerializeField] int startingNumberOfWords = 3;
        [SerializeField] GameObject targetWordPrefab;
        [SerializeField] float yOffset = 100;
        [SerializeField] float xOffset = 100;
        private RectTransform m_RectTransform;
        private CircleBuffer<TextTarget> targets;
        public static TextTarget selected;
        public static bool isSwitching = false;
        public static bool timeOut = false;

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
            if (Input.GetButtonDown("Switch") && !timeOut)
            {
                SwitchForward();
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && !timeOut)
            {
                if (Input.GetButtonDown("Switch"))
                {
                    SwitchBackward();
                }
            }
        }

        public void SwitchForward()
        {
            StartCoroutine(WaitForKeyUp());
            selected.isSelected = false;
            selected = targets.MoveNext();
            selected.isSelected = true;
        }

        public void SwitchBackward()
        {
            StartCoroutine(WaitForKeyUp());
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

        IEnumerator WaitForKeyUp()
        {
            isSwitching = true;
            yield return new WaitUntil(() => !Input.anyKey);
            isSwitching = false;
        }

        public void Reset()
        {
            timeOut = false;
        }

        public void TimesUp()
        {
            timeOut = true;
        }
    }
}

