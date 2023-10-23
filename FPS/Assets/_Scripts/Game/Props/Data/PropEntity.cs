using FPS.Core.Data;
using FPS.Game.Props.Enums;
using UnityEngine;

namespace FPS.Game.Props.Data
{
    [CreateAssetMenu(menuName = "Entities/Prop Entity", fileName = "Prop Entity")]
    public class PropEntity : Entity
    {
        [SerializeField] private PropMaterialType _materialType;
        [SerializeField] private int _durability;

        public PropMaterialType MaterialType => _materialType;
        public int Durability => _durability;
    }
}