using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Utility
{
    public class WordQueue : MonoBehaviour
    {
        public TextAsset wordList;
        private int size;
        private List<string> startingWords;
        private Queue<String> wordQueue;

        public int Size { get => wordQueue.Count; }

        void Awake()
        {
            startingWords = new List<string>(wordList.text.Split(new string[] { "\n", "\r\n", "\r" }, StringSplitOptions.None));
            wordQueue = new Queue<string>(startingWords);
        }

        public string GetNextWord()
        {
            string nextWord = wordQueue.Dequeue();

            wordQueue.Enqueue(nextWord);
            return nextWord;
        }
    }
}