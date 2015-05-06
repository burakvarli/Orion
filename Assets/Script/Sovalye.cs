using UnityEngine;
using System.Collections;

public class Sovalye : Asker
{
    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
