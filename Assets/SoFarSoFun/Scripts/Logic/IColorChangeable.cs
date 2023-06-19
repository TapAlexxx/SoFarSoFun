using UnityEngine;

namespace Logic
{

    public interface IColorChangeable
    {
        void ChangeColor(Color color);
        Color TargetColor { get; }
    }

}