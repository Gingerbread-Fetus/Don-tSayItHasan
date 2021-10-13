using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core
{
    public class ProgressSlider : MonoBehaviour, ITimed
    {
        [SerializeField] UnityEvent onFinish;
        private SceneDirector director;
        Slider sliderCmp;
        [HideInInspector] public float wordCount;
        [HideInInspector] public float totalWords;

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
            sliderCmp = GetComponent<Slider>();
            if (onFinish == null)
            {
                onFinish = new UnityEvent();
            }
        }

        // Update is called once per frame
        void Update()
        {
            wordCount = director.wordCount;
            CurrentProgress = ((float)wordCount / (float)totalWords);
        }

        void OnFinish()
        {
            onFinish.Invoke();
            TimesUp();
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
