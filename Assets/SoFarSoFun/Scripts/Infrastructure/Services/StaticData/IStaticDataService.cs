using System.Collections.Generic;
using Infrastructure.Services.ColorService;
using StaticData;
using UnityEngine;
using Window;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        GameStaticData GameConfig();
        WindowConfig ForWindow(WindowTypeId windowTypeId);
        List<Color> GetColorData();
        LevelStaticData GetLevelStaticData();
    }
}