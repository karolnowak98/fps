using System.Collections.Generic;
using UnityEngine;
using FPS.Core.Data;
using FPS.Game.Props.Enums;
using FPS.Game.Weapons.Enums;

namespace FPS.Game.Weapons.Data
{
    [CreateAssetMenu(menuName = "Entities/Weapon Entity", fileName = "Weapon Entity")]
    public class WeaponEntity : Entity
    {
        [Header("General Settings")]
        [SerializeField, Tooltip("The type of the weapon.")]
        private WeaponType _type;

        [SerializeField, Tooltip("The prefab representing the weapon.")]
        private GameObject _prefab;

        [SerializeField, Tooltip("The icon of the weapon.")]
        private Sprite _icon;

        [SerializeField, Tooltip("The icon representing the ammo for this weapon.")]
        private Sprite _ammoIcon;

        [Header("Visuals")]
        [SerializeField, Tooltip("The particle system for bullet impact.")]
        private ParticleSystem _bulletImpactParticle;

        [Header("Combat")]
        [SerializeField, Tooltip("The base damage dealt by the weapon.")]
        private int _damage;

        [SerializeField, Tooltip("List of materials that the weapon can destroy.")]
        private List<PropMaterialType> _destroyMaterials;

        [Header("Shooting")]
        [SerializeField, Tooltip("Cooldown between shots.")]
        private float _shootCooldown;

        [SerializeField, Tooltip("Maximum range of the weapon.")]
        private float _range;

        [SerializeField, Tooltip("Is the weapon capable of rapid fire?")]
        private bool _isRapidFire;
        
        [SerializeField, Tooltip("Number of magazines the weapon starts with.")]
        private int _numberOfMagazines;

        [SerializeField, Tooltip("Number of bullets in a magazine.")]
        private int _numberOfBulletsInMagazine;
        
        [SerializeField, Tooltip("Time it takes to reload the weapon.")]
        private float _reloadTime;

        public WeaponType Type => _type;
        public GameObject Prefab => _prefab;
        public Sprite Icon => _icon;
        public Sprite AmmoIcon => _ammoIcon;
        public ParticleSystem BulletImpactParticle => _bulletImpactParticle;
        public int NumberOfMagazines => _numberOfMagazines;
        public int NumberOfBulletsInMagazine => _numberOfBulletsInMagazine;
        public int Damage => _damage;
        public List<PropMaterialType> DestroyMaterials => _destroyMaterials;
        public float ReloadTime => _reloadTime;
        public float ShootCooldown => _shootCooldown;
        public float Range => _range;
        public bool IsRapidFire => _isRapidFire;
    }
}
