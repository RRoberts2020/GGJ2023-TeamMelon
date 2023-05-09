using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class AbilityManager : MonoBehaviour
    {
        public PlayerController playerController;
        public Checkpoint checkpoint;

        public void ChoiceOne()
        {
            playerController.rb.constraints = RigidbodyConstraints2D.None;
            playerController.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            playerController.movingSpeed = playerController.movingSpeed + 4;
            playerController.movingFPS = 16f;

            checkpoint.endGamePanel.SetActive(false);
            Destroy(checkpoint._checkPoint);
        }

        public void ChoiceTwo()
        {
            playerController.rb.constraints = RigidbodyConstraints2D.None;
            playerController.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            playerController.initialJumpCount++;
            checkpoint.endGamePanel.SetActive(false);
            Destroy(checkpoint._checkPoint);
        }
    }
}

