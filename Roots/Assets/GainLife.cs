using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainLife : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerManager playerHealth;
    public AudioClip collectHeart;
    public AnimationCurve myCurve;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" & playerHealth.playerHealth != playerHealth.maxHealth)
        {
            playerHealth.playerHealth++;
            AudioSource.PlayClipAtPoint(collectHeart, transform.position);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}


