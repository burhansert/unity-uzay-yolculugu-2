using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesUreticiKod : MonoBehaviour
{
    static SesUreticiKod instance;
    [SerializeField] List<AudioClip> _sesKlipleri;
    AudioSource _source;
    public enum SesTurleri
    {
        Ates=0,
        Patlama=1,
        Vurma = 2,
    }
    void Start()
    {
        instance=this;
        _source=GetComponent<AudioSource>();
    }
    public static void SesUret(SesTurleri tur)
    {
        int indeks = (int)tur;
        instance._source.clip = instance._sesKlipleri[indeks];
        instance._source.Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
