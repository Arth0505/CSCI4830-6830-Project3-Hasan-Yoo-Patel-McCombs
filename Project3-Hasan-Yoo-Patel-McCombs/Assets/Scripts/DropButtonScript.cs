using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropButtonScript : MonoBehaviour
{
    public BoxScript box;
    public AudioSource MagnetRelease;
    public Rigidbody container;
    public GameObject rightHand;
    public GameObject leftHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (box.following && (other.gameObject == rightHand.gameObject || other.gameObject == leftHand.gameObject))
        {
            MagnetRelease.Play();
            container.isKinematic = false;
            container.useGravity = true;
            box.following = false;
        }
    }
}
