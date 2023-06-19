using System;

namespace Infrastructure.Services.PersistenceProgress.Player
{
    [Serializable]
    public class PlayerData
    {
        public PlayerProgressData ProgressData = new PlayerProgressData();
    }

}