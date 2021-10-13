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
        List<Sprite> girlImages = new List<Sprite>();
        int currentImage = 0;
        private void Awake() {
            if(gameObject.activeInHierarchy) gameObject.SetActive(false);
        }
        
        private void OnEnable() {
            UIImage.sprite = girlImages[0];
            currentImage = 0;
        }

        private void OnDisable() {
            girlImages.Clear();
        }

        public void SetPictures(SlaveGirl[] girls)
        {
            foreach (SlaveGirl girl in girls)
            {
                //Get random pic and add to images
                int index = Random.Range(0, girl.images.Length);
                girlImages.Add(girl.images[index]);
            }
        }

        public void NextImage()
        {
            print("Next Image");
            currentImage = (currentImage + 1 > (girlImages.Count - 1)) ? 0 : currentImage + 1;
            UIImage.sprite = girlImages[currentImage];
            print(currentImage);
        }

        public void PrevImage()
        {
            print("Previous Image");
            currentImage = (currentImage - 1 < 0) ? girlImages.Count - 1 : currentImage - 1;
            UIImage.sprite = girlImages[currentImage];
            print(currentImage);
        }
    }
}
