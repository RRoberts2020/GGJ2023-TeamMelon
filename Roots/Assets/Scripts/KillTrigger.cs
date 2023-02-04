using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    public PlayerManager playerManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameObject.Destroy(collision.gameObject);
    }
}
