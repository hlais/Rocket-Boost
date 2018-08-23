using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    
    AudioSource rocketSound;
    Rigidbody rocketRigidBody;
	// Use this for initialization
	void Start () {

        rocketRigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {


        ControllerInputs();
		
	}



    void ControllerInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rocketRigidBody.AddRelativeForce(Vector3.up);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }
            else rocketSound.Stop();
        }



        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
      
    }
    
}
