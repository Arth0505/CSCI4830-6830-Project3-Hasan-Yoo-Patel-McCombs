using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
    public GameObject crane;
    public GameObject rotLever;
    float rPos;

    public AudioClip ConstantSound;
    public AudioClip MovementSound;
    public AudioClip MagnetAttach;
    public AudioClip MagnetRelease;
    public AudioSource currentSound;

    // Start is called before the first frame update
    void Start()
    {
        rPos = rotLever.transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rotLever.transform.rotation.x);
        //rotates the crane itself horizontally at a speed of .5f
        //if(Input.GetKey(KeyCode.A))
        if(rotLever.transform.localRotation.x>rPos+0.05f)
        {
            transform.Rotate(0, 1 * +-.5f, 0);
        }

        //if(Input.GetKey(KeyCode.D))
        if (rotLever.transform.localRotation.x < rPos-0.05f)
        {
            transform.Rotate(0, 1 * .5f, 0);
        }
    }
}
