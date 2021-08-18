using Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class StressBar : MonoBehaviour
    {
        [SerializeField] UnityEvent onLose;

        Slider slider;
        float currentStress;

        public float CurrentStress
        {
            get
            {
                return currentStress;
            }
            set
            {
                if (currentStress >= slider.maxValue)
                {
                    onLose.Invoke();
                }
                currentStress = value;
            }
        }

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void Update()
        {
            slider.value = currentStress;
        }
    }
}