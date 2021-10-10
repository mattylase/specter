using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Specter;

public class CubeController : MonoBehaviour
{
    Rigidbody body;
    float force = 1f;
    float jumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            GetComponent<SpecterCapture>().BeginCapture();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            var result = GetComponent<SpecterCapture>().StopCapture();
            Debug.Log("Got a stack of " + result.Frames.Count + " frames!");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector3.forward * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-Vector3.forward * force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(-Vector3.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.right * force);
        }
    }
}
