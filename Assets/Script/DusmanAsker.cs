using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]

public class DusmanAsker : Dusman
{
    public float Hiz = 5f;
    public float Guc = 5f;
    public float AtakHizi = 2f;
    public int KacAltin = 10;

    float SonrakiAtak = 0f;

    Yonetici Yonetici;
    NavMeshAgent HareketKontrol;

    public Kullanici Kullanici = null;

    public new void Start()
    {
        base.Start();

        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();

        HareketKontrol = GetComponent<NavMeshAgent>();
        HareketKontrol.speed = Hiz;

        base.Animasyon("Bekle");
    }

    public void Update()
    {
        if (HareketKontrol.hasPath)
            base.Animasyon("Koş");
        else
            base.Animasyon("Bekle");

        if (Kullanici != null && Vector3.Distance(transform.position, Kullanici.transform.position) <= Kullanici.VurusMesafesi && Time.time > SonrakiAtak)
        {
            HareketKontrol.Stop();
            HareketKontrol.ResetPath();

            SonrakiAtak = Time.time + AtakHizi;
            gameObject.transform.LookAt(Kullanici.transform);
            base.Animasyon("Vur");
            Kullanici.Hasar(Guc);
        } else if(Kullanici != null && Vector3.Distance(transform.position, Kullanici.transform.position) >= Kullanici.VurusMesafesi)
        {
            HareketKontrol.SetDestination(Kullanici.transform.position);
        }

    }

    new void YokOl()
    {
        Destroy(gameObject, 3);
        base.Animasyon("Öl");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Asker" || col.tag == "Yapi")
        {     
            Kullanici = col.gameObject.GetComponent<Kullanici>();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<Kullanici>() == Kullanici)
        {
            Kullanici = null;
        }
    }
}
