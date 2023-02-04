using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _enemyRB;

        public int patrolDistance = 0;
        public float enemySpeed = 0f;
        public bool isFacingRight;

        private float _startPos;
        private float _endPos;

        public bool moveRight = true;

        public void Awake()
        {
            _enemyRB = GetComponent<Rigidbody2D>();
            _startPos = transform.position.x;
            _endPos = _startPos + patrolDistance;
            isFacingRight = transform.localScale.x > 0;
        }

        public void Update()
        {
            if (moveRight)
            {
                _enemyRB.AddForce(Vector2.right * enemySpeed * Time.deltaTime);
                if (!isFacingRight)
                    Flip();
            }

            if (_enemyRB.position.x >= _endPos)
                moveRight = false;

            if (!moveRight)
            {
                _enemyRB.AddForce(-Vector2.right * enemySpeed * Time.deltaTime);
                if (isFacingRight)
                    Flip();
            }
            if (_enemyRB.position.x <= _startPos)
                moveRight = true;
        }

        public void Flip()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = transform.localScale.x > 0;
        }
    }
}
