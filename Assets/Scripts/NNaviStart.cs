using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NNaviStart : MonoBehaviour
{
    static int i = 0;
    // Use this for initialization
    void Start()
    {
        



    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            i++;
            Debug.Log(i);
            SceneManager.LoadScene(i);

        }
    }
}
