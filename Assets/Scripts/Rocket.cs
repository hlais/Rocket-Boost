﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    //TODO Fix lighting bug
   [SerializeField]
    float rcsThrust = 100f;

    [SerializeField]
    float mainRocketThrust = 100f;

    [SerializeField]
    AudioClip mainEngine;
    [SerializeField]
    AudioClip deathExplosion;
    [SerializeField]
    AudioClip jingle;

    [SerializeField]
    ParticleSystem rocketThrust;
    [SerializeField]
    ParticleSystem levelCompleteEffect;
    [SerializeField]
    ParticleSystem deadthParticleEffect;

    [SerializeField] float levelLoadDelay = 2f;

    bool isCollisionOn = true;

    AudioSource rocketSound;
    Rigidbody rocketRigidBody;

    enum State {live,  trascending,dying };
    State state = State.live;
    // Use this for initialization
    void Start()
    {

        rocketRigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == State.live)
        {
            RespondToThrustInput();

            Rotating();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SuccessSequence();
        }
        if (Debug.isDebugBuild)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log(isCollisionOn);
                isCollisionOn = !isCollisionOn;
            }
        }

    }



    void Rotating()
    {


        rocketRigidBody.angularVelocity = Vector3.zero; // remove phsics due to rotation
       
        float rotationSpeed = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
           
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

      

    }

    private void RespondToThrustInput()
    {
        
        if (Input.GetKey(KeyCode.Space) )
        {
            RespondToRotateInput();
            rocketThrust.Play();
        }
        else
        {

            rocketSound.Stop();
            rocketThrust.Stop();
           
        }

    }

    private void RespondToRotateInput()
    {
        float thrustSpeed = mainRocketThrust * Time.deltaTime;
        rocketRigidBody.AddRelativeForce(new Vector3(0, 1, 0) * thrustSpeed);
        if (!rocketSound.isPlaying)
        {
            rocketSound.PlayOneShot(mainEngine);
            


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.live || !isCollisionOn)
        {
            return;
        }

      
            switch (collision.gameObject.tag)
            {
                case "Finish":

                    SuccessSequence();



                    break;

                case "Friendly":

                    break;
                default:
                    DyingSequence();


                    break;

            
        }
         //if (collision.gameObject.CompareTag("Friendly"))
         //{
         //    Debug.Log("hello");

        //}

    }

    private void DyingSequence()
    {
        state = State.dying;
        rocketSound.Stop();
        rocketSound.PlayOneShot(deathExplosion);
        deadthParticleEffect.Play();


        Invoke("LoadPreviousLevel", levelLoadDelay);
    }

    private void SuccessSequence()
    {
        state = State.trascending;
        rocketSound.Stop();
        rocketSound.PlayOneShot(jingle);
        levelCompleteEffect.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void  LoadNextLevel()
    {
        
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel !=  SceneManager.sceneCountInBuildSettings -1)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
        
          

    }
    void LoadPreviousLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
            SceneManager.LoadScene(0);

    }
}
