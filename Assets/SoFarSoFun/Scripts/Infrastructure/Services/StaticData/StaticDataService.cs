using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEngine;
using Window;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string GameConfigPath = "StaticData/GameConfig";
        private const string WindowsStaticDataPath = "StaticData/WindowsStaticData";
        private const string ColorStaticDataPath = "StaticData/Color/ColorStaticData";
        private const string LevelStaticDataPath = "StaticData/Level/LevelStaticData";

        private GameStaticData _gameStaticData;
        private Dictionary<WindowTypeId, WindowConfig> _windowConfigs;
        private ColorStaticData _colorStaticData;
        private LevelStaticData _levelStaticData;

        public void LoadData()
        {
            _gameStaticData = Resources
                .Load<GameStaticData>(GameConfigPath);
            
            _windowConfigs = Resources
                .Load<WindowStaticData>(WindowsStaticDataPath)
                .Configs.ToDictionary(x => x.WindowTypeId, x => x);

            _colorStaticData = Resources
                .Load<ColorStaticData>(ColorStaticDataPath);
            
            _levelStaticData = Resources
                .Load<LevelStaticData>(LevelStaticDataPath);
        }

        public GameStaticData GameConfig() =>
            _gameStaticData;

        public WindowConfig ForWindow(WindowTypeId windowTypeId) => 
            _windowConfigs[windowTypeId];

        public List<Color> GetColorData() => 
            _colorStaticData.ColorData;

        public LevelStaticData GetLevelStaticData() => 
            _levelStaticData;
    }
}