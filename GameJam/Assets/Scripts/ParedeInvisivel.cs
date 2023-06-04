using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeInvisivel : MonoBehaviour
{
    [SerializeField]public GameObject Paredes; 
    void Start()
    {
        Paredes.GetComponent<SpriteRenderer>();
        Paredes.SetActive(false);
    }
}
