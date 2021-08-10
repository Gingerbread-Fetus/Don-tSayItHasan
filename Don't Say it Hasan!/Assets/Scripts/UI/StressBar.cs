using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StressBar : MonoBehaviour, ITimed
    {
        Slider slider;
        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        public void AddStress(float damage)
        {
            slider.value += damage;
        }

        public void TimesUp()
        {
        }
    }
}