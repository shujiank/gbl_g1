using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private AudioSource sound;
    public float tilt;
    public Boundary boundary;
    public Vector3 vector_1;
    public Vector3 vector_2;
    bool moving;
    public int turn;
    public float height;

    public float speed;

    private Vector3 destination;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        destination = transform.position;
        moving = false;
        transform.Translate(Vector3.up * height);

        //homingCount = 99;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !moving)
        {
            destination = transform.position + vector_1;
            Debug.Log(destination);
            moving = true;
        }
        if (Input.GetButton("Fire2") && !moving)
        {
            destination = transform.position + vector_2;
            Debug.Log(destination);
            moving = true;
        }
        if (Input.GetButton("Fire3") && !moving)
        {
            destination = transform.position - vector_1;
            Debug.Log(destination);
            moving = true;
        }
        if (Input.GetButton("Jump") && !moving)
        {
            destination = transform.position - vector_2;
            Debug.Log(destination);
            moving = true;
        }
    }


    void FixedUpdate()
    {
        if (moving)
        {
            if (Vector3.Distance(destination, transform.position) > 0.12)
            {
                rb.velocity = transform.forward * speed;
                Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
                rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));  // TODO TURN          
            }
            else
            {
                Debug.Log("HALT!!");
                moving = false;
                rb.velocity = transform.forward * 0;
                transform.position = destination;
            }
        }
    }
}
