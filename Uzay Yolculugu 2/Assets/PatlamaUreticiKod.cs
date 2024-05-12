using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaUreticiKod : MonoBehaviour
{
    [SerializeField] GameObject _patlamaSablon;
    [SerializeField] GameObject _vurmaSablon;
    static PatlamaUreticiKod referans;
    void Start()
    {
        referans = this;
    }

    public static void PatlamaUret(Vector3 konum)
    {
        var patlama = Instantiate(referans._patlamaSablon);
        patlama.transform.position = konum;
    }
    public static void VurmaUret(Vector3 konum)
    {
        var vurma = Instantiate(referans._vurmaSablon);
        vurma.transform.position = konum;
    }
    void Update()
    {
        
    }
}
