using System;
using FPS.Game.Weapons.Enums;
using UnityEngine;

namespace FPS.Game.Weapons.Data
{
    [Serializable]
    public struct WeaponSlotData
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private WeaponType _type;

        public Transform Transform => _transform;
        public WeaponType Type => _type;
    }
}