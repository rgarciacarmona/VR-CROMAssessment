using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SetCamera : MonoBehaviour
{
    public GameObject cero;
    private Vector3 posNeutra;

    public SteamVR_Action_Boolean trackPad;

    void Start()
    {
        posNeutra = cero.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trackPad.stateDown)
        {
            this.transform.position = new Vector3(posNeutra.x - .33f, posNeutra.y - 1.2f, posNeutra.z - 1f);
            Debug.Log("Click");
        }
            
    }
}
