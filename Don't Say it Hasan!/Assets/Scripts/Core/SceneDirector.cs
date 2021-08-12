using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Core
{
    public class SceneDirector : MonoBehaviour
    {
        [SerializeField] GameObject endGamePanel;
        List<ITimed> timedObjects;
        ProgressSlider slider;

        [HideInInspector] public int wordCount = 0;
        [HideInInspector] public int totalWords = 0;
        [HideInInspector] public int score = 0;
        [HideInInspector] public float stressLevel = 0f;
        public float levelTime = 0f;

        private void Start()
        {
            slider = FindObjectOfType<ProgressSlider>();
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
            totalWords = GameObject.FindGameObjectWithTag("Word Queue").GetComponent<WordQueue>().Size;
        }

        private void Update()
        {
            slider.CurrentProgress = ((float)wordCount / (float)totalWords);
            levelTime += Time.deltaTime;
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

        public void Reset()
        {
            foreach (ITimed timed in timedObjects)
            {
                timed.Reset();
            }
            wordCount = 0;
            score = 0;
            stressLevel = 0f;
        }
    }
}
