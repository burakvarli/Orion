using UnityEngine;
using System.Collections;

public class HazineSandigi : MonoBehaviour
{
    public int Altin = 100;
    public Texture2D FareImleci;

    Yonetici Yonetici;

    void Start()
    {
        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
    }

    void OnTriggerEnter(Collider obje)
    {
        if (obje.gameObject.tag == "Asker")
        {
            Yonetici.AltinAl(Altin);
            Destroy(gameObject);
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
