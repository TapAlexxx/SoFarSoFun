using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.ColorService
{

    public interface IColorService
    {
        Color GetRandomColor(Color currentColor);
    }

    public class ColorService : IColorService
    {
        private readonly IStaticDataService _staticDataService;
        
        private List<Color> _colorData;
        private bool _initialized;

        [Inject]
        public ColorService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public Color GetRandomColor(Color currentColor)
        {
            if (!_initialized)
            {
                _colorData = _staticDataService.GetColorData();
                _initialized = true;
            }

            List<Color> filteredColorData = new List<Color>(_colorData);
            filteredColorData.Remove(currentColor);
            Color newColor = filteredColorData[Random.Range(0, filteredColorData.Count)];
            return newColor;
        }
    }
}