using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Yonetici : MonoBehaviour
{

    public int Altin = 1000;

    public List<Asker> Secilenler;

	void Start()
    {
        Secilenler.Clear();
	}
	
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Sec();

        if (Input.GetMouseButtonDown(1))
            Git();
	}

    void Sec()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Asker")
            {
                hit.transform.GetComponent<Asker>().Secildin(Input.GetKey(KeyCode.LeftControl));
            }
            else if (hit.transform.tag == "Ortam")
            {
                foreach (Asker asker in Secilenler)
                {
                    asker.GetComponent<Asker>().Cikarildin();
                }

                Secilenler.Clear();
            }
        }
    }

    void Git()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Ortam")
            {
                foreach (Asker asker in Secilenler)
                {
                    asker.GetComponent<Asker>().Git(hit.point);
                }
            }
        }
    }


    public void TekSeciliEkle(Asker asker)
    {
        foreach (Asker askr in Secilenler)
        {
            if (askr != asker)
                askr.GetComponent<Asker>().Cikarildin();
        }

        Secilenler.Clear();
        Secilenler.Add(asker);
    }

    public void CokluSeciliEkle(Asker asker)
    {
        if (!Secilenler.Contains(asker))
            Secilenler.Add(asker);
        else
        {
            asker.GetComponent<Asker>().Cikarildin();
            Secilenler.Remove(asker);
        }
            
    }

    public void Cikar(Asker asker)
    {
        Secilenler.Remove(asker);
    }

}
