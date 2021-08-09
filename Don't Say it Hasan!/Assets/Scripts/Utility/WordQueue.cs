using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class WordQueue : MonoBehaviour
    {
        public List<string> startingWords;
        private Queue<String> wordQueue;

        void Awake()
        {
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