using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]

public class Asker : MonoBehaviour
{
    public float Can;
    public float MaksCan = 100f;
    public float Hiz = 5f;
    public float Guc = 5f;
    public float AtakHizi = 2f;

    float SonrakiAtak = 0f;

    public int KacAltin = 10;

    Yonetici Yonetici;
    Animator Animator;
    NavMeshAgent HareketKontrol;
    RectTransform SecimKutusu;
    Slider CanUI;

    public Dusman Dusman = null;

    public void Start()
    {
        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
        Animator = GetComponent<Animator>();
        HareketKontrol = GetComponent<NavMeshAgent>();
        CanUI = GetComponentInChildren<Slider>();
        HareketKontrol.speed = Hiz;
        SecimKutusu = GameObject.Find("SecimKutusu").GetComponent<RectTransform>();
        Can = MaksCan;
        CanUI.maxValue = MaksCan;
        CanUI.value = Can;
        Animasyon("Bekle");
	}

    public void Update()
    {
        if (HareketKontrol.hasPath)
			Animasyon ("Koş");
		else
			Animasyon ("Bekle");
            
        if (Input.GetMouseButton(0))
            KutuSecimKontrol();

        if (Dusman != null && Vector3.Distance(transform.position, Dusman.transform.position) <= Dusman.VurusMesafesi && Time.time > SonrakiAtak)
        {
            HareketKontrol.Stop();
            HareketKontrol.ResetPath();

            SonrakiAtak = Time.time + AtakHizi;
            gameObject.transform.LookAt(Dusman.transform);
            Animasyon("Vur");
            Dusman.Hasar(Guc);
        }
    }

    public void Secildin()
    {
        gameObject.GetComponentInChildren<Projector>().enabled = true;
        
        Yonetici.Ekle(GetComponent<Asker>());
    }

    public void Cikarildin(bool YoneticiBiliyormu)
    {
        gameObject.GetComponentInChildren<Projector>().enabled = false;

        if(!YoneticiBiliyormu)
            Yonetici.Cikar(GetComponent<Asker>());
    }

    public void Hasar(float hasar)
    {
        Can = Mathf.Clamp(Can - hasar, 0, MaksCan);

        CanUI.value = Can;

        if (Can <= 0)
            Ol();
    }

    public void Git(Vector3 hedef)
    {
        Dusman = null;
        HareketKontrol.SetDestination(hedef);
    }

    void Ol()
    {
        Yonetici.Cikar(gameObject.GetComponent<Asker>());
        Destroy(gameObject, 2);
        Animasyon("Öl");
    }

    void Animasyon(string anim)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false)
        {
            switch(anim)
            {
                case "Koş":
                    Animator.SetFloat("Yuru", 1);
                break;

                case "Bekle":
                    Animator.SetFloat("Yuru", -1);
                break;

                default:
                    Animator.SetFloat("Yuru", -1);
                    Animator.SetTrigger(anim);
                break;
            }
        }     
    }

    void KutuSecimKontrol()
    {
        if (SecimKutusu.sizeDelta.x <= 0 && SecimKutusu.sizeDelta.y <= 0)
            return;

        Vector3 EkranPoz = Camera.main.WorldToScreenPoint(transform.position);

        if (RectTransformUtility.RectangleContainsScreenPoint(SecimKutusu, EkranPoz, Camera.main))
        {
            this.Secildin();
        }
        else
        {
            this.Cikarildin(false);
        }
    }

    void OnMouseDown()
    {
        Yonetici.Temizle();

        this.Secildin();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Dusman")
        {
            Dusman = col.gameObject.GetComponent<Dusman>();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Dusman")
        {
            Dusman = null;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (Dusman != null && col.gameObject == Dusman.gameObject && Time.time > SonrakiAtak)
        {
            HareketKontrol.Stop();
            HareketKontrol.ResetPath();

            SonrakiAtak = Time.time + AtakHizi;
            gameObject.transform.LookAt(Dusman.transform);
            Animasyon("Vur");
            Dusman.Hasar(Guc);
        }
    }

    public void Saldir(Dusman dusman)
    {
        Dusman = dusman;

        if (Vector3.Distance(transform.position, dusman.transform.position) >= dusman.VurusMesafesi)
        {
            HareketKontrol.SetDestination(Dusman.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
        } 
    }
}
