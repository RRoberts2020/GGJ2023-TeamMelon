using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class PlayerDash : MonoBehaviour
    {
        public PlayerController playerController;

        [SerializeField]
        private float _dashSpeed = 0f;
        [SerializeField]
        private float _dashDuration = 0f;
        [SerializeField]
        private float _initialDuration = 0f;
        [SerializeField]
        private float _dashCooldown = 0f;
        [SerializeField]
        private float _initialCooldown = 0f;

        private bool _dashing = false;
        private float _horizontalDash;

        void Start()
        {
            _dashDuration = _initialDuration;
            _dashCooldown = _initialCooldown;
        }
        public void Dash(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                _dashing = true;
                if(playerController.facingRight)
                {
                    playerController.rb.velocity = Vector2.right * _dashSpeed;
                }
                else if (!playerController.facingRight)
                {    

                }
            }
        }
    }
}
    
