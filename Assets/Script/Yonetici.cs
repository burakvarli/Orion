using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Yonetici : MonoBehaviour
{

    public int Altin = 1000;

    public GameObject VarisNoktasi;

    public Asker[] Askerler;
    public Yapi[] Yapilar;

    public List<Asker> Secilenler;

    public Text ParanizYok;
    public Text AltinUI;

	void Start()
    {
        AltinUI.text = "Altın: " + Altin;
        this.Temizle();
	}
	
	void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Sec();
  
        if(Input.GetMouseButtonDown(1))
            Git();
	}

    void Sec()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag != "Asker")
            {
                this.Temizle();
            }         
        }
    }

    void Git()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if ((hit.transform.tag == "Ortam" || hit.transform.tag == "Sandik") && Secilenler.Count > 0)
            {
                VarisNoktasi.transform.position = new Vector3(hit.point.x, VarisNoktasi.transform.position.y, hit.point.z);
                VarisNoktasi.SetActive(true);

                foreach (Asker asker in Secilenler)
                {
                    asker.GetComponent<Asker>().Git(hit.point);
                }
            }
        }
    }

    public void Ekle(Asker asker)
    {
        if (!Secilenler.Contains(asker))
            Secilenler.Add(asker);
    }

    public void Cikar(Asker asker)
    {
        Secilenler.Remove(asker);
    }

    public void Temizle()
    {
        if (Secilenler.Count <= 0)
            return;

        foreach (Asker asker in Secilenler)
        {
            asker.GetComponent<Asker>().Cikarildin(true);
        }

        Secilenler.Clear();
    }

    public void AskerYarat(int indis)
    {
        Asker YaratilacakAsker = Askerler[indis];

        if (YaratilacakAsker.KacAltin <= Altin)
        {
            Altin -= YaratilacakAsker.KacAltin;
            AltinUI.text = "Altın: " + Altin;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.y = 0;

                Asker asker = Instantiate(YaratilacakAsker, pos, Quaternion.identity) as Asker;

                asker.GetComponent<Onizleme>().enabled = true;
                asker.GetComponent<Onizleme>().OnizlemeModu(true);
            }

            
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(MesajVer(ParanizYok));
        }
    }

    IEnumerator MesajVer(Text text)
    {
        text.gameObject.SetActive(true);

        yield return new WaitForSeconds(4);

        text.gameObject.SetActive(false);
    }

    public void AltinAl(int miktar)
    {
        Altin += miktar;

        AltinUI.text = "Altın: " + Altin;
    }

    public void YapiYarat(int indis)
    {
        Yapi YapilacakYapi = Yapilar[indis];

        if (YapilacakYapi.KacAltin <= Altin)
        {
            Altin -= YapilacakYapi.KacAltin;
            AltinUI.text = "Altın: " + Altin;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.y = 0.9f;

                Yapi yapi = Instantiate(YapilacakYapi, pos, Quaternion.identity) as Yapi;

                yapi.GetComponent<Onizlemeyapi>().enabled = true;
                yapi.GetComponent<Onizlemeyapi>().OnizlemeModu(true);
            }
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(MesajVer(ParanizYok));
        }
    }

    public void AltinEkle(int miktar)
    {
        Altin += miktar;
        AltinUI.text = "Altın: " + Altin;
    }
}
