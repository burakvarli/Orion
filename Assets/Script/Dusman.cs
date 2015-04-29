using UnityEngine;
using System.Collections;

public class Dusman : MonoBehaviour
{
    public float Can;
    public float MaksCan = 100f;
    public float VurusMesafesi = 10f;

    public Texture2D FareImleci;

    Animator Animator;

    void Start()
    {
        Can = MaksCan;
        Animator = GetComponent<Animator>();
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
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false)
        {
            Animator.SetTrigger(anim);
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(FareImleci, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
