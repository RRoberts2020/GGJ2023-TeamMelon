using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private float _movingSpeed = 0f;
        [SerializeField]
        private bool _facingRight;
        [SerializeField]
        private Rigidbody2D _rb;
        [SerializeField]
        private float _startPos;
        [SerializeField]
        private float _endPos;
        [SerializeField]
        private float _patrolDistance;
        [SerializeField]
        private GameObject _enemy;

        private float _initialStartPos;


        void Start()
        {
            _startPos = _enemy.transform.position.x;
            _endPos = _enemy.transform.position.x + _patrolDistance;
            Flip();
        }


        void Update()
        {
            Debug.Log(_enemy.transform.position.x);
            MoveEnemy();
            Patrol();
        }

        private void MoveEnemy()
        {
            if (_facingRight)
            {
                _rb.velocity = new Vector2(_movingSpeed, _rb.velocity.y);
            }
            else if (!_facingRight)
            {
                _rb.velocity = new Vector2(-_movingSpeed, _rb.velocity.y);
            }
        }

        private void Patrol()
        {
            if (_facingRight && _enemy.transform.position.x >= _endPos)
            {
                //_rb.velocity = new Vector2(-_movingSpeed, _rb.velocity.y);
                Flip();
            }
            else if (!_facingRight && _enemy.transform.position.x <= _startPos)
            {
                //_rb.velocity = new Vector2(_movingSpeed, _rb.velocity.y);
                Debug.Log("Right");
                Flip();
            }
        }
        

        private void Flip()
        {
            _facingRight = !_facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;

            /*if (_facingRight && _enemy.transform.position.x >= _endPos)
            {
                Debug.Log("Left");
                _endPos = _startPos - _patrolDistance;
            }
            else if (!_facingRight && _enemy.transform.position.x >= _endPos)
            {
                Debug.Log("Right");
                _endPos = _startPos + _patrolDistance;
            } */
        }
    }
}
