using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public static int score = 0;
    public static int containersLeft = 1;

    public AudioClip rightSound;
    public AudioClip wrongSound;
    public AudioSource rSound;

    public TextMeshProUGUI finText;

    float time;
    bool isTiming = true;
    float waitTime = 0;
    static bool isNotSaved = true;
    static bool isHighScore = false;
    static bool goToOutput = false;

    static bool scoreInOrder = false;
    static bool timeInOrder = false;

    float highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("time: " + waitTime);
        if (isTiming == true)
        {
            time = time + Time.deltaTime; //time for level
        }
        if (containersLeft == 0 && isNotSaved == true) //end result of level
        {

            isTiming = false;

            finText.text = "Congrats on completing the game!\nYour time was " + time + "\n Your score was " + score;
            waitTime = waitTime + Time.deltaTime;
            if (waitTime < 5f && isHighScore == false) //waits 5 seconds and then saves the high score if there is one and outputs the results
            {

                highScore = (score / time) * 100;


                if (PlayerPrefs.HasKey("hs1") == false)
                {
                    PlayerPrefs.SetFloat("hs1", highScore);
                    isHighScore = true;
                }

                else if (PlayerPrefs.HasKey("hs2") == false && PlayerPrefs.HasKey("hs1"))
                {
                    isHighScore = true;
                    if (PlayerPrefs.GetFloat("hs1") > highScore)
                    {
                        PlayerPrefs.SetFloat("hs2", highScore);
                    }

                    else
                    {
                        PlayerPrefs.SetFloat("hs2", PlayerPrefs.GetFloat("hs1"));
                        PlayerPrefs.SetFloat("hs1", highScore);
                    }

                }

                else if (PlayerPrefs.HasKey("hs3") == false && PlayerPrefs.HasKey("hs1") == true && PlayerPrefs.HasKey("hs2") == true)
                {
                    isHighScore = true;
                    if (PlayerPrefs.GetFloat("hs1") < highScore)
                    {
                        PlayerPrefs.SetFloat("hs3", PlayerPrefs.GetFloat("hs2"));
                        PlayerPrefs.SetFloat("hs2", PlayerPrefs.GetFloat("hs1"));
                        PlayerPrefs.SetFloat("hs1", highScore);
                    }

                    else if (PlayerPrefs.GetFloat("hs1") > highScore && PlayerPrefs.GetFloat("hs2") < highScore)
                    {
                        PlayerPrefs.SetFloat("hs3", PlayerPrefs.GetFloat("hs2"));
                        PlayerPrefs.SetFloat("hs2", highScore);
                    }

                    else
                    {
                        PlayerPrefs.SetFloat("hs3", highScore);
                    }
                }

                else
                {
                    if (PlayerPrefs.GetFloat("hs1") < highScore)
                    {
                        PlayerPrefs.SetFloat("hs3", PlayerPrefs.GetFloat("hs2"));
                        PlayerPrefs.SetFloat("hs2", PlayerPrefs.GetFloat("hs1"));
                        PlayerPrefs.SetFloat("hs1", highScore);

                        isHighScore = true;
                    }

                    else if (PlayerPrefs.GetFloat("hs1") > highScore && PlayerPrefs.GetFloat("hs2") < highScore)
                    {
                        PlayerPrefs.SetFloat("hs3", PlayerPrefs.GetFloat("hs2"));
                        PlayerPrefs.SetFloat("hs2", highScore);

                        isHighScore = true;

                    }

                    else if (PlayerPrefs.GetFloat("hs3") < highScore)
                    {
                        PlayerPrefs.SetFloat("hs3", highScore);

                        isHighScore = true;

                    }
                }
            }

            else{
                if (isHighScore == false && waitTime > 5f)
                {
                    finText.text = "Thank you for playing!!\nThe Leaderboard is:\nHigh Score 1: " + PlayerPrefs.GetFloat("hs1") + "\nHigh Score 2: " + PlayerPrefs.GetFloat("hs2") + "\nHigh Score 3: " + PlayerPrefs.GetFloat("hs3");
                }
                else if (isHighScore == true && waitTime > 5f)
                {
                    if (PlayerPrefs.HasKey("hs2") == false)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nHigh Score 1: " + PlayerPrefs.GetFloat("hs1") + "\nHigh Score 2: " + "N/A" + "\nHigh Score 3: " + "N/A";
                    }
                    else if (PlayerPrefs.HasKey("hs2") == true && PlayerPrefs.HasKey("hs3") == false)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nHigh Score 1: " + PlayerPrefs.GetFloat("hs1") + "\nHigh Score 2: " + PlayerPrefs.GetFloat("hs2") + "\nHigh Score 3: " + "N/A";
                    }
                    else if (PlayerPrefs.HasKey("hs2") == true && PlayerPrefs.HasKey("hs1") == true && PlayerPrefs.HasKey("hs3") == true)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nHigh Score 1: " + PlayerPrefs.GetFloat("hs1") + "\nHigh Score 2: " + PlayerPrefs.GetFloat("hs2") + "\nHigh Score 3: " + PlayerPrefs.GetFloat("hs3");
                    }
                }

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

    