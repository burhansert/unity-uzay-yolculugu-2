using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MermiKod : MonoBehaviour
{
    [SerializeField] float _hareketCarpani = 10.0f;

    [SerializeField] GameObject _mermiUcu;
    Rigidbody2D _rigidBody;
    oyunYoneticiKod oyunYoneticiX;

    //public float carpanGorunmeSuresi = 3.0f;
    //private float carpanGorunmeKalanSure = 0.0f;

    void Start()
    {
        _rigidBody=GetComponent<Rigidbody2D>();
        _rigidBody.velocity = new Vector2(_hareketCarpani,0.0f);
        oyunYoneticiX = GameObject.Find("oyunYonetici").GetComponent<oyunYoneticiKod>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SagDuvar"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dusman"))
        {
            Destroy(collision.gameObject);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Patlama);
            Destroy(gameObject);
            oyunYoneticiX.puanArtir(Puanlar.dusmanVuruldu);
        }
        if (collision.CompareTag("Dusman2"))
        {
            Destroy(collision.gameObject);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Patlama);
            Destroy(gameObject);
            oyunYoneticiX.puanArtir(Puanlar.dusman2Vuruldu);

        }
        if (collision.CompareTag("Dusman2Ates"))
        {
            Destroy(collision.gameObject);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Patlama);
            Destroy(gameObject);
            oyunYoneticiX.puanArtir(Puanlar.dusman2AtesVuruldu);

        }
        if (collision.CompareTag("Meteor"))
        {
            Destroy(gameObject);
            PatlamaUreticiKod.VurmaUret(_mermiUcu.transform.position);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
            oyunYoneticiX.puanArtir(Puanlar.meteorVuruldu);
        }
        if (collision.CompareTag("KucukMeteor"))
        {
            Destroy(gameObject);
            PatlamaUreticiKod.VurmaUret(_mermiUcu.transform.position);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
            oyunYoneticiX.puanArtir(Puanlar.kucukMeteorVuruldu);
        }
    }
    void Update()
    {
        
    }
}
