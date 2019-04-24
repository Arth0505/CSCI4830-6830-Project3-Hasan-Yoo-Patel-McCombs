using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (Input.GetKey("up"))
            {
                transform.Rotate(0, 0, .5f);
            }

            if (Input.GetKey("left"))
            {
                transform.Rotate(.5f, 0, 0);
            }

            if (Input.GetKey("right"))
            {
                transform.Rotate(-.5f, 0, 0);
            }

            if (Input.GetKey("down"))
            {
                transform.Rotate(0, 0, -.5f);
            }

            if (Input.GetKey("z"))
            {
                transform.Rotate(0, .5f, 0);
            }

            if (Input.GetKey("x"))
            {
                transform.Rotate(0, -.5f, 0);
            }
        }
        else
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0, 0, .5f);
            }

            if (Input.GetKey("left"))
            {
                transform.Translate(.5f, 0, 0);
            }

            if (Input.GetKey("right"))
            {
                transform.Translate(-.5f, 0, 0);
            }

            if (Input.GetKey("down"))
            {
                transform.Translate(0, 0, -.5f);
            }

            if (Input.GetKey("z"))
            {
                transform.Translate(0, .5f, 0);
            }

            if (Input.GetKey("x"))
            {
                transform.Translate(0, -.5f, 0);
            }
        }
    }
}
