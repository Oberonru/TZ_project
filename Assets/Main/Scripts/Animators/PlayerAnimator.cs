using System;
using Main.Scripts.Animators.Logic;
using UnityEngine;

namespace Main.Scripts.Animators
{
    public class PlayerAnimator : MonoBehaviour, IAnimationStateReader
    {
        public Animator Animator;
        public AnimationType AnimationType { get; private set; }
        
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Walk = Animator.StringToHash("Walk");

        private readonly int _movingHash = Animator.StringToHash("Running");
        private readonly int _jumpHash = Animator.StringToHash("Jumping");

        private event Action<AnimationType> EnterType;
        private event Action<AnimationType> ExitType;

        private void Update()
        {
            //Animator.SetFloat(Walk, playerRb.linearVelocity.magnitude, 0.1f, Time.deltaTime);
        }

        public void PlayMoving(float speed)
        {
            Animator.SetBool(IsMoving, Mathf.Abs(speed) > 0.01f);
        }

        public void StopMoving()
        {
            Animator.SetBool(IsMoving, false);
        }

        public void PlayJump()
        {
            Animator.SetTrigger(Jump);
        }
        
        public void EnteredState(int stateHash)
        {
            AnimationType = GetType(stateHash);
            EnterType?.Invoke(AnimationType);
        }

        public void ExitedState(int stateHash)
        {
            AnimationType = GetType(stateHash);
            ExitType?.Invoke(AnimationType);
        }

        private AnimationType GetType(int hash)
        {
            AnimationType = AnimationType.Idle;
            
            if (hash == _movingHash)
            {
                AnimationType = AnimationType.Run;
            } else if (hash == _jumpHash)
            {
                AnimationType = AnimationType.Jump;
            }

            return AnimationType;
        }
    }
}