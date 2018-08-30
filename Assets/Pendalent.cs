using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendalent : MonoBehaviour {

    //what axis we would like to Move. 
    [SerializeField]
    Vector3 movementVector;


    [SerializeField]
    [Range(0, 1)]
    float movementRange;

    float period = 2f;
    Vector3 startingPosition;
	void Start () {

        startingPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        //this value increments

        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period;
      
        //tau is complete circle
        const float tau = Mathf.PI * 2f;

        
        float rawSin = Mathf.Sin(cycles * tau);
        //print("Cycles" + cycles + "Tau"+ tau + "RawSin" +rawSin);

        
        movementRange = rawSin/2f +0.5f;
        
        Vector3 offset =  movementRange * movementVector;
        transform.position = startingPosition + offset;
       
		
	}
}
