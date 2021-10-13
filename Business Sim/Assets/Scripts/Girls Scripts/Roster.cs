using UnityEngine;
namespace Girls
{
    [CreateAssetMenu(fileName = "Roster", menuName = "Business Sim/Roster", order = 0)]
    public class Roster : ScriptableObject
    {
        public SlaveGirl[] GirlsRoster;
    }
}