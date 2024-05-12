using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class DusmanYonetici : MonoBehaviour
{
    [SerializeField] List<DusmanUretici> _ureticiler;
    float _dusmanUretmeAraligi = 1.0f;
    float _dusmanUretmeSayaci = 0.0f; 

     void Start() 
    {
        var liste = FindObjectsByType<DusmanUretici>(FindObjectsSortMode.None);

        foreach(var siradaki in liste)
        {
            _ureticiler.Add(siradaki);
        }

    }

    void Update()
    {
        if(_dusmanUretmeSayaci>= _dusmanUretmeAraligi)
        {
            int index = Random.Range(0, _ureticiler.Count);

            _ureticiler[index].Uret();
            _dusmanUretmeSayaci = 0.0f;

        }
        else
        {
            _dusmanUretmeSayaci += Time.deltaTime;
        }
    }

}
