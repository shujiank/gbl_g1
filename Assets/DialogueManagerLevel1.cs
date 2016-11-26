using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManagerLevel1 : MonoBehaviour {

    public Text textBox;
    public string[] dialogues;
    int currentlyDisplayingText = 0;
    

    public void Start()
    {
        dialogues = new string[]
        {
            "Greetings Captain!\nI am here to provide you a brief overview of the objective.",
            "You current mission is to command your spacecraft and efficiently utilize the remaining fuel to reach the destination planet.",
            "Personal Data Assistant provides you with information regarding your current location in the multiverse, the location of the destination planet, the directions in which your can maneuver represented by vectors, the number of times you made a maneuver in each direction and the fuel remaining." ,
            "In mathematics, physics, and engineering, a Euclidean vector is a geometric object that has magnitude (or length) and direction. Vectors can be added to other vectors according to vector algebra." ,
            "In vertical representation of vectors, the top element represents the x component and the other represents the y component. For the sake of establishment of relationship, the PDA represents (x, y) co-ordinates using the same notation." ,
            "Maneuvering your spacecraft requires you to input a scalar multiple for the vector in the input box at the tip of the arrow representing the vector and then clicking the 'Go!' button." ,
            "Each move consumes a specific fraction of the fuel. You have enough fuel to make at most 3 inefficient moves." ,
            "You can multiply the vector with negative scalars to negate a previous move. Negative scalar multiplication is not required to reach the destination. It is a provision for you to correct a wrong decision and will be regaded as a indicator of confusion which will subsequently unlock a hint in the journal. Since you have only 3 extra moves to reach destination, you can earn upto 4 hints which successively build up to the final solution." ,
            "You can find all this information logged into your journal.\nBest of luck!"
        };
        StartCoroutine(AnimateText());
    }

    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        if (currentlyDisplayingText >= dialogues.Length)
        {
            gameObject.SetActive(false);
        }
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {
        Debug.Log("Entered Animate");
        for (int i = 0; i < (dialogues[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = dialogues[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
    }
}
