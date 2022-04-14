using System;
using Cinemachine;
using My_Assets.Scrips.Utyles_Module;
using UnityEngine;

namespace My_Assets.Scrips.Camera_Module
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
        [SerializeField] private CinemachineVirtualCamera faceCamera;

        private void Awake()
        {
            InitializeMonoSingleton();
        }

        public void OnStartGame()
        {
            faceCamera.Priority = 9;
        }
        
        public void OnEndGame()
        {
            faceCamera.Priority = 11;
        }
    }
}