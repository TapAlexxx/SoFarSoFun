using System;

namespace Infrastructure.Services.PersistenceProgress.Player
{

    [Serializable]
    public class PlayerProgressData
    {
        public int BallHits;
        public int WallHits;
        
        public Action BallHitsChanged;
        public Action WallHitsChanged;

        public void SaveMaxBallHits(int amount)
        {
            BallHits = amount;
            BallHitsChanged?.Invoke();
        }
        
        public void SaveMaxWallHits(int amount)
        {
            WallHits = amount;
            WallHitsChanged?.Invoke();
        }
    }

}