using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Checkpoint : MonoBehaviour
    {
        public GameObject endGamePanel;
        public PlayerController playerController;
        private LevelManager levelManager;

        private bool _makingChoice;
        public GameObject _checkPoint;

        public  SpriteRenderer spriteRenderer;
        public Sprite treeSprite;

        void Start()
        {
            endGamePanel.SetActive(false);
            levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            _makingChoice = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Trigger");


                spriteRenderer.sprite = treeSprite;

                _makingChoice = true;
                Decision();
            }
        }

        private void Decision()
        {
            if (_makingChoice)
            {
                if (playerController._isGrounded)
                    playerController.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                endGamePanel.SetActive(true);
                Debug.Log("In trigger");
                levelManager.lastPlayerPos = transform.position;
            }
        }
    }
}

