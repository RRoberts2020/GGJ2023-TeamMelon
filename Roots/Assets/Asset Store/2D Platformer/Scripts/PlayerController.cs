using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float _moveInput;

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
            if (Input.GetButton("Horizontal")) 
            {
                _moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * _moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            }

            if(Input.GetKeyDown(KeyCode.Space) && _isGrounded )
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }

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
        }

        /*private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }
        }*/
    }
}
