using System.Collections;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject lightsRing1;
    public GameObject lightsRing2;
    public GameObject lightsRing3;
    public GameObject gimbalRing;
    public GameObject visor;
    public GameObject health;
    public GameObject impact;

    Rotation rigRotation;
    float speed = 0f;
    bool loop = false;

    // Start is called before the first frame update
    void Start()
    {
        rigRotation = gimbalRing.GetComponent<Rotation>();

        health.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        health.transform.GetChild(0).GetComponent<Light>().enabled = false;

        impact.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        impact.transform.GetChild(0).GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lightsRing1.transform.childCount; i++)
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
        visor.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);
        
        speed = Mathf.Abs(rigRotation.rotationSpeed1) + Mathf.Abs(rigRotation.rotationSpeed2) + Mathf.Abs(rigRotation.rotationSpeed3);        

        // Rig 1
        if (rigRotation.rotationSpeed1 >= 0.1 && rigRotation.rotationSpeed1 < 60)
            lightsRing1.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed1 >= 60  && rigRotation.rotationSpeed1 < 120)
            lightsRing1.transform.GetChild(6).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed1 >= 120)
            lightsRing1.transform.GetChild(4).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed1 <= -0.1 && rigRotation.rotationSpeed1 > -60)
            lightsRing1.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed1 <= -60 && rigRotation.rotationSpeed1 > -120)
            lightsRing1.transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed1 <= -120)
            lightsRing1.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed1 > -0.1 && rigRotation.rotationSpeed1 < 0.1)
            lightsRing1.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);

        // Rig 2
        if (rigRotation.rotationSpeed2 >= 0.1 && rigRotation.rotationSpeed2 < 60)
            lightsRing2.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed2 >= 60 && rigRotation.rotationSpeed2 < 120)
            lightsRing2.transform.GetChild(6).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed2 >= 120)
            lightsRing2.transform.GetChild(4).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed2 <= -0.1 && rigRotation.rotationSpeed2 > -60)
            lightsRing2.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed2 <= -60 && rigRotation.rotationSpeed2 > -120)
            lightsRing2.transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed2 <= -120)
            lightsRing2.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed2 > -0.1 && rigRotation.rotationSpeed2 < 0.1)
            lightsRing2.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);

        // Rig 3
        if (rigRotation.rotationSpeed3 >= 0.1 && rigRotation.rotationSpeed3 < 60)
            lightsRing3.transform.GetChild(2).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed3 >= 60 && rigRotation.rotationSpeed3 < 120)
            lightsRing3.transform.GetChild(6).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed3 >= 120)
            lightsRing3.transform.GetChild(4).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed3 <= -0.1 && rigRotation.rotationSpeed3 > -60)
            lightsRing3.transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (rigRotation.rotationSpeed3 <= -60 && rigRotation.rotationSpeed3 > -120)
            lightsRing3.transform.GetChild(5).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        if (rigRotation.rotationSpeed3 <= -120)
            lightsRing3.transform.GetChild(3).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        if (rigRotation.rotationSpeed3 > -0.1 && rigRotation.rotationSpeed3 < 0.1)
            lightsRing3.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);

        // Visor
        if (speed < 270)
            visor.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        if (speed >= 270 && speed < 472.5)
            visor.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        if (speed >= 472.5)
            visor.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

        // Health
        if (!loop)
        {
            if (speed >= 270 && speed < 337.5)
            {
                StartCoroutine(LightFlash(0));
            }
            if (speed >= 337.5 && speed < 405)
            {
                StartCoroutine(LightFlash(1));
            }
            if (speed >= 405 && speed < 472.5)
            {
                StartCoroutine(LightFlash(2));
            }
        }
        if (speed >= 472.5)
        {
            health.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            health.transform.GetChild(0).GetComponent<Light>().enabled = true;
        }
    }

    IEnumerator LightFlash(int status)
    {
        loop = true;

        health.GetComponent<AudioSource>().Play();

        health.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        health.transform.GetChild(0).GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(1);

        health.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        health.transform.GetChild(0).GetComponent<Light>().enabled = false;

        switch (status)
        {
            case 0:
                yield return new WaitForSeconds(3);
                break;
            case 1:
                yield return new WaitForSeconds(2);
                break;
            case 2:
                yield return new WaitForSeconds(1);
                break;
        }
        loop = false;
    }
}
