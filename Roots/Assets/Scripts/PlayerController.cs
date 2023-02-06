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

        public bool _isGrounded;
        public Transform groundCheck;

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
        }

        void Update()
        {
            rb.velocity = new Vector2(horizontal * movingSpeed, rb.velocity.y);

            if(facingRight == true && horizontal > 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Flip();
            }
            else if(facingRight == false && horizontal < 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                Flip();
            }
        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (_isGrounded)
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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            _isGrounded = colliders.Length > 1;
          
            if (_isGrounded)
            {
                _jumpCount = 0;
            }
          
        }
    }
}
