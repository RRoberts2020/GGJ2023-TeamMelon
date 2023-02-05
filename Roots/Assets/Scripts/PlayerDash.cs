using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class PlayerDash : MonoBehaviour
    {
        public PlayerController playerController;

        [SerializeField] private bool _ableToDash = true;
        [SerializeField] private bool _doDash = false;
        [SerializeField] private float _dashSpeed = 0f;
        [SerializeField] private float _dashDuration = 0f;
        [SerializeField] private float _initialDuration = 0f;
        [SerializeField] private float _dashCooldown = 0f;
        [SerializeField] private float _initialCooldown = 0f;

        private float _normalGravity;
        private float _waitTime;

        private void Awake()
        {
            _normalGravity = playerController.rb.gravityScale;
            _ableToDash = true;
            _dashDuration = _initialDuration;
        }

        private void Update()
        {
            /*if(_doDash)
            {
                return;
            }*/
        }

        public void Dash(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                StartCoroutine(Dash());
            }
        }

        IEnumerator Dash()
        {
            _ableToDash = false;
            _doDash = true;
            playerController.rb.AddForce(-transform.right * (_dashSpeed * 100));
            yield return new WaitForSeconds(_dashDuration);
            _doDash = false;
            yield return new WaitForSeconds(_dashCooldown);
            _ableToDash = true;
        }
    }
}

    
