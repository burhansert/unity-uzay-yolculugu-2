using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman1Uretici : DusmanUretici
{
    [SerializeField] GameObject _dusmanSablon;
    [SerializeField] Transform _ustSinir;
    [SerializeField] Transform _altSinir;

    public override void Uret()
    {
        float x = _altSinir.position.x;
        float y = Random.Range(_altSinir.position.y, _ustSinir.position.y);

        var yeniDusman = Instantiate(_dusmanSablon);
        yeniDusman.transform.position = new Vector3(x,y,0);

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
