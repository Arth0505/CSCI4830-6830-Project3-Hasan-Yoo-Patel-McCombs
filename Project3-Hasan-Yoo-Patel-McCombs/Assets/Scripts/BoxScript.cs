using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    //box refers to its own rigidbody. For some reason this.rigidbody doesnt want to play nice 
    public Rigidbody box;
    public bool following = false;

    private GameObject Magnet;
    public DropButtonScript dropButton;
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
        if(following)
        {
            if(Input.GetKey(KeyCode.Space))
            {//as soon as the spacebar is pressed, the box stops following. 
                MagnetRelease.Play();
                box.isKinematic = false;
                box.useGravity = true;
                following = false;
            }
            this.transform.position = Magnet.transform.position;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //when the magnet collides with the box, it begins to follow the magnet.
        if(collision.gameObject.name == "Magnet")
        {
            dropButton.container = box;

            MagnetAttach.Play();
            box.isKinematic = true;
            box.useGravity = false;

            following = true;
            Magnet = collision.gameObject;
        }

    }
}