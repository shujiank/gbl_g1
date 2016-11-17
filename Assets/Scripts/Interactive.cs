using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour {

    public drawExample drawing;

    Vector3 lastMousePosition;

    // Use this for initialization
    void Start () {
	
	}
    void OnMouseDown()
    {
        lastMousePosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        Vector3 distance = Input.mousePosition - lastMousePosition;
        drawing.dragReact(((distance.x / 50) + 0), ((distance.y / 50) + 0));
        //Debug.Log(distance);
    }

    void OnMouseUpAsButton()
    {
        drawing.saveMatrix();
    }
}
