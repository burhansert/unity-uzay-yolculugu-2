using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayatCizgisiKod : MonoBehaviour
{
    int _toplamYasam;
    int _kalanYasam;
    float _olcek;
    [SerializeField] GameObject _yesilCizgi;
    [SerializeField] GameObject _kirmiziCizgi;
    public int ToplamYasam
    {
        get {return _toplamYasam; }
         set {
            _toplamYasam= value;
            _kalanYasam = value;
        }
    }
    public int KalanYasam
    {
        get { return _kalanYasam; }
    }
    void Start()
    {
        ToplamYasam = 8;
       // _yesilCizgi.GetComponent<Renderer>().enabled = false;
        _yesilCizgi.SetActive(false);
        _kirmiziCizgi.SetActive(false);
    }

    public void goster()
    {
        _yesilCizgi.SetActive(true);
        _kirmiziCizgi.SetActive(true);
    }

    public void gizle()
    {
        _yesilCizgi.SetActive(false);
        _kirmiziCizgi.SetActive(false);
    }
    public void YasamAzalt(int azaltmaMiktari=1)
    {
        _kalanYasam -= azaltmaMiktari;
        if (_kalanYasam < 0)
            _kalanYasam = 0;

        _olcek = (float)_kalanYasam / (float)_toplamYasam;
    
        var olcekVektoru = _yesilCizgi.transform.localScale;
        olcekVektoru.x = _olcek;
        _yesilCizgi.transform.localScale = olcekVektoru;
    }

    void Update()
    {
    
    }
}
