using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "green" && gameObject.tag == "greenContainer")
        {
            Destroy(collision.gameObject, 1);
        }

        if (collision.gameObject.tag == "blue" && gameObject.tag == "blueContainer")
        {
            Destroy(collision.gameObject, 1);
        }

        if (collision.gameObject.tag == "red" && gameObject.tag == "redContainer")
        {
            Destroy(collision.gameObject, 1);
        }

        if (collision.gameObject.tag == "yellow" && gameObject.tag == "yellowContainer")
        {
            Destroy(collision.gameObject, 1);
        }

        if (collision.gameObject.tag == "orange" && gameObject.tag == "orangeContainer")
        {
            Destroy(collision.gameObject, 1);
        }
    }
}
