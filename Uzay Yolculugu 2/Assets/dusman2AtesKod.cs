using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusman2AtesKod : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-7.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Duvar"))
        {
            Destroy(gameObject);
        }

    }
}
