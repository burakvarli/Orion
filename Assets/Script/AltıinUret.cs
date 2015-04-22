using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AltıinUret : MonoBehaviour
{
    public int Miktar = 10;
    public float Sure = 5;

    GameObject AltinAnimUI;
    Yonetici Yonetici;

	void Start()
    {
        Yonetici = GameObject.FindGameObjectWithTag("Yonetici").GetComponent<Yonetici>();
        AltinAnimUI = Resources.Load("AltinAnimasyon") as GameObject;

        InvokeRepeating("AltinUret", Sure, Sure);
	}
	
	void AltinUret()
    {
        Yonetici.AltinEkle(Miktar);
        UIAnimasyon();
	}

    void UIAnimasyon()
    {
        Vector3 EkranPoz = Camera.main.WorldToScreenPoint(transform.position);

        Debug.Log(EkranPoz);

        GameObject Anim = (GameObject)Instantiate(AltinAnimUI);
        Anim.transform.SetParent(GameObject.FindGameObjectWithTag("AnaTuval").transform, false);
        Anim.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(EkranPoz.x, EkranPoz.y);
        Anim.GetComponent<Text>().text = "+" + Miktar.ToString();
    }
}
