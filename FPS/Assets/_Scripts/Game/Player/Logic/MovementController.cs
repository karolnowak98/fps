using UnityEngine;
using Zenject;
using FPS.Core.Input.Logic;
using FPS.Game.Input.Logic;
using FPS.Game.Player.Data;

namespace FPS.Game.Player.Logic
{
    public class MovementController : IInitializable, ITickable, IFixedTickable
    {
        private InputManager _inputManager;
        private MovementData _movementData;
        private Rigidbody _rb;
        private Transform _orientation;
        private Transform _player;

        private Vector3 _moveDirection;
        private bool _isGrounded;
        private bool _canJump;
        private float _nextJumpTime;

        [Inject]
        private void Construct(InputManager inputManager, MovementData data, Transform orientation, Transform playerTransform, Rigidbody rb)
        {
            _inputManager = inputManager;
            _movementData = data;
            _orientation = orientation;
            _player = playerTransform;
            _rb = rb;

            _inputManager.OnSpacePressed += Jump;
        }

        public void Initialize()
        {
            _rb.freezeRotation = true;
        }

        public void Tick()
        {
            GetInput();
            AddDragForce();
            LimitMoveSpeed();
            CalculateAirCooldown();
        }

        public void FixedTick()
        {
            AddMoveForce();
        }

        private void GetInput()
        {
            _moveDirection = _orientation.forward * _inputManager.MoveAxis.y + _orientation.right * _inputManager.MoveAxis.x;
        }

        private void AddDragForce()
        {
            _isGrounded = Physics.Raycast(_orientation.position, Vector3.down, _movementData.PlayerHeight * 0.5f, _movementData.GroundMask);
            _rb.drag = _isGrounded ? _movementData.DragForce : 0;
        }

        private void LimitMoveSpeed()
        {
            var velocity = _rb.velocity;
            var flatVel = new Vector3(velocity.x, 0f, velocity.z);

            if (flatVel.magnitude > _movementData.MaxMoveSpeed)
            {
                var limitedVel = flatVel.normalized * _movementData.MaxMoveSpeed;
                _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
            }
        }

        private void CalculateAirCooldown()
        {
            if (!_canJump && Time.time > _nextJumpTime)
            {
                _canJump = true;
            }
        }

        private void AddMoveForce()
        {
            var moveSpeed = _isGrounded ? _movementData.MoveSpeed : _movementData.MoveSpeed * _movementData.AirMultiplier;
            _rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Force);
        }

        private void Jump()
        {
            if (_canJump && _isGrounded)
            {
                _canJump = false;
                
                var velocity = _rb.velocity;
                velocity = new Vector3(velocity.x, 0f, velocity.z);
                
                _rb.velocity = velocity;
                _rb.AddForce(_player.up * _movementData.JumpForce, ForceMode.Impulse);
                _nextJumpTime = Time.time + _movementData.JumpCooldown;
            }
        }
    }
}
