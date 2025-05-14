using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Player
{
    public class AnimationHandler : MonoBehaviour
    {
        public event Action StartJump;
        public event Action EndtJump;

        private void OnJump()
        {
            StartJump?.Invoke();
        }

        private void OffJump()
        {
            EndtJump?.Invoke();
        }
    }
}