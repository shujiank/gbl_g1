
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
    public Vector3 final_destination;   
    public int turn;
    public float height;
    public float speed;
    public GameObject pda;
    public Transform third_person_camera;
    public GameObject v1_arrow_prefab;
    public GameObject v2_arrow_prefab;
    public GameObject gameWorld;
    public float v1_solution;
    public float v2_solution;

    private Vector3 destination;
    private Vector3 newPosition;
    bool moving;
    bool rotating;
    private Rigidbody rb;
    private float v1_counter;
    private float v2_counter;
    private Quaternion fixedRotation;
    private PDAManager pdaManager;
    private GameObject v1_arrow;
    private GameObject v2_arrow;
    private GameCrontroller gameController;
    private float fuel_remaining;


    void initializePDA()
    {
        pdaManager.updateVector1(vector_1.x, vector_1.z);
        pdaManager.updateVector2(vector_2.x, vector_2.z);
        pdaManager.updateVectorEquation(v1_counter, v1_counter);
        pdaManager.updateFuel(100.0f);
    }

    public void PlayerMovementV1()
    {
        float scalar_multiple = float.Parse(v1_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_1);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            v1_counter += scalar_multiple;
        }
    }

    public void PlayerMovementV2()
    {
        float scalar_multiple = float.Parse(v2_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_2);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            v2_counter += scalar_multiple;
        }
    }

    void initializeVectorArrows()
    {
        v1_arrow = Instantiate(v1_arrow_prefab, 
            transform.position, 
            Quaternion.LookRotation(vector_1) * Quaternion.Euler(0, -90, 0)) as GameObject;
        v1_arrow.GetComponentInChildren<Button>().onClick.AddListener(() => PlayerMovementV1());
        Debug.Log("DSAD " + v1_arrow.GetComponentInChildren<Text>().text);
        v2_arrow = Instantiate(v2_arrow_prefab,
            transform.position ,
            Quaternion.LookRotation(vector_2) * Quaternion.Euler(0, -90, 0)) as GameObject;
        v2_arrow.GetComponentInChildren<Button>().onClick.AddListener(() => PlayerMovementV2());
    }

    void updateVectorArrows()
    {
        v1_arrow.transform.position = transform.position;
        v1_arrow.transform.rotation = Quaternion.LookRotation(vector_1) * Quaternion.Euler(0, -90, 0);
        v2_arrow.transform.position = transform.position;
        v2_arrow.transform.rotation = Quaternion.LookRotation(vector_2) * Quaternion.Euler(0, -90, 0);
        v1_arrow.SetActive(true);
        v2_arrow.SetActive(true);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementCanvas = GameObject.Find("Player/MovementCanvas");
        destination = transform.position;
        moving = false;
        rotating = false;
        pdaManager = pda.GetComponent<PDAManager>();
        gameController = gameWorld.GetComponent<GameCrontroller>();
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
            v1_arrow.SetActive(false);
            v2_arrow.SetActive(false);
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
                fuel_remaining = ((v1_solution + v2_solution) - (v1_counter + v2_counter)) / (v1_solution + v2_solution) * 100;
                if (transform.position == final_destination)
                {
                    gameController.levelComplete();
                }
                if (fuel_remaining <= 0)
                {
                    gameController.gameOver();
                }
            }
            
            pdaManager.updateCurrentPosition(transform.position.x, transform.position.z);
            pdaManager.updateVectorEquation(v1_counter, v2_counter);
            pdaManager.updateFuel(fuel_remaining);

            third_person_camera.transform.position = transform.position + new Vector3(-1.0f, 6.5f, -1.5f);
            
        }
    }
}
