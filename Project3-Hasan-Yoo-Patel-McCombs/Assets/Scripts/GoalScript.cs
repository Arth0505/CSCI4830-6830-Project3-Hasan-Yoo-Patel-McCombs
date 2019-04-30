using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public Transform shippingContainer;
    public GameObject loadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "hipping Container Red") 
        { 
            Destroy(collision.gameObject);
            loadText.SetActive(true);
            StartCoroutine("waitingForTransition");

        }
    }

    IEnumerator waitingForTransition() {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Sorting scene");
    }
}
