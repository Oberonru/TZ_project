using System;
using UnityEngine;

namespace Main.Scripts.Gameplay.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float jumpForce = 1;
        public float speed = 1;
        public float friction = 1;
        private Rigidbody _rb;
        private float _horizontal;
        private bool _isGround;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Update()
        {
            _horizontal = Input.GetAxis("Horizontal");

            if (_horizontal < 0)
            {
                Rotate(180);
            }
            else if (_horizontal > 0)
            {
                Rotate(0);
            }

            if (CanJumping())
            {
                Jump();
            }
        }

        private bool CanJumping()
        {
            return Input.GetKey(KeyCode.Space) && _isGround;
        }

        private void Jump()
        {
            _rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        private void Move()
        {
            _rb.AddForce(_horizontal * speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            _rb.AddForce(-_rb.linearVelocity.x * friction, 0, 0, ForceMode.VelocityChange);
        }

        private void Rotate(int angle)
        {
            var eulerAngle = Quaternion.Euler(0, angle, 0);
            transform.rotation = eulerAngle;
        }

        private void OnCollisionStay(Collision other)
        {
            float angle = Vector3.Angle(other.contacts[0].point, Vector3.up);
            _isGround = angle < 45;
        }

        private void OnCollisionExit(Collision other)
        {
            _isGround = false;
        }
    }
}