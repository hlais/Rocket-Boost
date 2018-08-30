using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendalent : MonoBehaviour {

    //what axis we would like to move. 
    [SerializeField]
    Vector3 movementVector = new Vector3(10f, 10f, 10f);//this needs to be Assigned

    float movementRange;

    [SerializeField]
    float movementSpeed = 2f;
    Vector3 startingPosition;
	void Start () {

        startingPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        //this value increments

        if (movementSpeed <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time/ movementSpeed;
      
        //tau is complete circle
        const float tau = Mathf.PI * 2f;

        float rawSin = Mathf.Sin(cycles * tau);
         print("Cycles" + cycles + "Tau"+ tau + "RawSin" +rawSin);
         movementRange = rawSin/2f +0.5f;

         Vector3 offset =  movementRange * movementVector;
        transform.position = startingPosition + offset;

	}
}
