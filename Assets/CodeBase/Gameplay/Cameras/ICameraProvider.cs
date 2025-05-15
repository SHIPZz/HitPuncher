using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        
        void Init(Camera camera);
    }
}