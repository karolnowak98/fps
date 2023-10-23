using System;
using UnityEngine;

namespace FPS.Game.Player.Data
{
    [Serializable]
    public struct CameraData
    {
        [Header("Sensitivity")]
        [SerializeField, Tooltip("The horizontal sensitivity of the camera.")]
        private float _xSens;

        [SerializeField, Tooltip("The vertical sensitivity of the camera.")]
        private float _ySens;

        [Header("Angle Constraints")]
        [SerializeField, Tooltip("The minimum angle in the y-axis.")]
        private float _minYAngle;

        [SerializeField, Tooltip("The maximum angle in the y-axis.")]
        private float _maxYAngle;

        public float XSens => _xSens;
        public float YSens => _ySens;
        public float MinYAngle => _minYAngle;
        public float MaxYAngle => _maxYAngle;
    }
}