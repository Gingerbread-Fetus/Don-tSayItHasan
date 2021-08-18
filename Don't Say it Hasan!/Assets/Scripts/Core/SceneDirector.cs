using System;
using System.Collections;
using System.Collections.Generic;
using CoreInput;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Core
{
    public class SceneDirector : MonoBehaviour
    {
        [SerializeField] GameObject endGamePanel;
        [SerializeField] GameObject stunlockPanel;
        [SerializeField] Countdown countdown;
        [SerializeField] StressBar stressBar;
        [SerializeField] int countdownTime;
        [SerializeField] List<int> stunlockPositions;

        int nextStunlock = 5;
        List<ITimed> timedObjects;
        ProgressSlider slider;

        [HideInInspector] public int wordCount = 0;
        [HideInInspector] public int totalWords = 0;
        [HideInInspector] public int score = 0;//TODO: Move this back to score component and have it referenced from a field.
        [HideInInspector] public float levelTime = 0f;

        private void Awake()
        {
            ReactPanel.timeOut = true;
            StartCoroutine(StartGameCountdown(countdownTime));
        }

        private void Start()
        {
            slider = FindObjectOfType<ProgressSlider>();
            SetupTimedObjects();
            totalWords = GameObject.FindGameObjectWithTag("Word Queue").GetComponent<WordQueue>().Size;
            slider.totalWords = totalWords;
            nextStunlock = (stunlockPositions.Count == 0) ? 5 : stunlockPositions[0];
        }

        private void SetupTimedObjects()
        {
            timedObjects = new List<ITimed>();
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (var rootGameObject in rootGameObjects)
            {
                ITimed[] childrenInterfaces = rootGameObject.GetComponentsInChildren<ITimed>();
                foreach (var childInterface in childrenInterfaces)
                {
                    timedObjects.Add(childInterface);
                }
            }
        }

        private void Update()
        {
            if (!ReactPanel.timeOut)
            {
                levelTime += Time.deltaTime;
            }
            CheckForStunlock();
        }

        //TODO: Reset stunlocks?
        private void CheckForStunlock()
        {
            if (wordCount == nextStunlock)
            {
                Time.timeScale = 0;
                print(levelTime);
                stunlockPanel.SetActive(true);

                if (stunlockPositions.Count > 0)
                {
                    stunlockPositions.RemoveAt(0);
                    nextStunlock = (stunlockPositions.Count > 0) ? stunlockPositions[0] : -1;
                    return;
                }
            }
        }

        internal void AddScore(int wordLength)
        {
            score += wordLength;
        }

        internal void AddStress(float stress)
        {
            stressBar.CurrentStress += stress;
        }

        public void FinishGame()
        {
            foreach (ITimed timed in timedObjects)
            {
                timed.TimesUp();
            }
            //Start end game transition
            endGamePanel.SetActive(true);
        }

        public void GameOver()
        {
            foreach (ITimed timed in timedObjects)
            {
                timed.TimesUp();
            }
        }

        public void Reset()
        {
            foreach (ITimed timed in timedObjects)
            {
                timed.Reset();
            }
            wordCount = 0;
            score = 0;
            stressBar.CurrentStress = 0f;
            levelTime = 0;
        }

        private IEnumerator StartGameCountdown(float countdownTime)
        {
            countdown.gameObject.SetActive(true);
            int tmpCountdown = (int)countdownTime;
            while (tmpCountdown > 0)
            {
                countdown.TextCmp.text = tmpCountdown.ToString();
                yield return new WaitForSeconds(1.0f);
                tmpCountdown--;
            }
            countdown.gameObject.SetActive(false);
            ReactPanel.timeOut = false;
        }
    }
}