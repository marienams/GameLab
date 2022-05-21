using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed = 10;
    public int upperBound;

    public int lowerBound;

    private Rigidbody playerRb;

    public float boundForce;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * turnSpeed, Space.World);

        boundMovement();

        
    }
     public void boundMovement()
    {
        // Limit player movement, top and bottom of the screen
        if (transform.position.z > upperBound)
        {
            playerRb.AddForce(Vector3.back * boundForce, ForceMode.Impulse);
        }
        else if (transform.position.z < lowerBound)
        {
            playerRb.AddForce(Vector3.forward * boundForce, ForceMode.Impulse);
        }
        // Limit player movement, left and right
        if (transform.position.x > 18)
        {
            transform.position = new Vector3(18, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -18)
        {
            transform.position = new Vector3(-18, transform.position.y, transform.position.z);
        }
    }

}
