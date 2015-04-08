using UnityEngine;
using System.Collections;

public class Onizleme : MonoBehaviour
{
    public Shader OnizlemeShader;
    Shader OrjinalShader;

    bool aktif = false;

	void Awake()
    {
        OrjinalShader = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.shader;
        //OnizlemeShader = Shader.Find("Unlit/Transparent Cutout");
	}

    void Update()
    {
        if (aktif)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.y = 0;

                transform.position = pos;
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

        foreach (SkinnedMeshRenderer rnderer in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            if (aktif)
                rnderer.materials[0].shader = OnizlemeShader;
            else { 
                rnderer.materials[0].shader = OrjinalShader;
                Debug.Log(OrjinalShader);
            }
        }

        gameObject.GetComponent<Asker>().enabled = !aktif;
        //gameObject.GetComponent<NavMeshAgent>().enabled = !aktif;
    }
	
}
