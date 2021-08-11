using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core
{
    public class TimeSlider : MonoBehaviour, ITimed
    {
        [SerializeField] UnityEvent onTimesUp;
        float levelTime;
        float currentTime = 0;
        private SceneDirector director;
        Slider sliderCmp;
        // Start is called before the first frame update
        void Start()
        {
            director = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
            levelTime = director.levelTime;
            sliderCmp = GetComponent<Slider>();
            Invoke("OnTimesUp", levelTime);
        }

        // Update is called once per frame
        void Update()
        {
            if (sliderCmp.value < 1.0f)
            {
                currentTime += Time.deltaTime;
                sliderCmp.value = currentTime / levelTime;
            }
        }

        public float GetProgress()
        {
            return sliderCmp.value * 100;
        }

        void OnTimesUp()
        {
            onTimesUp.Invoke();
        }

        public void TimesUp()
        {
        }

        public void Reset()
        {
            sliderCmp.value = 0f;
            currentTime = 0;
            Invoke("OnTimesUp", levelTime);
        }
    }
}
