using UnityEngine;

namespace StaticData
{

    [CreateAssetMenu(menuName = "StaticData/LevelStaticData", fileName = "LevelStaticData", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        public GameObject Player;
        
        public int BallCount;
        public float ClickPower;
        public float ComboResetTime;
    }

}