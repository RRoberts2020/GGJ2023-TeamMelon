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
            playerController.movingSpeed = playerController.movingSpeed + 4;
            checkpoint.endGamePanel.SetActive(false);
            playerController.rb.constraints = RigidbodyConstraints2D.None;
            Destroy(checkpoint._checkPoint);
        }

        public void ChoiceTwo()
        {
            playerController.initialJumpCount++;
            checkpoint.endGamePanel.SetActive(false);
            playerController.rb.constraints = RigidbodyConstraints2D.None;
            Destroy(checkpoint._checkPoint);
        }
    }
}

