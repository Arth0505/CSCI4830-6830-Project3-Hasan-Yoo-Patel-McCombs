using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public Transform Move1;
    public Transform Move2;
    public GameObject vertLever;
    public GameObject fbLever;
    float speed = 3f;
    float vPos;
    float fbPos;
    // Start is called before the first frame update
    void Start()
    {
        vPos = vertLever.transform.localRotation.x;
        fbPos = fbLever.transform.localRotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        float updateStep = speed * Time.deltaTime;
        //the values in the following 2 if statements are subject to change when we realize what size the boxes will be.
        //if(Input.GetKey(KeyCode.S) && this.transform.localScale.y < 5.5)
        if (vertLever.transform.localRotation.x > vPos+0.05f && this.transform.localScale.y < 5.5) // tenative usage of physics to see if this will work
        {
            this.transform.localScale += new Vector3(0, 0.0125f, 0);
        }

        //if(Input.GetKey(KeyCode.W) && this.transform.localScale.y > 2)
        if (vertLever.transform.localRotation.x < vPos-0.05f && this.transform.localScale.y > 2)    //// tenative usage of physics to see if this will work
        {
            this.transform.localScale += new Vector3(0, -0.0125f, 0);
        }

        //below values will need to be changed after the crane is made to final size
        //if(Input.GetKey(KeyCode.G))
        if(fbLever.transform.localRotation.x < fbPos-0.05f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Move1.position, updateStep);    
        }

        //for some reason, this if statement needs the z transform to be +4.0 from the actual coordinate you want to stop at.
        //if(Input.GetKey(KeyCode.T))
        if (fbLever.transform.localRotation.x > fbPos+0.05f)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Move2.position, updateStep);   
        }
    }
}
