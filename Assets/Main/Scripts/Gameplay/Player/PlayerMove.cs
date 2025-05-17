using Main.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Main.Scripts.Gameplay.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed = 5f;
        public float jumpHeight = 2f;
        public float gravity = -9.81f;
        private float _verticalVelocity = 0f;
        private CharacterController _characterController;
        private bool _isGround;
        private Vector3 _move;
        private IInputService _inputService;
        private float _horizontal;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void FixedUpdate()
        {
            _isGround = CheckGround();
        }

        private void Update()
        {
            _horizontal = _inputService.Axis().x;
            
            _move = new Vector3(_horizontal, 0, 0) * speed;

            RevertToSpeedDirection();

            if (_isGround)
            {
                if (_inputService.Jump())
                    _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
                else
                    _verticalVelocity = -1f;
            }
            else
            {
                _verticalVelocity += gravity * Time.deltaTime;
            }

            _move.y = _verticalVelocity;

            _characterController.Move(_move * Time.deltaTime);
        }

        private void Rotate(int angle)
        {
            var eulerAngle = Quaternion.Euler(0, angle, 0);
            transform.rotation = eulerAngle;
        }

        private void RevertToSpeedDirection()
        {
            switch (_horizontal)
            {
                case < 0:
                    Rotate(-90);
                    break;
                case > 0:
                    Rotate(90);
                    break;
            }
        }

        private bool CheckGround()
        {
            return _characterController.isGrounded;
        }
    }
}