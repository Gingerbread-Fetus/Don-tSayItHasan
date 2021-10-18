using System.Collections.Generic;
using UnityEngine;
namespace Girls
{
    [CreateAssetMenu(fileName = "Roster", menuName = "Business Sim/Roster", order = 0)]
    public class Roster : ScriptableObject
    {
        public List<SlaveGirl> GirlsRoster;

        public void RemoveGirl(int index)
        {
            GirlsRoster.RemoveAt(index);
        }

        public void AddGirl(SlaveGirl newGirl)
        {
            GirlsRoster.Add(newGirl);
        }

        public SlaveGirl GetGirl(int index)
        {
            return GirlsRoster[index];
        }

        public int GetRandomGirlIndex()
        {
            return Random.Range(0, GirlsRoster.Count);
        }
    }
}