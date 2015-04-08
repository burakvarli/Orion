using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]

public class Asker : MonoBehaviour
{
    public float Can;
    public float MaksCan = 100f;
    public float Hiz = 5;

    public int KacAltin = 10;

    Yonetici Yonetici;
    Animator Animator;
    NavMeshAgent HareketKontrol;
    RectTransform SecimKutusu;

    public void Start()
    {
        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
        Animator = GetComponent<Animator>();
        HareketKontrol = GetComponent<NavMeshAgent>();
        HareketKontrol.speed = Hiz;
        SecimKutusu = GameObject.Find("SecimKutusu").GetComponent<RectTransform>();
        Can = MaksCan;
        Animasyon("Bekle");      
	}

    public void Update()
    {
        if (HareketKontrol.hasPath && HareketKontrol.remainingDistance > 1)
			Animasyon ("Koş");
		else
			Animasyon ("Bekle");
            
        if (Input.GetMouseButton(0))
            KutuSecimKontrol();
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

        if (Can <= 0)
            Ol();
    }

    public void Git(Vector3 hedef)
    {
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
}
