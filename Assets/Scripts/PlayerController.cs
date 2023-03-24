﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private float velocidad = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // There is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We'll move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * forwardInput);
        
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        
        // We turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

/*       
    // Movimiento con las flechas del teclado 
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") / velocidad, 0, Input.GetAxis("Vertical") / velocidad);
    } */

}
