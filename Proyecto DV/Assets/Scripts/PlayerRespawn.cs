using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    void Start()
    {
        if(PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            gameObject.transform.GetChild(1).gameObject.transform.position = gameObject.transform.GetChild(0).gameObject.transform.position;
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        gameObject.transform.GetChild(0).gameObject.transform.position = new Vector2(x, y);
    }
}