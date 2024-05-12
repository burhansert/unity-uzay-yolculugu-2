using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanKod : MonoBehaviour
{
    [SerializeField] GameObject _resim1;
    [SerializeField] GameObject _resim2;
    GameObject _aktif;
    GameObject _sag;
    float mesafeX, minX;
    [SerializeField] float _akisHizi = 0.01f;
    void Start()
    {
        _aktif = _resim1;
        _sag = _resim2;
        mesafeX = _sag.transform.position.x-_aktif.transform.position.x;
        minX = _aktif.transform.position.x - mesafeX;
    }

    // Update is called once per frame
    void Update()
    {
        _aktif.transform.position += new Vector3(-_akisHizi, 0.0f, 0.0f);
        _sag.transform.position += new Vector3(-_akisHizi, 0.0f, 0.0f);

        if(_aktif.transform.position.x<minX)
        {
            _aktif.transform.position = _sag.transform.position + new Vector3(mesafeX, 0.0f, 0.0f);

            GameObject gecici = _aktif;
            _aktif = _sag;
            _sag = gecici;
        }
    }
}
