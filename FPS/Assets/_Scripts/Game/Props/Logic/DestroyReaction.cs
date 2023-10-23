using UnityEngine;

namespace FPS.Game.Props.Logic
{
    [RequireComponent(typeof(IDestroyable))]
    public abstract class DestroyReaction : MonoBehaviour
    {
        private IDestroyable _destroyable;
        
        private void Awake()
        {
            _destroyable = GetComponent<IDestroyable>();
        }

        private void OnEnable()
        {
            _destroyable.OnDestroy += HandleDestroyReaction;
        }

        private void OnDisable()
        {
            _destroyable.OnDestroy -= HandleDestroyReaction;
        }

        protected abstract void HandleDestroyReaction();
    }
}