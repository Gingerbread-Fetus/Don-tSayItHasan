using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Girls;
using UnityEngine.UI;

namespace UI
{
    public class UIEndOfDay : MonoBehaviour
    {
        [SerializeField] Image UIImage;
        private void OnEnable() {
            UIImage.sprite = girlImages[0];
        }

        List<Sprite> girlImages = new List<Sprite>();
        public void SetPictures(SlaveGirl[] girls)
        {
            foreach (SlaveGirl girl in girls)
            {
                //Get random pic and add to images
                int index = Random.Range(0, girl.images.Length);
                girlImages.Add(girl.images[index]);
            }
        }
    }
}
