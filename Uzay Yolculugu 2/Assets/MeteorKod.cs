using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorKod : MonoBehaviour
{

    [SerializeField] HayatCizgisiKod _hayatCizgisi;
    [SerializeField] Transform _sprite;
    [SerializeField] GameObject _kucukMeteorSablon;

    oyunYoneticiKod oyunYoneticiX;

    public float barGorunmeSuresi = 3.0f;
    private float barGorunmeKalanSure = 0.0f; 
    void Start()
    {
        oyunYoneticiX = GameObject.Find("oyunYonetici").GetComponent<oyunYoneticiKod>();
    }
    private void Awake() //prefab lar baþlangýçta Start çaðýrmýyor Awake çaðýrýyor
    {
        // _hayatCizgisi.ToplamYasam = 100;
        //_hayatCizgisi.gameObject.ReSetActive(false);

       // _hayatCizgisiKirmizi.gameObject.GetComponent<Renderer>().enabled = true;
       // _hayatCizgisiYesil.gameObject.GetComponent<Renderer>().enabled = true;
        // Renderer renderer = _hayatCizgisi.GetComponent<Renderer>();
        //renderer.enabled = false;
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Mermi"))
        {
            _hayatCizgisi.YasamAzalt();
            if(_hayatCizgisi.KalanYasam<=0)
            {
                Destroy(gameObject);
                PatlamaUreticiKod.PatlamaUret(transform.position);
                KucukMeteorUret();
                oyunYoneticiX.puanArtir(Puanlar.meteorYokedildi);
                _hayatCizgisi.gizle();
            }
            else
            {
               // print("ee" + barGorunmeSuresi);
                 barGorunmeKalanSure = barGorunmeSuresi;
                _hayatCizgisi.goster();
            }

        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Duvar"))
        {
            Destroy(gameObject);
          //  print("evet");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
   
    }

    public void KucukMeteorUret()
    {
        var kYukari = Instantiate(_kucukMeteorSablon);
        var kAsagi = Instantiate(_kucukMeteorSablon);
        kYukari.transform.position= transform.position;
        kAsagi.transform.position = transform.position;
        Vector2 hiz = new Vector2(-10.0f, 5.0f);
        kYukari.GetComponent<Rigidbody2D>().velocity = hiz;
        hiz.y = -hiz.y;
        kAsagi.GetComponent<Rigidbody2D>().velocity = hiz;
    }
    void Update()
    {
        _sprite.Rotate(0.0f, 0.0f, 0.4f);

        if(barGorunmeKalanSure<=0.0f)
        {
            _hayatCizgisi.gizle();
        }
        else
        {
            barGorunmeKalanSure -= Time.deltaTime;
          //  print(barGorunmeKalanSure);
        }
    }
}
