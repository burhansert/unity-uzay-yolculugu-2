using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKod : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidBody;
    [SerializeField] float _hareketCarpanai = 10.0f;
    [SerializeField] GameObject _atesSablon;
    public float saglik = 100f;
    public bool oldum = false;
    oyunYoneticiKod oyunYoneticiX;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody=GetComponent<Rigidbody2D>();
        oyunYoneticiX = GameObject.Find("oyunYonetici").GetComponent<oyunYoneticiKod>();
    }

    void Update()
    {
        hareketEt();
      if (Input.GetKeyDown(KeyCode.Space))
        {
            var ates = Instantiate(_atesSablon);
            ates.transform.position = transform.position;

            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Ates);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    void hareketEt()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        bool asagiBasildimi = false;
        bool yukariBasildimi = false;

        if (y < 0)
        {
            asagiBasildimi = true;
        }
        else if (y > 0)
        {
            yukariBasildimi = true;
        }
        _animator.SetBool("asagiBasildi", asagiBasildimi);
        _animator.SetBool("yukariBasildi", yukariBasildimi);

        _rigidBody.velocity = new Vector2(x * _hareketCarpanai, y * _hareketCarpanai);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteor")
        {
            oyunYoneticiX.yasamAzalt((int)Hasarlar.meteorCarpti);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            //Destroy(collision.gameObject);
            //print("1"+other.name);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }
        else if (collision.tag == "Dusman")
        {
            oyunYoneticiX.yasamAzalt((int)Hasarlar.dusmanCarpti);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            Destroy(collision.gameObject);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }
        else if (collision.tag == "Dusman2")
        {
            oyunYoneticiX.yasamAzalt((int)Hasarlar.dusman2Carpti);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            Destroy(collision.gameObject);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }
        else if (collision.tag == "Dusman2Ates")
        {
            oyunYoneticiX.yasamAzalt((int)Hasarlar.dusman2AtesCarpti);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            Destroy(collision.gameObject);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }
        else if (collision.tag == "KucukMeteor")
        {
            oyunYoneticiX.yasamAzalt((int)Hasarlar.kucukMeteorCarpti);
            PatlamaUreticiKod.PatlamaUret(collision.transform.position);
            Destroy(collision.gameObject);
            SesUreticiKod.SesUret(SesUreticiKod.SesTurleri.Vurma);
        }

        oluMuyum();
    }

    public void HasarAl(float hasar)
    {
        if ((saglik - hasar) >= 0)
        {
            saglik = saglik - hasar;
        }
        else
        {
            saglik = 0;
        }
        oluMuyum();
    }

    void oluMuyum()
    {
        if (saglik <= 0) oldum = true;
    }
}
