using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
	bool following = false;

	private GameObject MagnetPick;
	public GameObject dropButton;
	//public DropButtonScript dropButton;
	public AudioSource MagnetAttach;
	public AudioSource MagnetRelease;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//while the space button hasn't been pressed, the box will continue to follow the magnet.
		if (following)
		{
			if (dropButton.tag == "Drop")
			{//as soon as the spacebar is pressed, the box stops following. 
				MagnetRelease.Play();
				MagnetPick.GetComponent<Rigidbody>().isKinematic = false;
				MagnetPick.GetComponent<Rigidbody>().useGravity = true;
				following = false;
				MagnetPick = null;
			}
			MagnetPick.transform.position = this.transform.position;
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name.IndexOf("Container") >= 0)
		{
			MagnetAttach.Play();
			collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			collision.gameObject.GetComponent<Rigidbody>().useGravity = false;

			following = true;
			MagnetPick = collision.gameObject;
		}
		//when the magnet collides with the box, it begins to follow the magnet.
	}
}