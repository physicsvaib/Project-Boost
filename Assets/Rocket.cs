using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {


    Rigidbody rigidBody;
    public AudioSource audio;
    public float thrust = 40;
    public float rotationSpeed = 3  ;



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
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(0,thrust,0);


            if (!audio.isPlaying)
            {
                audio.Play();
            }
            
            
        }
        else
        {
            audio.Stop();
        }

        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.D ))
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        rigidBody.freezeRotation = false;
    }
}
