using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class oyunYoneticiKod : MonoBehaviour
{
    int puan;
    public int yasam;
    public TextMeshProUGUI txtPuan;
    public TextMeshProUGUI txtYasam;
    public TextMeshProUGUI txtCarpan;

    [SerializeField] GameObject _yesilCizgi;


    public float carpanGorunmeSuresi = 2.0f;
    private float carpanGorunmeKalanSure = 0.0f;

    void CarpanGizle()
    {
        txtCarpan.gameObject.SetActive(false);

    }

    void CarpanGoster()
    {
        txtCarpan.gameObject.SetActive(true);
    }

    void PuanAta(int puanx)
    {
        puan = puanx;
        txtPuan.text = "Puan: " + puan;
    }

    void YasamAta(int yasamxx)
    {
        yasam = yasamxx;
        txtYasam.text = "Yasam:" + yasam;
    }

    public void puanArtir(Puanlar yenipuan)
    {
        puan = puan + ((int)yenipuan * carpan);
        PuanAta(puan);

        if (carpanGorunmeSuresi - carpanGorunmeKalanSure < 1.0f)
        {
            carpan++;
            txtCarpan.text = "X" + carpan;
        }

        carpanGorunmeKalanSure = carpanGorunmeSuresi;
        //CarpanGoster();
       
    }

    int carpan = 1;
    public void yasamAzalt(int yasamx)
    {
        if (yasam - yasamx < 0)
        {
            yasam = 0;
        }
        else
        {
            yasam = yasam - yasamx;
        }
        YasamAta(yasam);

        float _olcek = (float) yasam / 100.0f;
        var olcekVektoru = _yesilCizgi.transform.localScale;
        olcekVektoru.x = _olcek;
        _yesilCizgi.transform.localScale = olcekVektoru;
    }
    void Start()
    {
        puan = 0;
        PuanAta(puan);
        yasam = 100;
        YasamAta(yasam);

        //CarpanGizle();
    }

    // Update is called once per frame
    void Update()
    {

        if (carpanGorunmeKalanSure <= 0.0f)
        {
            //CarpanGizle();
        }
        else
        {
            carpanGorunmeKalanSure -= Time.deltaTime;
        }

        if (carpanGorunmeSuresi - carpanGorunmeKalanSure >= 1.0f)
        {
            carpan = 1;
            txtCarpan.text = "X" + carpan;
        }
    }
}
