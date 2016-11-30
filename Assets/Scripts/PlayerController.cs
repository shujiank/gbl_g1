
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

[System.Serializable]
public class HintLevels
{
    public int hint_1_level;
    public int hint_2_level;
    public int hint_3_level;
    public int hint_4_level;
}

public class UndoData
{
    public String vectorNumber;
    public float multiplier;
    public UndoData(String vectorNum, float multiply)
    {
        vectorNumber = vectorNum;
        multiplier = multiply;
    }
}

public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public HintLevels hintLevels;
    public Vector3 vector_1;
    public Vector3 vector_2;
    public Vector3 final_destination;   
    public int turn;
    public float height;
    public float speed;
    public GameObject pda;
    public GameObject v1_arrow_prefab;
    public GameObject v2_arrow_prefab;
    public GameObject gameWorld;
    public GameObject journal;
    public GameObject DialogueWindow;
    public GameObject undoButton;
    public float v1_solution;
    public float v2_solution;

    private Vector3 destination;
    private Vector3 newPosition;
    System.Diagnostics.Stopwatch watch;
    private int moveCount;
    private int hintsUsed;
    bool moving;
    bool rotating;
    private Rigidbody rb;
    private float backtrack_counter;
    private float v1_multiplier;
    private float v2_multiplier;
    private Quaternion fixedRotation;
    private PDAManager pdaManager;
    private GameObject v1_arrow;
    private GameObject v2_arrow;
    private GameController gameController;
    private float fuel_remaining;
    private JournalManager journalManager;
    private DialogueManagerLevel1 dialogueManagerLevel1;
    private Dictionary<Vector3, UndoData> movementDict;
    private List<Vector3> movementList;
    private UndoData undo;

    void initializePDA()
    {
        pdaManager.updateVector1(vector_1.x, vector_1.z);
        pdaManager.updateVector2(vector_2.x, vector_2.z);
        pdaManager.updateVectorEquation(v1_multiplier, v2_multiplier);
        pdaManager.updateDestination(final_destination.x, final_destination.y);
        pdaManager.updateCurrentPosition(transform.position.x, transform.position.z);
        pdaManager.updateFuel(100.0f);
    }

    public void PlayerMovementV1()
    {
        float scalar_multiple = float.Parse(v1_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_1);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            moveCount += 1;
            destination = newPosition;
            movementList.Add(transform.position);
            rotating = true;
            v1_multiplier += scalar_multiple;
            movementDict.Add(transform.position, new UndoData("V1", scalar_multiple));
        }
    }

    public void PlayerMovementV2()
    {
        float scalar_multiple = float.Parse(v2_arrow.GetComponentInChildren<InputField>().text);
        newPosition = transform.position + (scalar_multiple * vector_2);
        if (newPosition.x <= boundary.xMax && newPosition.x >= boundary.xMin && newPosition.z <= boundary.zMax && newPosition.z >= boundary.zMin)
        {
            moveCount += 1;
            destination = newPosition;
            movementList.Add(transform.position);
            rotating = true;
            v2_multiplier += scalar_multiple;
            movementDict.Add(transform.position, new UndoData("V2", scalar_multiple));
        }
    }

    public void UndoLastAction()
    {
        destination = movementList[movementList.Count - 1];
        undo = movementDict[destination];

        moveCount -= 1;
        rotating = true;
        backtrack_counter += 1;
        checkForHints();

        if (undo.vectorNumber == "V1")  v1_multiplier -= undo.multiplier;
        if (undo.vectorNumber == "V2")  v2_multiplier -= undo.multiplier;

        movementList.Remove(destination);
        movementDict.Remove(destination);
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

    void checkForHints()
    {

        if (backtrack_counter == hintLevels.hint_1_level)
        {
            journalManager.unlockHint(1);
            dialogueManagerLevel1.HintDisplay(1);
            hintsUsed = 1;      
        }
        else if (backtrack_counter == hintLevels.hint_2_level)
        {
            journalManager.unlockHint(2);
            dialogueManagerLevel1.HintDisplay(2);
            hintsUsed = 2;
        }
        else if (backtrack_counter == hintLevels.hint_3_level)
        {
            journalManager.unlockHint(3);
            dialogueManagerLevel1.HintDisplay(3);
            hintsUsed = 3;
        }
        else if (backtrack_counter == hintLevels.hint_4_level)
        {
            journalManager.unlockHint(4);
            dialogueManagerLevel1.HintDisplay(4);
            hintsUsed = 4;
        }
    }

    public Dictionary<string, float> getFinalStats()
    {
        Dictionary<string, float> finalStats = new Dictionary<string, float>();
        watch.Stop();
        finalStats["time taken"] = (watch.ElapsedMilliseconds / 60000); 
        finalStats["number of moves"] = (float) moveCount;
        finalStats["number of hints used"] = (float) hintsUsed;
        finalStats["optimal move count"] = (float) (v1_solution + v2_solution);
        return finalStats;
    }

    void Start()
    {
        watch = System.Diagnostics.Stopwatch.StartNew();
        hintsUsed = 0;
        moveCount = 0;
        v1_multiplier = 0;
        v2_multiplier = 0;
        backtrack_counter = 0;
        fuel_remaining = 100;
        rb = GetComponent<Rigidbody>();
        movementList = new List<Vector3>();
        movementDict = new Dictionary<Vector3, UndoData>();
        if (movementList.Count == 0) undoButton.SetActive(false);
        destination = transform.position;
        moving = false;
        rotating = false;
        pdaManager = pda.GetComponent<PDAManager>();
        gameController = gameWorld.GetComponent<GameController>();
        journalManager = journal.GetComponent<JournalManager>();
        dialogueManagerLevel1 = DialogueWindow.GetComponent<DialogueManagerLevel1>();
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
        if (movementList.Count > 0)
        {
            undoButton.SetActive(true);
        }
        else
        {
            undoButton.SetActive(false);
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
                fuel_remaining = ((v1_solution + v2_solution) - (v1_multiplier + v2_multiplier)) / (v1_solution + v2_solution) * 100;
                if (fuel_remaining <= 0)
                {
                    gameController.GameOver();
                }           
            }
            
            pdaManager.updateCurrentPosition(transform.position.x, transform.position.z);
            pdaManager.updateVectorEquation(v1_multiplier, v2_multiplier);
            pdaManager.updateFuel(fuel_remaining);            
        }
    }
}
