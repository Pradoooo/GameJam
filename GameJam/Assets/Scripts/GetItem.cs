using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private CircleCollider2D circle;
    private SpriteRenderer sr;

    public int leite;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;


            GameManager.instance.totalLeite += leite;
            GameManager.instance.UpdateLeiteText();

            Destroy(gameObject, 0.25f);
        }
    }
}