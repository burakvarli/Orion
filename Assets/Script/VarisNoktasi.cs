using UnityEngine;
using System.Collections;

public class VarisNoktasi : MonoBehaviour
{
    void OnTriggerEnter(Collider obje)
    {
        if (obje.gameObject.tag == "Asker")
            gameObject.SetActive(false);
    }
}
