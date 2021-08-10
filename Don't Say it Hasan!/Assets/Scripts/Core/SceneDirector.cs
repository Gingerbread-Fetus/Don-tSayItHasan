using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneDirector : MonoBehaviour
    {
        [SerializeField] GameObject endGamePanel;
        List<ITimed> timedObjects;

        private void Start()
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

        public void TimesUp()
        {
            foreach (ITimed timed in timedObjects)
            {
                timed.TimesUp();
            }
            //Start end game transition
            endGamePanel.SetActive(true);
        }
    }
}
