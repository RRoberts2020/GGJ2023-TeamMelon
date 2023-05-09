using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float _moveInput;

        private float horizontal;

        [SerializeField]
        private int _jumpCount = 0;
        public int initialJumpCount = 0;

        public bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;
   
        [Header("Ground Checks")]
        public bool isGrounded;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.7f;
        [Space]

        public Rigidbody2D rb;
        private Animator _animator;
        private GameManager _gameManager;

        public AudioSource _jumpSound;
        public AudioSource _walkSound;

        public AudioSource _landSound;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CheckGround();

            rb.velocity = new Vector2(horizontal * movingSpeed, rb.velocity.y);

            if (facingRight == true && horizontal > 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Flip();
            }
            else if (facingRight == false && horizontal < 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Flip();
            }
        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (isGrounded)
                {
                    _walkSound.Play();
                }
                horizontal = context.ReadValue<Vector2>().x;
            }
            else if (context.canceled)
            {
                _walkSound.Stop();
                horizontal = 0;
            }
        }

        public void JumpPlayer(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _walkSound.Stop();
                if (_jumpCount < initialJumpCount)
                {                   
                    _jumpCount++;
                    rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                }
            }

            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _groundLayer);

            if (isGrounded)
            {
                _jumpCount = 0;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - _groundCheckDistance, transform.position.z));
        }
    }
}
