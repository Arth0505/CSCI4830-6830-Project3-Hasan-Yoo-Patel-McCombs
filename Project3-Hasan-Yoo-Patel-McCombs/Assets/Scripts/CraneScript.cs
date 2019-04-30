using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
    public GameObject crane;
    public GameObject rotLever;
    float rPos;

    //Movement sounds work but only for the rotation lever. I don't want to mess anything up so ill leave 
    //it to Thomas to finish implementing the sound for the other levers.
    public AudioSource ConstantSound;
    public AudioSource MovementSound;

    // Start is called before the first frame update
    void Start()
    {
        ConstantSound.Play();
        rPos = rotLever.transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        MovementSound.Stop();
        //rotates the crane itself horizontally at a speed of .5f
        //if(Input.GetKey(KeyCode.A))
        if (rotLever.transform.localRotation.x>rPos+0.05f)
        {
            MovementSound.Play();
            transform.Rotate(0, 1 * +-.5f, 0);
        }

        //if(Input.GetKey(KeyCode.D))
        if (rotLever.transform.localRotation.x < rPos-0.05f)
        {
            MovementSound.Play();
            transform.Rotate(0, 1 * .5f, 0);
        }
    }
}
