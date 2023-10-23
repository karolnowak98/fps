using FPS.Core.Data;
using FPS.Game.Weapons.Enums;
using UnityEngine;

namespace FPS.Game.Weapons.Data
{
    [CreateAssetMenu(menuName = "Configs/Weapons Config", fileName = "Weapons Config")]
    public class WeaponsConfig : Config
    {
        [SerializeField] private WeaponType _startingSlot;
        [SerializeField] private WeaponEntity[] _startingWeapons; //Using Odin I would make Dictionary<WeaponType, WeaponEntity> instead
        
        public WeaponType StartingSlot => _startingSlot;
        public WeaponEntity[] StartingWeapons => _startingWeapons;
    }
}