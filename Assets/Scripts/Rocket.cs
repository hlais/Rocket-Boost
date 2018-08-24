using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    //TODO Fix lighting bug
   [SerializeField]
    float rcsThrust = 100f;

    [SerializeField]
    float mainRocketThrust = 100f;

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

        Thrusting();

        Rotating();

    }



    void Rotating()
    {

        rocketRigidBody.freezeRotation = true;
       
        float rotationSpeed = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
           
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        rocketRigidBody.freezeRotation = false; // resume rotation 

    }

    private void Thrusting()
    {
        float thrustSpeed = mainRocketThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidBody.AddRelativeForce(new Vector3(0,1,0) * thrustSpeed);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }
        }
        else
        {

            rocketSound.Stop();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Finish":
                state = State.trascending;
               Invoke("LoadNextLevel",3f);
               
                break;

            case "Friendly":
                
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                    
                break;
        }
         //if (collision.gameObject.CompareTag("Friendly"))
         //{
         //    Debug.Log("hello");

        //}

    }
    void  LoadNextLevel()
    {
       
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevel + 1);
    }
}
