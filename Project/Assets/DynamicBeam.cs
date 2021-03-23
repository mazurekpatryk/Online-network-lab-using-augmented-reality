using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class DynamicBeam : MonoBehaviour
{

    public GameObject cotroller;
    private LineRenderer beamLine;
    public Color startColor;
    public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        beamLine = GetComponent<LineRenderer>();
        beamLine.startColor = startColor;
        beamLine.endColor = endColor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cotroller.transform.position;
        transform.rotation = cotroller.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beamLine.useWorldSpace = true;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, hit.point);
        }
        else
        {
            beamLine.useWorldSpace = false;
            beamLine.SetPosition(0, transform.position);
            beamLine.SetPosition(1, Vector3.forward * 5);
        }

    }
}
