using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core
{
    public class TimeSlider : MonoBehaviour
    {
        [SerializeField] UnityEvent onTimesUp;
        [SerializeField] float levelTime;
        float currentTime = 0;
        Slider sliderCmp;
        // Start is called before the first frame update
        void Start()
        {
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
    }
}
