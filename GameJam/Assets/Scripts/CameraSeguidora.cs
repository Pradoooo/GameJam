using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguidora : MonoBehaviour
{
    public Transform player;

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.2f);
    }

}