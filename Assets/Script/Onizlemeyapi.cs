using UnityEngine;
using System.Collections;

public class Onizlemeyapi : MonoBehaviour
{

    bool aktif = false;

    void Update()
    {
        if (aktif)
        {       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {       
                Vector3 pos = hit.point;
                pos.y = 0.9f;

                gameObject.transform.position = pos;
            }

            if (Input.GetMouseButtonDown(0))
            {
                this.OnizlemeModu(false);
            }

        }
    }

    public void OnizlemeModu(bool aktf)
    {
        aktif = aktf;

        gameObject.GetComponent<Yapi>().enabled = !aktif;
        gameObject.GetComponent<NavMeshObstacle>().enabled = !aktif;
    }
}
