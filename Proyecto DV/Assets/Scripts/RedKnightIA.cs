﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKnightIA : MonoBehaviour
{

    public Animator animator;

    public SpriteRenderer SpriteRenderer;

    public float speed = 3;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 2;

    private int i = 0;

    private Vector2 actualPos;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpots[i].transform.position)<0.1f)
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
                waitTime = Time.deltaTime;
            }
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
        }
    }
}