using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject lightsRing1;
    public GameObject lightsRing2;
    public GameObject lightsRing3;
    public GameObject gimbalRing;

    Rotation rigRotation;

    // Start is called before the first frame update
    void Start()
    {
        rigRotation = gimbalRing.GetComponent<Rotation>();
        for(int i = 0; i < lightsRing1.transform.childCount; i++)
        {
            lightsRing1.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }
        for (int i = 0; i < lightsRing2.transform.childCount; i++)
        {
            lightsRing2.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }
        for (int i = 0; i < lightsRing3.transform.childCount; i++)
        {
            lightsRing3.transform.GetChild(i).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rigRotation.rotationSpeed1 > 0.1 && rigRotation.rotationSpeed1 < 60)
            lightsRing1.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        //lightsRing1.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(49, 132, 49));
    }
}
