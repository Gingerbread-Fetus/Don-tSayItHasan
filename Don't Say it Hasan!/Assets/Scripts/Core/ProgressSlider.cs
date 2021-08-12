using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core
{
    public class ProgressSlider : MonoBehaviour, ITimed
    {
        [SerializeField] UnityEvent onFinish;
        float levelTime;
        private SceneDirector director;
        Slider sliderCmp;

        public float CurrentProgress
        {
            get
            {
                return sliderCmp.value;
            }
            set
            {
                if (value >= sliderCmp.maxValue)
                {
                    onFinish.Invoke();
                }
                sliderCmp.value = value % sliderCmp.maxValue;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            director = GameObject.FindGameObjectWithTag("Director").GetComponent<SceneDirector>();
            levelTime = director.levelTime;
            sliderCmp = GetComponent<Slider>();
            if (onFinish == null)
            {
                onFinish = new UnityEvent();
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        public float GetProgress()
        {
            return sliderCmp.value * 100;
        }

        void OnFinish()
        {
            onFinish.Invoke();
        }

        public void TimesUp()
        {
        }

        public void Reset()
        {
            sliderCmp.value = 0f;
        }
    }
}
