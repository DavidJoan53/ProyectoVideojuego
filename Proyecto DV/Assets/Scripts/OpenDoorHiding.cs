using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorS : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sortingOrder = -1;
    }

}
