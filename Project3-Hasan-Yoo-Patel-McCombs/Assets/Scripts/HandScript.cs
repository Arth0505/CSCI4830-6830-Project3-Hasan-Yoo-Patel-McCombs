using System.Collections;
using System.Collections.Generic;
using OVR;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag == "Lever")
		{
			if (this.gameObject.name == "hand_right")
			{
				OVRInput.SetControllerVibration(.2f, .6f, OVRInput.Controller.RTouch);
			}
			else if (this.gameObject.name == "hand_left")
			{
				OVRInput.SetControllerVibration(.2f, .6f, OVRInput.Controller.LTouch);

			}
		}
		
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Lever")
		{
			if (this.gameObject.name == "hand_right")
			{
				OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
			}
			else if (this.gameObject.name == "hand_left")
			{
				OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.LTouch);

			}
		}
	}
}
