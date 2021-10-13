namespace Core
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "MessageData", menuName = "Don't Say it Hasan!/MessageData", order = 0)]
    public class MessageData : ScriptableObject
    {
        [SerializeField, TextArea(15, 20)] List<string> possibleMessages;

        public string GetRandomMessage()
        {
            int index = Random.Range(0, possibleMessages.Count - 1);
            return possibleMessages[index];
        }
    }
}
