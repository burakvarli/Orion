using UnityEngine;
using System.Collections;

public class Yapi : MonoBehaviour
{
    public float Can;
    public float MaksCan = 1000f;

    public int KacAltin = 100;

    Animator Animator;

	public void Start()
    {
        Can = MaksCan;
        Animator = GetComponent<Animator>();
	}

    public void Update()
    {
        
    }

    public void Hasar(float hasar)
    {
        Can = Mathf.Clamp(Can - hasar, 0, MaksCan);

        if (Can <= 0)
            YokOl();
    }

    void YokOl()
    {
        Animasyon("Yokol");
        Destroy(gameObject, 1);
    }

    void Animasyon(string anim)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false){
            Animator.SetTrigger(anim);  
        }   
    }
}
