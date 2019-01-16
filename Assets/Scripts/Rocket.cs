using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {


    Rigidbody rigidBody;
    AudioSource audio;
    public float thrust = 45;
    public float rotationSpeed = 8;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] AudioClip successAudio;
    [SerializeField] bool canDie;
    [SerializeField] ParticleSystem mainEngieParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;
    static int level = 1;


    enum State { alive,dead,Success }
    State state = State.alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        canDie = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
        if (Input.GetKeyDown(KeyCode.C))
        {
            canDie = !canDie;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            SceneManager.LoadScene(level);
        }

    }

    
   




    void getInput()
    {
        rigidBody.AddForce(0, -5, 0);
        if (Input.GetKey(KeyCode.Space) && state != State.dead && state != State.Success)
        {
            rigidBody.AddRelativeForce(0,thrust,0);


            if (!audio.isPlaying)
            {
                audio.PlayOneShot(mainEngine);
                mainEngieParticles.Play();

            }


        }
        else
        {
            audio.Stop();
            mainEngieParticles.Stop();  
        }

        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.D) && state != State.dead && state != State.Success)
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.A) && state != State.dead && state != State.Success)
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        rigidBody.freezeRotation = false;
    }


    private void OnCollisionEnter(Collision target)
    {
        if (canDie)
        {
            if (target.gameObject.tag == "Enemy")
            {
                audio.Stop();
                Debug.Log(level + "was");
                deathParticles.Play();
                state = State.dead;
 

                audio.Play(); Invoke("deadly", 1f);


            }

        }

            if (target.gameObject.tag == "Finish")
            {
                audio.Stop();
                
                Debug.Log(level);
                audio.PlayOneShot(successAudio);
                successParticles.Play();
                state = State.Success;
                audio.Play();
                Invoke("successed", 2f);
            }


        

    }
    void deadly()
    {

        SceneManager.LoadScene(level);
        
    }
    void successed()
    {
        level += 1;
        Debug.Log(level + "is ");
        SceneManager.LoadScene(level);
    } 
   
}
