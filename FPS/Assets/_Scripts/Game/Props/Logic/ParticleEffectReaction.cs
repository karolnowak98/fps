using UnityEngine;

namespace FPS.Game.Props.Logic
{
    public class ParticleEffectReaction : DestroyReaction
    {
        [SerializeField] private ParticleSystem _particle;
        
        protected override void HandleDestroyReaction()
        {
            var obj = Instantiate(_particle, transform.position, _particle.transform.rotation);
            obj.Play();
            Destroy(obj, _particle.main.duration);
        }
    }
}