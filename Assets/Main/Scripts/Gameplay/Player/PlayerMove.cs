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
        private float _horizontal;
        private bool _isGroung;
        private Vector3 _move;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            _isGroung = CheckGround();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");
             _move = new Vector3(_horizontal, 0, 0) * speed;

            RevertToSpeedDirection();
           
            if (_isGroung)
            {
                if (Input.GetButtonDown("Jump"))
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
            if (_horizontal < 0)
            {
                Rotate(-90);
            }
            else if (_horizontal > 0)
            {
                Rotate(90);
            }
        }

        private bool CheckGround()
        {
            return _characterController.isGrounded;
        }


        //     public PlayerAnimator animator;
        //     public AnimationHandler animationHandler;
        //     
        //     [SerializeField] private float speed = 1f;
        //     [SerializeField] private float turnSpeed = 200f;
        //     [SerializeField] private float jumpSpeed = 1f;
        //     [SerializeField] private float gravity = 10f;
        //     
        //     private CharacterController _characterController;
        //     private Vector3 _moveVelocity;
        //     private Vector3 _turnVelocity;
        //     private float _horizontal;
        //     private float _vertical;
        //     
        //     private bool _isGround;
        //     
        //     private void Start()
        //     {
        //         _characterController = GetComponent<CharacterController>();
        //     }
        //     
        //     private void FixedUpdate()
        //     {
        //         _isGround = CheckGround();
        //     }
        //     
        //     private void Update()
        //     {
        //         RevertToSpeedDirection();
        //         
        //         _horizontal = Input.GetAxis("Horizontal");
        //     
        //         _moveVelocity = transform.forward * (speed * _horizontal);
        //         
        //         if (_isGround)
        //         {
        //             if (Input.GetButton("Jump"))
        //             {
        //                 _moveVelocity.y = jumpSpeed;
        //             }
        //         }
        //
        //         _moveVelocity.y -= gravity * Time.deltaTime;
        //         _characterController.Move(_moveVelocity * Time.deltaTime);
        //     }
        //     
        //     private void Move()
        //     {
        //     }
        //     
        //     private bool CanJumping()
        //     {
        //         return Input.GetKey(KeyCode.Space);
        //     }
        //     
        //     private void Jump()
        //     {
        //     }
        //     
        //     private void OnJump()
        //     {
        //     }
        //     
        //     private void OffJump()
        //     {
        //     }
        //     
        //     
        //     private void Rotate(int angle)
        //     {
        //         var eulerAngle = Quaternion.Euler(0, angle, 0);
        //         transform.rotation = eulerAngle;
        //     }
        //     
        //     private void RevertToSpeedDirection()
        //     {
        //         if (_horizontal < 0)
        //         {
        //             Rotate(-90);
        //         }
        //         else if (_horizontal > 0)
        //         {
        //             Rotate(90);
        //         }
        //     }
        //     
        //     private bool CheckGround()
        //     {
        //         return _characterController.isGrounded;
        //     }
        
    }
}