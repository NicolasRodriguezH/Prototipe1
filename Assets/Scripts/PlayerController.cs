using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    [SerializeField] float velocidad;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private const float turnSpeed = 75.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    // [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI spedoometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    //[SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // There is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //if(IsOnGround())
        //{
            // We'll move the vehicle forward
            // transform.Translate(Vector3.forward * Time.deltaTime * velocidad * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        
            // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        
            // We turn the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            velocidad = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // for kph, change 2.237f for 3.6
            spedoometerText.SetText("Speed: " + velocidad + "mph");

            rpm = (velocidad % 30) * 40;
            rpmText.SetText("RPM: " + rpm);
        //}
    }

    //bool IsOnGround()
    //{
    //    wheelsOnGround = 0;
    //    foreach (WheelCollider wheel in allWheels)
    //    {
    //        if (wheel.isGrounded)
    //        {
    //            wheelsOnGround++;
    //        }
    //    }
    //    if (wheelsOnGround == 4)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

/*       
    // Movimiento con las flechas del teclado 
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") / velocidad, 0, Input.GetAxis("Vertical") / velocidad);
    } */

}

