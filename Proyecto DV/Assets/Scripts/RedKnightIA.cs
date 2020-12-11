using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 

public class RedKnightIA : MonoBehaviour
{
    public Text youDie;

    public AudioSource clip;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public float speed = 4.5f;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 1.5f;

    private int i = 0;

    private Vector2 actualPos;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position=Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        
        if(Vector2.Distance(transform.position, moveSpots[i].transform.position)<0.2f)
        {
            if(waitTime<=0)
            {
                if(moveSpots[i]!=moveSpots[moveSpots.Length-1])
                {
                    i++;
                }
                else {
                    i=0;
                }

                waitTime = startWaitTime;
            } 
            else {
                waitTime -= Time.deltaTime;
            }
        }

        IEnumerator CheckEnemyMoving()
        {
            actualPos=transform.position;

            yield return new WaitForSeconds(0.5f);

            if(transform.position.x > actualPos.x)
            {
                spriteRenderer.flipX = false;
            } else
            if(transform.position.x < actualPos.x)
            {
                spriteRenderer.flipX = true;
            }
        }
    
    }

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
