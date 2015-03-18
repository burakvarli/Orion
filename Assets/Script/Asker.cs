using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]

public class Asker : MonoBehaviour
{
    public float Can;
    public float MaksCan = 100f;

    public int KacAltin = 10;

    bool Secili = false;

    Yonetici Yonetici;
    Animator Animator;
    NavMeshAgent HareketKontrol;

    public void Start()
    {
        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
        Animator = GetComponent<Animator>();
        HareketKontrol = GetComponent<NavMeshAgent>();
        Can = MaksCan;
	}

    public void Update()
    {
        if (HareketKontrol.hasPath)
            Animasyon("Koş");     
        else
            Animasyon("Bekle");
    }

    public void Secildin(bool cift)
    {
        Secili = true;
        gameObject.GetComponentInChildren<Projector>().enabled = true;

        if (cift)
           Yonetici.CokluSeciliEkle(GetComponent<Asker>());
        else
           Yonetici.TekSeciliEkle(GetComponent<Asker>()); 
    }

    public void Cikarildin()
    {
        Secili = false;
        gameObject.GetComponentInChildren<Projector>().enabled = false;
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
        /*if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim))
        {
            //animasyon zaten oynuyor
        } 
        else if(Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false)
        {
            Animator.();
            Animator.SetTrigger(anim);
        }
        else
        {
            Animator.SetTrigger(anim);
        }*/

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

}
