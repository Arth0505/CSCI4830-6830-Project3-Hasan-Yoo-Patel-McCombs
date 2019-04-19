using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //the values in the following 2 if statements are subject to change when we realize what size the boxes will be.
        if(Input.GetKey(KeyCode.S) && this.transform.localScale.y < 10)
        {
            this.transform.localScale += new Vector3(0, 0.1f, 0);
        }

        if(Input.GetKey(KeyCode.W) && this.transform.localScale.y > 3)
        {
            this.transform.localScale += new Vector3(0, -0.1f, 0);
        }

        //below values will need to be changed after the crane is made to final size
        if(Input.GetKey(KeyCode.G) && this.transform.position.z >= 3)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -0.1f);
        }

        //for some reason, this if statement needs the z transform to be +4.0 from the actual coordinate you want to stop at.
        if(Input.GetKey(KeyCode.T) && this.transform.position.z < 10.3)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.1f);
        }
    }
}
