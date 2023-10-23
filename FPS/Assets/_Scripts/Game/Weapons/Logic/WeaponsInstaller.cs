using FPS.Game.Weapons.Data;
using UnityEngine;
using Zenject;

namespace FPS.Game.Weapons.Logic
{
    public class WeaponsInstaller : MonoInstaller
    {
        [SerializeField] private WeaponsConfig _config;
        [SerializeField] private WeaponSlotData[] _weaponSlots;
            
        public override void InstallBindings()
        {
            Container.BindInstance(_config);
            
            Container.Bind<WeaponManager>().AsSingle().WithArguments(_weaponSlots).NonLazy();
            Container.Bind<ShootingController>().AsSingle().NonLazy();
            
            Container.Bind<ITickable>().To<WeaponManager>().FromResolve();
            Container.Bind<ITickable>().To<ShootingController>().FromResolve();
        }
    }
}