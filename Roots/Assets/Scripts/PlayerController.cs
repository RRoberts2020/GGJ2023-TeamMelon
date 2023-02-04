using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        [SerializeField]
        private int _initialJumpCount = 0;

        public bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool _isGrounded;
        public Transform groundCheck;

        public Rigidbody2D rb;
        private Animator _animator;
        private GameManager _gameManager;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            /*animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();*/
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            rb.velocity = new Vector2(horizontal * movingSpeed, rb.velocity.y);

            if(facingRight == false && _moveInput > 0)
            {
                rb.velocity = Vector2.zero;
                Flip();
            }
            else if(facingRight == true && _moveInput < 0)
            {
                rb.velocity = Vector2.zero;
                Flip();
            }
        }

        public void MovePlayer(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }

        public void JumpPlayer(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (_jumpCount < _initialJumpCount)
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
                _jumpCount = 0;
        }
    }
}
