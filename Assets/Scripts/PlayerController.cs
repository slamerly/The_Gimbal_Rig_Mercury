using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rotation rotations;
    float force = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rotations = GetComponent<Rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rotations.rotationSpeed1 += Input.GetAxis("Horizontal") * force * Time.deltaTime;
            if(force < 5f )
                force += 0.1f;
        }
        else
        {
            force = 0;
        }
    }
}
