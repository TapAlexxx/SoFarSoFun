using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{

    [CreateAssetMenu(menuName = "StaticData/Color", fileName = "ColorData", order = 0)]
    public class ColorStaticData : ScriptableObject
    {
        public List<Color> ColorData = new List<Color>();
    }

}