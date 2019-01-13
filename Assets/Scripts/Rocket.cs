using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {


    Rigidbody rigidBody;
    AudioSource audio;
    public float thrust = 40;
    public float rotationSpeed = 3;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] AudioClip successAudio;

    [SerializeField] ParticleSystem mainEngieParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;



    enum State { alive,dead,Success }
    State state = State.alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
       
        
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
        
    }

    
   




    void getInput()
    {
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
        if (target.gameObject.tag == "Enemy")
        {
            audio.Stop();
            deathParticles.Play();
            state = State.dead;
            audio.Play(); Invoke("deadly", 1f);


        }

        

        if (target.gameObject.tag == "Finish")
        {
            audio.Stop();   
            audio.PlayOneShot(successAudio);
            successParticles.Play();
            state = State.Success;
            audio.Play();
            Invoke("successed", 2f);
        }
        



    }
    void deadly()
    {

        SceneManager.LoadScene("Trainer");
        
    }
    void successed()
    {

        SceneManager.LoadScene("Level 1");
    } 
   
}
