using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraProvider: ICameraProvider
    {
        public Camera MainCamera { get; private set; }

        public void Init(Camera camera)
        {
            MainCamera = camera;
        }
        
    }
}