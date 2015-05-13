using UnityEngine;
using System.Collections;

public class Dusman : MonoBehaviour
{
    public float Can;
    public float MaksCan = 100f;
    public float VurusMesafesi = 10f;

    public Texture2D FareImleci;

    Animator Animator;

    public void Start()
    {
        Animator = GetComponent<Animator>(); ;
        Can = MaksCan;
    }

    public void Hasar(float hasar)
    {
        Can = Mathf.Clamp(Can - hasar, 0, MaksCan);

        if (Can <= 0)
            YokOl();
    }

    protected void YokOl()
    {
        Animasyon("Öl");
        Destroy(gameObject, 1);
    }

    protected void Animasyon(string anim)
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(anim) == false)
        {
            switch (anim)
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

    void OnMouseEnter()
    {
        Cursor.SetCursor(FareImleci, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
