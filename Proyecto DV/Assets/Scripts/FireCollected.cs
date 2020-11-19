using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //ESTABLECIMIENTO DEL CHECKPOINT
            collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
            //ANIMACIÓN DEL SPRITE
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Invoke("DisableAnimation", 1);
            //Destroy(gameObject, 1f);
        }
    }

    void DisableAnimation() {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
