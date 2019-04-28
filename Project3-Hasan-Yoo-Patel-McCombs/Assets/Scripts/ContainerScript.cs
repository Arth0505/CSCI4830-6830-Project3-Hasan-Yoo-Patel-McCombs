using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public static int score = 0;
    public static int containersLeft = 9;

    public AudioClip rightSound;
    public AudioClip wrongSound;
    public AudioSource rSound;

    public TextMeshProUGUI finText;

    float time;
    bool isTiming = true;
    float waitTime = 0;
    bool isNotSaved = true;
    static bool isHighScore = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming == true)
        {
            time = time + Time.deltaTime; //time for level
        }
        if (containersLeft == 0 && isNotSaved == true) //end result of level
        {
            isTiming = false;

            finText.text = "Congrats on completing the game!\nYour time was " + time + "\n Your score was " + score;
            waitTime = waitTime + Time.deltaTime;
            if (waitTime >= 5f) //waits 5 seconds and then saves the high score if there is one and outputs the results
            {
                

                if (PlayerPrefs.HasKey("highScore") == false)
                {
                    isHighScore = true;
                    Debug.Log("Here1");
                    PlayerPrefs.SetFloat("bestTime", time);
                    PlayerPrefs.SetInt("highScore", score);

                }
                else if (score > PlayerPrefs.GetInt("highScore"))
                {
                    isHighScore = true;
                    PlayerPrefs.SetFloat("bestTime", time);
                    PlayerPrefs.SetInt("highScore", score);


                }
                else if (score == PlayerPrefs.GetInt("highScore") && time < PlayerPrefs.GetFloat("bestTime"))
                {
                    isHighScore = true;
                    PlayerPrefs.SetFloat("bestTime", time);
                    PlayerPrefs.SetInt("highScore", score);

                }               
                    if (isHighScore == false)
                    {
                        finText.text = "Thank you for playing!!\nThe High Score is:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore");
                    }
                    else
                    {
                        finText.text = "You beat the High Score!!\nThe High Score is now:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore");
                    }
                
                isNotSaved = false;
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag) //correct box placement
        {

            if (collision.gameObject.tag != "noDestroy")
            {
                // collision.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(collision.gameObject);
                rSound.PlayOneShot(rightSound);
                score = score + 1;
                containersLeft = containersLeft - 1;
            }

        }

        else //wrong box placement
        {

            if (collision.gameObject.tag != "noDestroy")
            {
                // collision.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(collision.gameObject);
                rSound.PlayOneShot(wrongSound);
                score = score - 1;
                containersLeft = containersLeft - 1;
            }

        }
    }
}