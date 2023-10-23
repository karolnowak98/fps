using System;
using FPS.Game.Props.Enums;

namespace FPS.Game.Props.Logic
{
    public interface IDestroyable
    {
        public PropMaterialType MaterialType { get; }
        public event Action OnDestroy;
        public void TakeDamage(int damage);
    }
}