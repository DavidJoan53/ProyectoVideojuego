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
            //EJECUTO LA MUERTE
            clip.Play();
            youDie.gameObject.SetActive(true);
            //INICIO EL RESPAWN
            Invoke("HideMessage", 1.5f);
            //collision.gameObject.GetComponent<PlayerMove>().setState(0);
            collision.gameObject.transform.position = collision.gameObject.transform.parent.transform.GetChild(0).gameObject.transform.position;
            
        }
    }

    void HideMessage()
    {
        youDie.gameObject.SetActive(false);
    }
}
