using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintPos : MonoBehaviour
{

    public Transform a;
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Ciao!");

        Debug.Log(a.position);
    }
}
