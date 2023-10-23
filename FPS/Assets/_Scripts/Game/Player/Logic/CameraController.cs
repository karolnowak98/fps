using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using FPS.Game.Player.Data;

namespace FPS.Game.Player.Logic
{
    public class CameraController : ITickable, IInitializable
    {
        private CameraData _data;
        private Transform _holder;
        private Transform _playerCameraPos;
        private Transform _playerOrientation;
        private float _xRotation;
        private float _yRotation;

        [Inject]
        private void Construct(CameraData data, Transform transform, Transform playerCameraPos, Transform playerOrientation)
        {
            _data = data;
            _holder = transform;
            _playerCameraPos = playerCameraPos;
            _playerOrientation = playerOrientation;
        }
        
        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        public void Tick()
        {
            CalculateRotation();
            UpdateCameraTransform();
        }

        private void CalculateRotation()
        {
            var mouseDelta = Mouse.current.delta.ReadValue();
            var mouseX = mouseDelta.x * Time.deltaTime * _data.XSens;
            var mouseY = mouseDelta.y * Time.deltaTime * _data.YSens;
            
            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, _data.MinYAngle, _data.MaxYAngle);
        }

        private void UpdateCameraTransform()
        {
            _holder.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _playerOrientation.rotation = Quaternion.Euler(0, _yRotation, 0);
            _holder.position = _playerCameraPos.position;
        }
    }
}