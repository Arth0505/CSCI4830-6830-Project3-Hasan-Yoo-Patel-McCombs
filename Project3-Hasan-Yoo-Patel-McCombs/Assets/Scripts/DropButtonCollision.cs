using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButtonCollision : MonoBehaviour
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
		if (collision.gameObject.name == "hand_right" || collision.gameObject.name == "hand_left")
		{
			this.gameObject.tag = "Drop";
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.name == "hand_right" || collision.gameObject.name == "hand_left")
		{
			this.gameObject.tag = "NoDrop";
		}
	}
}
