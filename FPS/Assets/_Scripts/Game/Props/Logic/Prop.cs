using System;
using FPS.Game.Props.Data;
using UnityEngine;
using FPS.Game.Props.Enums;

namespace FPS.Game.Props.Logic
{
    public class Prop : MonoBehaviour, IDestroyable
    {
        [SerializeField] private PropEntity _data;
        
        private int _currentDurability;

        public PropMaterialType MaterialType => _data.MaterialType;

        public event Action OnDestroy;

        private void Awake()
        {
            _currentDurability = _data.Durability;
        }
        
        public void TakeDamage(int damage)
        {
            _currentDurability -= damage;

            if (_currentDurability <= 0)
            {
                OnDestroy?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}