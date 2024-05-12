using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman2Kod : MonoBehaviour
{
    public GameObject _mermiCikis;
    public GameObject _mermi;

    public float mermiUretmeAraligi = 1.5f;
    public float mermiUretmeSayaci = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.left * 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mermiUretmeSayaci >= mermiUretmeAraligi)
        {
            GameObject mermix = Instantiate(_mermi, _mermiCikis.transform.position, Quaternion.identity);

            mermiUretmeSayaci = 0.0f;
        }
        mermiUretmeSayaci += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Duvar"))
        {
            Destroy(gameObject);
        }
    }
}
