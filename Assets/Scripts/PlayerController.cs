
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public Vector3 vector_1;
    public Vector3 vector_2;    
    public int turn;
    public float height;
    public float speed;
    public GameObject pda;
    public GameObject movementCanvas;
    //public Slider vector1;
    //public Slider vector2;
    public Text sliderV1text;
    public Text sliderV2text;
    public Transform third_person_camera;
    public GameObject v1_arrow_prefab;
    public GameObject v2_arrow_prefab;

    private Vector3 destination;
    private Vector3 newPosition;
    bool moving;
    bool rotating;
    private Rigidbody rb;
    private int vector_1_counter;
    private int vector_2_counter;
    private Quaternion fixedRotation;
    private float rotationV1;
    private float rotationV2;
    private PDAManager pdaManager;
    private GameObject vector_1_arrow;
    private GameObject vector_2_arrow;


    void initializePDA()
    {
        pdaManager.updateVector1(vector_1.x, vector_1.z);
        pdaManager.updateVector2(vector_2.x, vector_2.z);
        pdaManager.updateVectorEquation(vector_1_counter, vector_1_counter);
    }

    public void PlayerMovementV1()
    {
        int scalar_multiple = Int32.Parse(vector_1_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_1);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            vector_1_counter += scalar_multiple;
        }
    }

    public void PlayerMovementV2()
    {
        int scalar_multiple = Int32.Parse(vector_2_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_2);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            vector_2_counter += scalar_multiple;
        }
    }

    void initializeVectorArrows()
    {
        vector_1_arrow = Instantiate(v1_arrow_prefab, 
            transform.position, 
            Quaternion.LookRotation(vector_1) * Quaternion.Euler(0, -90, 0)) as GameObject;
        vector_1_arrow.GetComponentInChildren<Button>().onClick.AddListener(() => PlayerMovementV1());
        Debug.Log("DSAD " + vector_1_arrow.GetComponentInChildren<Text>().text);
        vector_2_arrow = Instantiate(v2_arrow_prefab,
            transform.position ,
            Quaternion.LookRotation(vector_2) * Quaternion.Euler(0, -90, 0)) as GameObject;
        vector_2_arrow.GetComponentInChildren<Button>().onClick.AddListener(() => PlayerMovementV2());
    }

    void updateVectorArrows()
    {
        vector_1_arrow.transform.position = transform.position;
        vector_1_arrow.transform.rotation = Quaternion.LookRotation(vector_1) * Quaternion.Euler(0, -90, 0);
        vector_2_arrow.transform.position = transform.position;
        vector_2_arrow.transform.rotation = Quaternion.LookRotation(vector_2) * Quaternion.Euler(0, -90, 0);
        vector_1_arrow.SetActive(true);
        vector_2_arrow.SetActive(true);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementCanvas = GameObject.Find("Player/MovementCanvas");
        destination = transform.position;
        moving = false;
        rotating = false;
        pdaManager = pda.GetComponent<PDAManager>();
        initializePDA();
        initializeVectorArrows();        
    }

    void Update()
    {
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
            vector_1_arrow.SetActive(false);
            vector_2_arrow.SetActive(false);
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
                updateVectorArrows();
            }
            
            pdaManager.updateCurrentPosition(transform.position.x, transform.position.z);
            pdaManager.updateVectorEquation(vector_1_counter, vector_2_counter);
            third_person_camera.transform.position = transform.position + new Vector3(-1.0f, 6.5f, -1.5f);
            
        }
    }

    /**void LateUpdate()
    {
        if (!moving && !rotating)   rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, fixedRotation, turn));
        movementCanvas.transform.rotation = fixedRotation;
    }**/
}
