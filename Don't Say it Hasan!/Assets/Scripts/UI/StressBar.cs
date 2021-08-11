using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StressBar : MonoBehaviour
    {
        Slider slider;

        SceneDirector director;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            director = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
        }

        private void Update()
        {
            slider.value = director.stressLevel;
        }
    }
}