﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource sound;
    public float tilt;
    public Boundary boundary;
    public Vector3 vector_1;
    public Vector3 vector_2;
    bool moving;
    public int turn;

    public float speed;

    private Vector3 destination;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        destination = transform.position;
        moving = false;

        //homingCount = 99;
    }

    void Update ()
    {
        if (Input.GetButton("Fire1") && !moving)
        {
            Debug.Log("FIRE 1");
            destination = transform.position + vector_1;
            Debug.Log(destination);
            moving = true;
        }
        if (Input.GetButton("Fire2") && !moving)
        {
            Debug.Log("FIRE 2");
            destination = transform.position + vector_2;
            Debug.Log(destination);
            moving = true;
        }
    }

    void move(Vector3 vector)
    {
        
    }

    void FixedUpdate ()
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