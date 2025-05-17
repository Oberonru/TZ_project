using UnityEngine;
using UnityEngine.InputSystem;

namespace Main.Scripts.Infrastructure.Services.InputService
{
    public class InputService : MonoBehaviour, IInputService
    {
        public PlayerInput playerInput;
        
        public Vector2 Axis()
        {
            return playerInput.actions["Move"].ReadValue<Vector2>();
        }

        public bool Jump()
        {
            return playerInput.actions["Jump"].IsPressed();
        }
    }
}