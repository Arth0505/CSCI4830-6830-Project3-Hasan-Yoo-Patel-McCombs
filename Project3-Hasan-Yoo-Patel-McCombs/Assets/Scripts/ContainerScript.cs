using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
	int score = 0;

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
		/*if(collision.gameObject.tag == "green" && gameObject.tag == "greenContainer")
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
        }*/
	
			if (collision.gameObject.tag == gameObject.tag) //correct box placement
			{
				if (gameObject.tag != "noDestroy")
				{
				Debug.Log("Correct box");
				Destroy(collision.gameObject);
				score = score + 1;
				Debug.Log(score);
				}
			}

		else //wrong box placement
		{
			
			if (gameObject.tag != "noDestroy")
			{
				Debug.Log("Wrong box!");
				Destroy(collision.gameObject);
				score = score - 1;
				Debug.Log(score);
			}
		}
    }
}
