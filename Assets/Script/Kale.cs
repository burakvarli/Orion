using UnityEngine;
using System.Collections;

public class Kale : Yapi
{
    Yonetici Yonetici;

    new void Start()
    {
        base.Start();

        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
	}

    new void Update()
    {
        base.Update();
	}

    new void Yokol()
    {
        base.YokOl();
        Yonetici.Kaybettik();
    }
}
