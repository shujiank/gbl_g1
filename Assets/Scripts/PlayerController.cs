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
    bool rotating;
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
        rotating = false;
        transform.Translate(Vector3.up * height);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !rotating && !moving)
        {
            destination = transform.position + vector_1;                      
        }
        if (Input.GetButton("Fire2") && !rotating && !moving)
        {
            destination = transform.position + vector_2;
        }
        if (Input.GetButton("Fire3") && !rotating && !moving)
        {
            destination = transform.position - vector_1;
        }
        if (Input.GetButton("Jump") && !rotating && !moving)
        {
            destination = transform.position - vector_2;
        }
        if (destination != transform.position && destination.x > 0 
            && destination.z > 0 && destination.x < 10.0 && destination.z < 10.0)
        {
            rotating = true;
        }
    }


    void FixedUpdate()
    {
        if (rotating)
        {
            float angle = 5;
            if (Vector3.Angle(transform.forward, destination - transform.position) > angle)
            {
                Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
                rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));  
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(destination - transform.position);
                moving = true;
                rotating = false;
            }
        }

        if (moving)
        {            
            if (Vector3.Distance(destination, transform.position) > 0.12)
            {
                rb.velocity = transform.forward * speed;
            }
            else
            {
                moving = false;
                rb.velocity = transform.forward * 0;
                transform.position = destination;
            }                      
        }
    }
}
