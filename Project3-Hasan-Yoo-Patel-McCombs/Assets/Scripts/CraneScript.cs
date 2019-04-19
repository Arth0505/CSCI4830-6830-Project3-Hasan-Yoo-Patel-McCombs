using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
    public GameObject crane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotates the crane itself horizontally at a speed of .5f
        if(Input.GetKey(KeyCode.A))
        {
            crane.transform.Rotate(0, Input.GetAxis("Horizontal") * +.5f, 0);
        }

        if(Input.GetKey(KeyCode.D))
        {
            crane.transform.Rotate(0, -Input.GetAxis("Horizontal") * -.5f, 0);
        }
    }
}
