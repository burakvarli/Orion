using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AltinAnimasyon : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        Destroy(gameObject, 1);
        text.CrossFadeAlpha(0f, .8f, false);
    }
	
	void FixedUpdate()
    {
        //gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z - 25f);
        text.fontSize += 1;       
	}
}
