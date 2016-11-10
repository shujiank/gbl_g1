using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

[System.Serializable]
public class HUD
{
    public TextMesh current_x;
    public TextMesh current_y;
    public TextMesh vector_1_display_x;
    public TextMesh vector_1_display_y;
    public TextMesh vector_2_display_x;
    public TextMesh vector_2_display_y;
    public TextMesh equation_vector1;
    public TextMesh equation_vector2;
}


public class PlayerController : MonoBehaviour
{
    public float tilt;
    public Boundary boundary;
    public Vector3 vector_1;
    public Vector3 vector_2;    
    public int turn;
    public float height;
    public float speed;
    public HUD hud;    

    private Vector3 destination;
    bool moving;
    bool rotating;
    private Rigidbody rb;
    private int vector1_times = 0;
    private int vector2_times = 0;
    
    void initializeHUD()
    {
        hud.vector_1_display_x.text = ((int)vector_1.x).ToString();
        hud.vector_1_display_y.text = ((int)vector_1.z).ToString();
        hud.vector_2_display_x.text = ((int)vector_2.x).ToString();
        hud.vector_2_display_y.text = ((int)vector_2.z).ToString();
        hud.equation_vector1.text = vector1_times.ToString();
        hud.equation_vector2.text = vector2_times.ToString();
    }   


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destination = transform.position;
        moving = false;
        rotating = false;
        transform.Translate(Vector3.up * height);
        initializeHUD();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && !rotating && !moving)
        {
            destination = transform.position + vector_1;
            vector1_times += 1;
        }
        if (Input.GetButton("Fire2") && !rotating && !moving)
        {
            destination = transform.position + vector_2;
            vector2_times += 1;
        }
        if (Input.GetButton("Fire3") && !rotating && !moving)
        {
            destination = transform.position - vector_1;
            vector1_times -= 1;
        }
        if (Input.GetButton("Jump") && !rotating && !moving)
        {
            destination = transform.position - vector_2;
            vector2_times -= 1;
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
            hud.current_x.text = ((int) transform.position.x).ToString();
            hud.current_y.text = ((int) transform.position.z).ToString();
            hud.equation_vector1.text = vector1_times.ToString() + "V1";
            hud.equation_vector2.text = vector2_times.ToString() + "V2";
        }
    }
}
