using System;
using FPS.Game.Weapons.Data;

namespace FPS.Game.Weapons.Logic.Interfaces
{
    public interface IWeapon
    {
        public WeaponEntity WeaponEntity { get; }
        public int TotalAmmo { get; }
        public int AmmoInMagazine { get; set; }
        public bool IsReloading { get; set; }
        public event Action OnReloadStart;
        public event Action<float> OnReloadProgressChanged;
        public void StartReload();
        public void StopReload();
        public void Tick();
    }
}