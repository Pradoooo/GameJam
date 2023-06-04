using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    private Rigidbody2D rig;
    //private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    private bool colliding;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position);

        if (colliding)
        {

        }
    }
}
