using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 

public class SpikesScript : MonoBehaviour
{
    public Text youDie;

    public AudioSource clip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            clip.Play();
            youDie.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
    }
}
