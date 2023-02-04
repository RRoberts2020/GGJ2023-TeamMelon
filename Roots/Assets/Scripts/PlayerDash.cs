using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


        void Start()
        {
            _dashDuration = _initialDuration;
            _dashCooldown = _initialCooldown;

        }

        void Update()
        {
            Dash();
        }

        public void Dash()
        {
            if (_dashCooldown == _initialCooldown)
            {
                if (_dashDuration != 0f && Input.GetKeyDown(KeyCode.LeftShift))
                {
                    _dashDuration -= Time.deltaTime;
                    _dashing = true;

                    if (playerController.facingRight == true && Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        playerController.rb.velocity = Vector2.right * _dashSpeed;
                        _dashCooldown -= Time.deltaTime;
                    }
                    else if (playerController.facingRight != true && Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        playerController.rb.velocity = Vector2.left * _dashSpeed;
                        _dashCooldown -= Time.deltaTime;
                    }
                }
            }
            else if (_dashCooldown != _initialCooldown)
            {  
                _dashCooldown -= Time.deltaTime;

                if (_dashing)
                {
                    _dashDuration -= Time.deltaTime;
                }

                if (_dashDuration < 0f)
                {
                    _dashing = false;
                    playerController.rb.velocity = Vector2.zero;
                    _dashDuration = _initialDuration;
                }

                if (_dashCooldown <= 0f)
                {
                    _dashCooldown = _initialCooldown;
                }       
            }
        }
    }
}
    
