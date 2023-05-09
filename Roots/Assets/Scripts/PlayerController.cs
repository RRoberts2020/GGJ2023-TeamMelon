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

        [Header("Visuals")]
        public float movingFPS = 10f;
        [SerializeField] private float _idleFPS = 0f;
        private MeshRenderer _mr;
        private Material _walkingMaterial;
        [SerializeField] private Material _attackingMaterial;

        public Rigidbody2D rb;

        public AudioSource _jumpSound;
        public AudioSource _walkSound;

        public AudioSource _landSound;

        private WaitForSeconds _cachedWaitForSeconds;


        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            _mr = GetComponent<MeshRenderer>();
            _walkingMaterial = _mr.material;

            // Cursed things here but this allows the attack material to be initialised properly
            _mr.material = _attackingMaterial;
            _attackingMaterial = _mr.material;

            _mr.material = _walkingMaterial;

            RandomiseMaterialAttributes();

            _cachedWaitForSeconds = new WaitForSeconds(0.33f);
        }

        #region [Randomise Character Appearance]
        public void RandomiseMaterialAttributes()
        {
            // Hats
            int hatRandomiser = Random.Range(0, 3);

            int wearHat = hatRandomiser == 1 ? 1 : 0;
            int wearBeanie = hatRandomiser == 2 ? 1 : 0;
            Color hatColour = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            // Hair
            int longHair = Random.Range(0, 2);

            Color hairColour = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            // Glasses
            int glasses = Random.Range(0, 2);

            Color glassesColour = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);

            // Earrings
            int earrings = Random.Range(0, 2);

            Color earringsColour = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);


            // Set values

            // Hats
            _walkingMaterial.SetFloat("_Wear_Hat", wearHat);
            _attackingMaterial.SetFloat("_Wear_Hat", wearHat);
            _walkingMaterial.SetColor("_Hat_Colour_Tint", hatColour);
            _attackingMaterial.SetColor("_Hat_Colour_Tint", hatColour);

            _walkingMaterial.SetFloat("_Wear_Beanie", wearBeanie);
            _attackingMaterial.SetFloat("_Wear_Beanie", wearBeanie);
            _walkingMaterial.SetColor("_Beanie_Colour_Tint", hatColour);
            _attackingMaterial.SetColor("_Beanie_Colour_Tint", hatColour);

            
            // Hair
            _walkingMaterial.SetFloat("_Long_Hair", longHair);
            _attackingMaterial.SetFloat("_Long_Hair", longHair);
            _walkingMaterial.SetColor("_Hair_Colour_Tint", hairColour);
            _attackingMaterial.SetColor("_Hair_Colour_Tint", hairColour);

            // Glasses
            _walkingMaterial.SetFloat("_Wear_Glasses", glasses);
            _attackingMaterial.SetFloat("_Wear_Glasses", glasses);
            _walkingMaterial.SetColor("_Glasses_Colour_Tint", glassesColour);
            _attackingMaterial.SetColor("_Glasses_Colour_Tint", glassesColour);

            // Earrings
            _walkingMaterial.SetFloat("_Wear_Earrings", earrings);
            _attackingMaterial.SetFloat("_Wear_Earrings", earrings);
            _walkingMaterial.SetColor("_Earring_Colour_Tint", earringsColour);
            _attackingMaterial.SetColor("_Earring_Colour_Tint", earringsColour);
        }
        #endregion // Randomise Character Appearance

        private void FixedUpdate()
        {
            CheckGround();

            rb.velocity = new Vector2(horizontal * movingSpeed, rb.velocity.y);

            if (horizontal == 0 || !isGrounded)
            {
                _walkingMaterial.SetFloat("_FPS", _idleFPS);
            }

            else
            {
                _walkingMaterial.SetFloat("_FPS", movingFPS);
            }

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

        public IEnumerator PlayAttackAnimation()
        {
            _mr.material = _attackingMaterial;
            yield return _cachedWaitForSeconds;
            _mr.material = _walkingMaterial;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - _groundCheckDistance, transform.position.z));
        }
    }
}
