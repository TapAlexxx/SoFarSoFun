using UnityEngine;

namespace StaticData
{

    [CreateAssetMenu(menuName = "StaticData/LevelStaticData", fileName = "LevelStaticData", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        public GameObject Player;
        public GameObject Ball;
        [Space(20)]
        public int BallCount;
        public float BallSpawnRadius = 10f;
        public float ClickPower = 200;
        public float ComboResetTime;
    }

}