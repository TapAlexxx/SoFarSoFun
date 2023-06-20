using UnityEngine;

namespace StaticData
{

    [CreateAssetMenu(menuName = "StaticData/LevelStaticData", fileName = "LevelStaticData", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        [Header("Prefabs")]
        public GameObject Player;
        public GameObject Ball;
        
        [Space(20)]
        
        [Header("Input")]
        public float ClickPower = 200;
        
        [Space(20)]
        
        [Header("Ball")]
        public int BallCount;
        public float BallSpawnRadius = 10f;

        [Space(20)]

        [Header("Combo")]
        public float ComboResetTime;
        public int MaxCombo = 10;
    }

}