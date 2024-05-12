using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipKod : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity=Vector3.left*10.0f;
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Duvar"))
        {
            Destroy(gameObject);
        }
    }
}
