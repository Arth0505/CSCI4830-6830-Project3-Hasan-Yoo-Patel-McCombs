using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blueCrate;
    public GameObject greenCrate;
    public GameObject orangeCrate;
    public GameObject redCrate;
    public GameObject yellowCrate;
    
    float time = 0;
    float holdTime = 0;

    bool isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

   

        
    }
}
