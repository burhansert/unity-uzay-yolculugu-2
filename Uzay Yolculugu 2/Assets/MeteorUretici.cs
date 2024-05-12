using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorUretici : DusmanUretici
{
    [SerializeField] GameObject _meteorSablon;
    [SerializeField] Transform _ustSinir;
    [SerializeField] Transform _altSinir;
    [SerializeField] Transform _player;
    public override void Uret()
    {
        float x = _altSinir.position.x;
        float y = Random.Range(_altSinir.position.y, _ustSinir.position.y);

        var meteor = Instantiate(_meteorSablon);
        meteor.transform.position = new Vector3(x, y, 0);

        Vector3 hiz = _player.position - meteor.transform.position;

        meteor.GetComponent<Rigidbody2D>().velocity = hiz.normalized*5.0f;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
