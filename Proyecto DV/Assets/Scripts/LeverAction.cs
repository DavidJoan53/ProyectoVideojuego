using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    public AudioSource clip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //EJECUCIÓN DEL CLIP DE SONIDO
            if(gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                clip.Play();
                Debug.Log("The mechanism has moved");
            }
            //ANIMACIÓN DEL SPRITE
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //Destroy(gameObject, 1f);
        }
    }
}
