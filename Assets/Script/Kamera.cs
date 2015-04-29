using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour
{
    //hareket ayarları
    public float Hassasiyet = 25f;
    public float Hiz = 5f;

    //yakınlaştırma ayarları
    public float MinYakinlik = 3f;
    public float MaksYakinlik = 10f;
    public float YakinlastirmaHizi = 10f;

    float Genislik = Screen.width;
    float Yukseklik = Screen.height;

	void Update()
    {
        Hareket();
        Yakinlastir();
	}

    void Hareket()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if (Genislik - x <= Hassasiyet) //sağa git
        {
            transform.Translate(Vector3.right * Hiz * Time.deltaTime);
        }

        if (x <= Hassasiyet) //sola git
        {
            transform.Translate(Vector3.left * Hiz * Time.deltaTime);
        }

        if (y <= Hassasiyet) //alta git
        {
            transform.Translate(Vector3.down * Hiz * Time.deltaTime);
        }

        if (Yukseklik - y <= Hassasiyet) //üste git
        {
            transform.Translate(Vector3.up * Hiz * Time.deltaTime);
        }
    }

    void Yakinlastir() {

        Camera.main.orthographicSize += -Input.GetAxis("Mouse ScrollWheel") * YakinlastirmaHizi * Time.deltaTime;

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, MinYakinlik, MaksYakinlik);

        /* transform.position += new Vector3(0, -Input.GetAxis("Mouse ScrollWheel") * YakinlastirmaHizi * Time.deltaTime, 0);

        if (transform.position.y > MaksYakinlik)
            transform.position = new Vector3(transform.position.x, MaksYakinlik, transform.position.z);

        if (transform.position.y < MinYakinlik)
            transform.position = new Vector3(transform.position.x, MinYakinlik, transform.position.z);*/
    }
 
}
