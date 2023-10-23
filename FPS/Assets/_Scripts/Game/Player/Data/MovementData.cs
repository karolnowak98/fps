using System;
using UnityEngine;

namespace FPS.Game.Player.Data
{
    [Serializable]
    public struct MovementData
    {
        [Header("Movement Speed")]
        [SerializeField, Tooltip("The base movement speed of the player.")]
        private float _moveSpeed;

        [SerializeField, Tooltip("The maximum movement speed of the player.")]
        private float _maxMoveSpeed;

        [SerializeField, Tooltip("The height of the player character.")]
        private float _playerHeight;
        
        [Header("Jumping")]
        [SerializeField, Tooltip("The force applied when jumping.")]
        private float _jumpForce;

        [SerializeField, Tooltip("The cooldown time between jumps.")]
        private float _jumpCooldown;

        [SerializeField, Tooltip("Multiplier applied to movement while in the air.")]
        private float _airMultiplier;

        [Header("Other Properties")]
        [SerializeField, Tooltip("The drag force applied to the player.")]
        private float _dragForce;

        [SerializeField, Tooltip("Layer mask used to detect the ground.")]
        private LayerMask _groundMask;

        public float MoveSpeed => _moveSpeed;
        public float MaxMoveSpeed => _maxMoveSpeed;
        public float PlayerHeight => _playerHeight;
        public float JumpForce => _jumpForce;
        public float JumpCooldown => _jumpCooldown;
        public float AirMultiplier => _airMultiplier;
        public float DragForce => _dragForce;
        public LayerMask GroundMask => _groundMask;
    }
}