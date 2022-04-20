using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject rig1;
    public GameObject rig2;
    public GameObject rig3;
    public float rotationSpeed1 = 1f;
    public float rotationSpeed2 = 1f;
    public float rotationSpeed3 = 1f;

    void Update()
    {
        rig1.transform.Rotate(Vector3.right * rotationSpeed1 * Time.deltaTime);
        rig2.transform.Rotate(Vector3.up * rotationSpeed2 * Time.deltaTime);
        rig3.transform.Rotate(Vector3.right * rotationSpeed3 * Time.deltaTime);
    }
}
