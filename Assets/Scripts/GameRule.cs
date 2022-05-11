using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    public GameObject gimbalRig;
    public GameObject impactLight;
    public GameObject endScreen;
    public GameObject winText;
    public GameObject looseText;
    public int difficulty = 0;

    Rotation rotations;
    float maxSpeed = 0f;
    float currentTime;
    float currentTimeHealth;
    float timeBeforeCriticalHealth = 30f;
    float nextImpulse = 0;
    float speed;
    float speedAddToCurrent;
    bool loop = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
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
        currentTimeHealth = timeBeforeCriticalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        Debug.Log(currentTime);

        speed = Mathf.Abs(rotations.rotationSpeed1) + Mathf.Abs(rotations.rotationSpeed2) + Mathf.Abs(rotations.rotationSpeed3);

        if (currentTime <= 0)
        {
            if(!loop)
                StartCoroutine(Impulse());
        }

        if(speed > 472.5f)
        {
            currentTimeHealth -= Time.deltaTime;
            if(currentTimeHealth <= 0)
            {
                LooseGame();
            }
        }
        else
        {
            currentTimeHealth = timeBeforeCriticalHealth;
        }

        if (Mathf.Abs(rotations.rotationSpeed1) < 0.1f && Mathf.Abs(rotations.rotationSpeed2) < 0.1f && Mathf.Abs(rotations.rotationSpeed3) < 0.1f)
            WinGame();
    }

    IEnumerator Impulse()
    {
        loop = true;
        int cpt = 5;


        while(cpt > 0)
        {
            impactLight.transform.GetChild(0).GetComponent<AudioSource>().Play();

            impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            impactLight.transform.GetChild(0).GetComponent<Light>().enabled = true;

            yield return new WaitForSeconds(1);

            impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
            impactLight.transform.GetChild(0).GetComponent<Light>().enabled = false;

            yield return new WaitForSeconds(1);

            cpt--;
        }

        switch (difficulty)
        {
            case 0:
                speedAddToCurrent = 10f;
                break;
            case 1:
                speedAddToCurrent = Random.Range(10f, 20f);
                break;
            case 2:
                speedAddToCurrent = Random.Range(10f, 30f);
                break;

        }
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

        impactLight.GetComponent<AudioSource>().Play();

        impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
        impactLight.transform.GetChild(0).GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(3);

        impactLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        impactLight.transform.GetChild(0).GetComponent<Light>().enabled = false;

        currentTime = nextImpulse;

        loop = false;
    }

    void LooseGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        looseText.SetActive(true);
        endScreen.SetActive(true);
        
        Debug.Log("Loose");
    }

    void WinGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        winText.SetActive(true);
        endScreen.SetActive(true);
        
        //Debug.Log("End");
    }
}
