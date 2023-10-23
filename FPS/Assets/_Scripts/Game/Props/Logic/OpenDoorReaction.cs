using UnityEngine;

namespace FPS.Game.Props.Logic
{
    public class OpenDoorReaction : DestroyReaction
    {
        protected override void HandleDestroyReaction()
        {
            Debug.Log("Door has been opened!");
        }
    }
}