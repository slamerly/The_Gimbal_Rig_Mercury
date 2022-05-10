using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public GameObject gimbalRig;
    public GameObject impactLight;
    public int difficulty = 0;

    Rotation rotations;
    float maxSpeed = 0f;
    float currentTime;
    float nextImpulse = 0;
    float speedAddToCurrent;
    bool loop = false;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = StaticClassCrossScene.Difficulty;
        rotations = gimbalRig.GetComponent<Rotation>();

        switch (difficulty)
        {
            case 0:
                do
                {
                    maxSpeed = 270;
                    rotations.rotationSpeed1 = Random.Range(-60f, 60f);
                    maxSpeed -= rotations.rotationSpeed1;
                    rotations.rotationSpeed2 = Random.Range(-60f, 60f);
                    maxSpeed -= rotations.rotationSpeed2;
                    rotations.rotationSpeed3 = Random.Range(-60f, 60f);
                    maxSpeed -= rotations.rotationSpeed3;
                } while (maxSpeed < 0);
                nextImpulse = 40;
                break;
            case 1:
                do
                {
                    maxSpeed = 270;
                    rotations.rotationSpeed1 = Random.Range(-120f, 120f);
                    maxSpeed -= rotations.rotationSpeed1;
                    rotations.rotationSpeed2 = Random.Range(-120f, 120f);
                    maxSpeed -= rotations.rotationSpeed2;
                    rotations.rotationSpeed3 = Random.Range(-120f, 120f);
                    maxSpeed -= rotations.rotationSpeed3;
                } while (maxSpeed < 0);
                nextImpulse = Random.Range(30, 40);
                break;
            case 2:
                do
                {
                    maxSpeed = 270;
                    rotations.rotationSpeed1 = Random.Range(-180f, 180f);
                    maxSpeed -= rotations.rotationSpeed1;
                    rotations.rotationSpeed2 = Random.Range(-180f, 180f);
                    maxSpeed -= rotations.rotationSpeed2;
                    rotations.rotationSpeed3 = Random.Range(-180f, 180f);
                    maxSpeed -= rotations.rotationSpeed3;
                } while (maxSpeed < 0);
                nextImpulse = Random.Range(20, 40);
                break;
        }

        currentTime = nextImpulse;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        Debug.Log(currentTime);

        if (currentTime <= 0)
        {
            if(!loop)
                StartCoroutine(Impulse());
        }

        if (Mathf.Abs(rotations.rotationSpeed1) < 0.1f && Mathf.Abs(rotations.rotationSpeed2) < 0.1f && Mathf.Abs(rotations.rotationSpeed3) < 0.1f)
            EndGame();
    }

    IEnumerator Impulse()
    {
        loop = true;
        int cpt = 5;


        while(cpt > 0)
        {
            impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            impactLight.transform.GetChild(0).GetComponent<Light>().enabled = true;

            yield return new WaitForSeconds(1);

            impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
            impactLight.transform.GetChild(0).GetComponent<Light>().enabled = false;

            yield return new WaitForSeconds(1);

            cpt--;
        }

        speedAddToCurrent = Random.Range(10f, 30f);
        float speedAdd = speedAddToCurrent;

        if (Mathf.Abs(rotations.rotationSpeed1) + speedAdd > 180)
            speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed1);
        rotations.rotationSpeed1 = Random.Range(rotations.rotationSpeed1 - speedAdd, rotations.rotationSpeed1 + speedAdd);
        speedAdd = speedAddToCurrent;
        if (Mathf.Abs(rotations.rotationSpeed2) + speedAdd > 180)
            speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed2);
        rotations.rotationSpeed2 = Random.Range(rotations.rotationSpeed2 - speedAdd, rotations.rotationSpeed2 + speedAdd);
        speedAdd = speedAddToCurrent;
        if (Mathf.Abs(rotations.rotationSpeed3) + speedAdd > 180)
            speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed3);
        rotations.rotationSpeed3 = Random.Range(rotations.rotationSpeed3 - speedAdd, rotations.rotationSpeed3 + speedAdd);

        /*switch (difficulty)
        {
            case 0:
                speedAdd = 20f;
                if (Mathf.Abs(rotations.rotationSpeed1) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed1);
                rotations.rotationSpeed1 = Random.Range(rotations.rotationSpeed1 - speedAdd, rotations.rotationSpeed1 + speedAdd);
                speedAdd = 20f;
                if (Mathf.Abs(rotations.rotationSpeed2) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed2);
                rotations.rotationSpeed2 = Random.Range(rotations.rotationSpeed2 - speedAdd, rotations.rotationSpeed2 + speedAdd);
                speedAdd = 20f;
                if (Mathf.Abs(rotations.rotationSpeed3) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed3);
                rotations.rotationSpeed3 = Random.Range(rotations.rotationSpeed3 - speedAdd, rotations.rotationSpeed3 + speedAdd);
                break;
            case 1:
                speedAdd = 40f;
                if (Mathf.Abs(rotations.rotationSpeed1) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed1);
                rotations.rotationSpeed1 = Random.Range(rotations.rotationSpeed1 - speedAdd, rotations.rotationSpeed1 + speedAdd);
                speedAdd = 40f;
                if (Mathf.Abs(rotations.rotationSpeed2) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed2);
                rotations.rotationSpeed2 = Random.Range(rotations.rotationSpeed2 - speedAdd, rotations.rotationSpeed2 + speedAdd);
                speedAdd = 40f;
                if (Mathf.Abs(rotations.rotationSpeed3) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed3);
                rotations.rotationSpeed3 = Random.Range(rotations.rotationSpeed3 - speedAdd, rotations.rotationSpeed3 + speedAdd);
                break;
            case 2:
                speedAdd = 60f;
                if (Mathf.Abs(rotations.rotationSpeed1) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed1);
                rotations.rotationSpeed1 = Random.Range(rotations.rotationSpeed1 - speedAdd, rotations.rotationSpeed1 + speedAdd);
                speedAdd = 60f;
                if (Mathf.Abs(rotations.rotationSpeed2) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed2);
                rotations.rotationSpeed2 = Random.Range(rotations.rotationSpeed2 - speedAdd, rotations.rotationSpeed2 + speedAdd);
                speedAdd = 60f;
                if (Mathf.Abs(rotations.rotationSpeed3) + speedAdd > 180)
                    speedAdd += 180 - Mathf.Abs(rotations.rotationSpeed3);
                rotations.rotationSpeed3 = Random.Range(rotations.rotationSpeed3 - speedAdd, rotations.rotationSpeed3 + speedAdd);
                break;
        }*/

        impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        impactLight.transform.GetChild(0).GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(3);

        impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        impactLight.transform.GetChild(0).GetComponent<Light>().enabled = false;

        currentTime = nextImpulse;

        loop = false;
    }

    void EndGame()
    {
        Debug.Log("Fin");
    }
}
