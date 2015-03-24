using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Yonetici : MonoBehaviour
{

    public int Altin = 1000;

    public GameObject VarisNoktasi;

    public List<Asker> Secilenler;

	void Start()
    {
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
            if (hit.transform.tag == "Ortam" && Secilenler.Count > 0)
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
        foreach (Asker asker in Secilenler)
        {
            asker.GetComponent<Asker>().Cikarildin(true);
        }

        Secilenler.Clear();
    }

}
