using UnityEngine;

[System.Serializable]
public class SpaceSize
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovementLevel2 : MonoBehaviour
{
    public SpaceSize boundary;
    public float speed;
    int currentNum;
    private Rigidbody rb;

    private Vector3 newPosition;
    private Vector3 movement;
    public GameObject[] modelArray;
    GameObject currentModel;

    public bool canMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentNum = GameInfo.gameState;
        currentModel = Instantiate(modelArray[currentNum], transform.position, transform.rotation) as GameObject;
        currentModel.transform.parent = transform;
        canMove = true;

    }

        void Update()
    {
        if (!canMove)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(GameInfo.gameState+"gameState") ;
        }

        if (currentNum == GameInfo.gameState - 1)
        {
            GameObject thisModel = Instantiate(modelArray[GameInfo.gameState], currentModel.transform.position, currentModel.transform.rotation) as GameObject;
            Destroy(currentModel);
            thisModel.transform.parent = transform;
            currentModel = thisModel;
            currentNum = GameInfo.gameState;
        }
        
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        newPosition = transform.position + (movement * speed * Time.deltaTime);
        if (newPosition.x >= boundary.xMin && newPosition.x <= boundary.xMax &&
            newPosition.z >= boundary.zMin && newPosition.z <= boundary.zMax)
        {
            transform.position = newPosition;
        }
    }
}
