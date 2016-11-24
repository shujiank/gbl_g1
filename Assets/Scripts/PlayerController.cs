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
    public Slider vector1;
    public Slider vector2;
    public Text sliderV1text;
    public Text sliderV2text;

    private Vector3 destination;
    private Vector3 newPosition;
    bool moving;
    bool rotating;
    private Rigidbody rb;
    private static int vector1_times;
    private static int vector2_times;
    private Quaternion fixedRotation;
    private float rotationV1;
    private float rotationV2;
    private PDAManager pdaManager;
    
    void initializePDA()
    {
        pdaManager.updateVector1(vector_1.x, vector_1.z);
        pdaManager.updateVector2(vector_2.x, vector_2.z);
        pdaManager.updateVectorEquation(vector1_times, vector2_times);
    }

    public void PlayerMovementV1()
    {
        Debug.Log("Slider value V1: " + vector1.value);
        newPosition = transform.position + (vector1.value * vector_1);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            vector1_times += (int)vector1.value;
        }
        else
        {
            rotating = false;
            destination = transform.position;
        }
    }

    public void PlayerMovementV2()
    {
        Debug.Log("Slider value V2: " + vector2.value);
        newPosition = transform.position + (vector2.value * vector_2);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            destination = newPosition;
            rotating = true;
            vector2_times += (int)vector2.value;
        }
        else
        {
            rotating = false;
            destination = transform.position;
        }
    }

    void sliderV1Value()
    {
        sliderV1text.text = "V1: " + vector1.value.ToString();
    }

    void sliderV2Value()
    {
        sliderV2text.text = "V2: " + vector2.value.ToString();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementCanvas = GameObject.Find("Player/MovementCanvas");
        destination = transform.position;
        moving = false;
        rotating = false;

        rotationV1 = Mathf.Atan2(vector_1.z, vector_1.x) * Mathf.Rad2Deg;
        vector1.transform.rotation = Quaternion.Euler(90, -rotationV1, 0);

        rotationV2 = Mathf.Atan2(vector_2.z, vector_2.x) * Mathf.Rad2Deg;
        vector2.transform.rotation = Quaternion.Euler(90, -rotationV2, 0);

        transform.Translate(Vector3.up * height);
        vector1.onValueChanged.AddListener(delegate { sliderV1Value();});
        vector2.onValueChanged.AddListener(delegate { sliderV2Value(); });

        pdaManager = pda.GetComponent<PDAManager>();
        initializePDA();
    }
    
    void Awake()
    {
        fixedRotation = movementCanvas.transform.rotation;

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
                vector1.value = 0;
                vector2.value = 0;
                sliderV1text.text = "V1: 0";
                sliderV2text.text = "V2: 0";
            }
            pdaManager.updateCurrentPosition(transform.position.x, transform.position.z);
            pdaManager.updateVectorEquation(vector1_times, vector2_times);
        }
    }

    void LateUpdate()
    {
        if (!moving && !rotating)   rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, fixedRotation, turn));
        movementCanvas.transform.rotation = fixedRotation;
    }
}
