using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class SpikesScript : MonoBehaviour
{
    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            clip.Play();
            Debug.Log("Player Destroyed");
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(collision.gameObject);
        }
    }
}
