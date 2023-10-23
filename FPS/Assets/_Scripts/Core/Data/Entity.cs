using UnityEngine;

namespace FPS.Core.Data
{
    public class Entity : ScriptableObject
    {
        [SerializeField] protected int _id;

        public int ID => _id;
    }
}