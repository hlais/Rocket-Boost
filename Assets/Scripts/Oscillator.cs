using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {
    [SerializeField] Vector3 movementVector;
    [SerializeField] float oscillationSpeed = 2f;

    Vector3 startingPos;

    // Use this for initialization
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movementFactor = (Mathf.Sin(Time.time * oscillationSpeed)) / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPos + offset;
    }
}

 //   [SerializeField] Vector3 movementVector = new Vector3(10f,10f,10f);

 //   [SerializeField] float period = 2f;

 //   Vector3 startingPosition;

 //   [Range(0, 1)]
 //   [SerializeField]
 //   float movementFactor; // 1 for fully movement, 0 for not moved

	//// Use this for initialization
	//void Start () {

 //       startingPosition = transform.position;


 //   }
	
	//// Update is called once per frame
	//void Update () {

 //       float cycles = Time.time / period;
 //       print(Time.time);

 //       const float tau = Mathf.PI * 2f;
 //       float rawSinWave = Mathf.Sin(cycles * tau);

 //       print(rawSinWave);

 //       movementFactor = rawSinWave / 2 + 0.5f;

 //       Vector3 offset = movementFactor * movementVector;
 //       transform.position = startingPosition + offset;





//    }
//}
