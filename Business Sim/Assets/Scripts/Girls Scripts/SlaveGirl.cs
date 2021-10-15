using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Girls
{
    [CreateAssetMenu(fileName = "New Girl", menuName = "Business Sim/Create New Girl", order = 0)]
    public class SlaveGirl : ScriptableObject 
    {
        public string cName { get {return characterName;} }
        
        [SerializeField]
        string characterName = "";
        public Sprite coverImage;
        public Sprite[] images;
    }
}
