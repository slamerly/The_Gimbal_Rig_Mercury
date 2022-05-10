using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rotation rotations;
    float forceRig1 = 1f;
    float forceRig2 = 1f;
    float forceRig3 = 1f;

    void Start()
    {
        rotations = GetComponent<Rotation>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Mathf.Abs(rotations.rotationSpeed1) < 181)
            {
                rotations.rotationSpeed1 += Input.GetAxis("Horizontal") * forceRig1 * Time.deltaTime;
                if (forceRig1 < 5f)
                    forceRig1 += 0.5f * Time.deltaTime;
            }
            else
            {
                if (rotations.rotationSpeed1 < 0)
                    rotations.rotationSpeed1 = -180;
                else
                    rotations.rotationSpeed1 = 180;
            }
        }
        else
        {
            forceRig1 = 0;
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            if (Mathf.Abs(rotations.rotationSpeed1) < 181)
            {
                rotations.rotationSpeed2 += Input.GetAxis("Vertical") * forceRig2 * Time.deltaTime;
                if (forceRig2 < 5f)
                    forceRig2 += 0.5f * Time.deltaTime;
            }
            else
            {
                if (rotations.rotationSpeed1 < 0)
                    rotations.rotationSpeed1 = -180;
                else
                    rotations.rotationSpeed1 = 180;
            }
        }
        else
        {
            forceRig2 = 0;
        }

        if (Input.GetAxis("Horizontal2") != 0)
        {
            if (Mathf.Abs(rotations.rotationSpeed1) < 181)
            {
                rotations.rotationSpeed3 += Input.GetAxis("Horizontal2") * forceRig3 * Time.deltaTime;
                if (forceRig3 < 5f)
                    forceRig3 += 0.5f * Time.deltaTime;
            }
            else
            {
                if (rotations.rotationSpeed1 < 0)
                    rotations.rotationSpeed1 = -180;
                else
                    rotations.rotationSpeed1 = 180;
            }
        }
        else
        {
            forceRig3 = 0;
        }
    }
}
