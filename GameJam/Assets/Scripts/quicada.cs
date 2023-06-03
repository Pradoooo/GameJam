using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quicada : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chão")
        {
            gameObject.SetActive(false);
            
        }
    }
}
