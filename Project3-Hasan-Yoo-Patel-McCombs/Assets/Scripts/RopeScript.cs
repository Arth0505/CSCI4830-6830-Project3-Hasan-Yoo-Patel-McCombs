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
        if(Input.GetKey(KeyCode.S) && this.transform.localScale.y < 10)
        {
            this.transform.localScale += new Vector3(0, 0.1f, 0);
        }

        if(Input.GetKey(KeyCode.W) && this.transform.localScale.y > 3)
        {
            this.transform.localScale += new Vector3(0, -0.1f, 0);
        }
    }
}
