using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody _rb;

        private void Start()
        {
            
        }

        // public float jumpHeight = 2.0f;
        // public float speed = 1;
        // private CharacterController _controller;
        // private Vector3 _velocity;
        // private float _gravity = -9.81f;
        // private float _verticalVelocity = 0;
        //
        //
        // private void Start()
        // {
        //     _controller = GetComponent<CharacterController>();
        // }
        //
        // private void Update()
        // {
        //     float horizontal = Input.GetAxis("Horizontal");
        //
        //     Vector3 move = new Vector3(0, 0, horizontal);
        //     move = transform.TransformDirection(move);
        //
        //     _controller.Move(move * (speed * Time.deltaTime));
        //     if (!_controller.isGrounded)
        //     {
        //         _verticalVelocity += _gravity * Time.deltaTime;
        //     }
        //     else if(_verticalVelocity < 0)
        //     {
        //         _verticalVelocity = 0;
        //     }
        //
        //     move.y = _verticalVelocity;
        //     
        //     if (CanJump())
        //     {
        //         print("can jump");
        //         Jump();
        //     }
        // }
        //
        // private void Jump()
        // {
        //     _velocity.y = Mathf.Sqrt(jumpHeight * -2f * _gravity);
        // }
        //
        // private bool CanJump()
        // {
        //     return Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded;
        // }
    }
}