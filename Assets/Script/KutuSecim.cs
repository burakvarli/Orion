using UnityEngine;
using System.Collections;

public class KutuSecim : MonoBehaviour {

    public RectTransform SecimKutusu;

    Vector2 BaslangicNoktasi = Vector2.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BaslangicNoktasi = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            SecimKutusu.anchoredPosition = BaslangicNoktasi;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 BitisNoktasi = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 Fark = BitisNoktasi - BaslangicNoktasi;
            Vector2 baslangic = BaslangicNoktasi;

            if (Fark.x < 0)
            {
                baslangic.x = BitisNoktasi.x;
                Fark.x = -Fark.x;
            }
            if (Fark.y < 0)
            {
                baslangic.y = BitisNoktasi.y;
                Fark.y = -Fark.y;
            }

            SecimKutusu.anchoredPosition = baslangic;
            SecimKutusu.sizeDelta = Fark;

        }

        if (Input.GetMouseButtonUp(0))
        {
            BaslangicNoktasi = Vector2.zero;
            SecimKutusu.anchoredPosition = Vector2.zero;
            SecimKutusu.sizeDelta = Vector2.zero;
        }
    }
}
