﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeamScript : MonoBehaviour
{
    float time;
    float holdTime;

    public GameObject loadText;
    bool isFallen = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*time = time + Time.deltaTime;  
        if (isFallen == true) //waits 2 seconds after level falls to load the next scene
        {
            loadText.SetActive(true);
            if (time - holdTime >= 2f)
            {
                SceneManager.LoadScene("Sorting scene");
            }

        }*/
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Beam") {
            //Reset Scene if it collides with anything
            loadText.SetActive(true);
            StartCoroutine("waitingForTransition");
        }
    }

    IEnumerator waitingForTransition() {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Project3-Hasan-Yoo-Patel-McCombs");
    }
}
