using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class a : MonoBehaviour
{

    private void Start()
    {
        Invoke("fun", 3f);
    }

    void fun()
    {
        
        Debug.Log(6);
        SceneManager.LoadScene(6);
    }
}
