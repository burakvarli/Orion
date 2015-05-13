using UnityEngine;
using System.Collections;

public class Kullanici : MonoBehaviour
{
    public float Can;
    public float MaksCan = 1000f;
    public float VurusMesafesi = 1f;
    public int KacAltin = 100;

    protected Animator Animator;

    public void Start()
    {
        Can = MaksCan;
        Animator = GetComponent<Animator>();
    }

    public virtual void Hasar(float hasar)
    {
        Can = Mathf.Clamp(Can - hasar, 0, MaksCan);

        if (Can <= 0)
            YokOl();
    }

    public void YokOl()
    {
        Animasyon("Yokol");
        Destroy(gameObject, 1);
    }

    void Animasyon(string anim)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false)
        {
            Animator.SetTrigger(anim);
        }
    }
}
