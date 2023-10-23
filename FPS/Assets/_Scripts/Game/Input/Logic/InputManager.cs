using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using FPS.Core.Input.Logic;

namespace FPS.Game.Input.Logic
{
    public class InputManager : IInitializable, IDisposable
    {
        private Controls _controls;
        
        public Vector2 MoveAxis { get; private set; }

        public event Action OnLmbPerformed;
        public event Action OnLmbCanceled;
        public event Action OnBtn1Pressed;
        public event Action OnBtn2Pressed;
        public event Action OnBtn3Pressed;
        public event Action OnRPressed;
        public event Action OnPPressed;
        public event Action OnSpacePressed;
        public event Action OnScrollUp;
        public event Action OnScrollDown;

        public void Initialize()
        {
            _controls = new Controls();
            
            _controls.Gameplay.Lmb.performed += _ => OnLmbPerformed?.Invoke();
            _controls.Gameplay.Lmb.canceled += _ => OnLmbCanceled?.Invoke();
            _controls.Gameplay.Btn1.started += _ => OnBtn1Pressed?.Invoke();
            _controls.Gameplay.Btn2.started += _ => OnBtn2Pressed?.Invoke();
            _controls.Gameplay.Btn3.started += _ => OnBtn3Pressed?.Invoke();
            _controls.Gameplay.R.started += _ => OnRPressed?.Invoke();
            _controls.Gameplay.P.started += _ => OnPPressed?.Invoke();
            _controls.Gameplay.Space.started += _ => OnSpacePressed?.Invoke();
            _controls.Gameplay.Move.performed += x => MoveAxis = x.ReadValue<Vector2>();
            _controls.Gameplay.Move.canceled += _ =>  MoveAxis = Vector2.zero;
            _controls.Gameplay.Scroll.performed += OnMouseScroll;

            _controls.Enable();
        }

        public void Dispose()
        {
            _controls.Disable();
        }
        
        private void OnMouseScroll(InputAction.CallbackContext context)
        {
            var scrollValue = context.ReadValue<float>();

            switch (Math.Sign(scrollValue))
            {
                case 1:
                    OnScrollUp?.Invoke();
                    break;
                case -1:
                    OnScrollDown?.Invoke();
                    break;
            }
        }
    }
}