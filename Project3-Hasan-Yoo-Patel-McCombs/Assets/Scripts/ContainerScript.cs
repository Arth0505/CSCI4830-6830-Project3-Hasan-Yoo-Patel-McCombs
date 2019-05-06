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
            if (waitTime < 5f) //waits 5 seconds and then saves the high score if there is one and outputs the results
            {
               
                if (PlayerPrefs.HasKey("highScore") == false)
                {
                    isHighScore = true;
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
                    if ((PlayerPrefs.HasKey("highScore2") == false) && (PlayerPrefs.HasKey("highScore3") == false))
                    {
                        PlayerPrefs.SetInt("highScore2", PlayerPrefs.GetInt("highScore"));
                        PlayerPrefs.SetFloat("bestTime2", PlayerPrefs.GetFloat("bestTime"));

                        PlayerPrefs.SetFloat("bestTime", time);
                        PlayerPrefs.SetInt("highScore", score);
                        isHighScore = true;
                    }

                    //if there is a 2nd score and no 3rd score
                    else if ((PlayerPrefs.HasKey("highScore2") == true) && (PlayerPrefs.HasKey("highScore3") == false))
                    {
                        if (PlayerPrefs.GetInt("highScore2") == score)
                        {
                            if (PlayerPrefs.GetFloat("bestTime") < time) 
                            {
                                if(PlayerPrefs.GetFloat("bestTime2") > time)
                                {
                                    PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                                    PlayerPrefs.SetFloat("bestTime3", PlayerPrefs.GetFloat("bestTime2"));

                                    PlayerPrefs.SetInt("highScore2", score);
                                    PlayerPrefs.SetFloat("bestTime2", time);


                                    isHighScore = true;
                                }

                                else if(PlayerPrefs.GetFloat("bestTime2") < time)
                                {
                                    PlayerPrefs.SetInt("highScore3", score);
                                    PlayerPrefs.SetFloat("bestTime3", time);

                                    isHighScore = true;
                                }

                                Debug.Log("1");
                            }
                            else if (PlayerPrefs.GetFloat("bestTime") > time)
                            {
                                PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                                PlayerPrefs.SetFloat("bestTime3", PlayerPrefs.GetFloat("bestTime2"));

                                PlayerPrefs.SetInt("highScore2", PlayerPrefs.GetInt("highScore"));
                                PlayerPrefs.SetFloat("bestTime2", PlayerPrefs.GetFloat("bestTime"));

                                PlayerPrefs.SetInt("highScore", score);
                                PlayerPrefs.SetFloat("bestTime", time);

                                isHighScore = true;

                                Debug.Log("1: " + PlayerPrefs.GetFloat("bestTime"));
                                Debug.Log("2: " + PlayerPrefs.GetFloat("bestTime2"));
                                Debug.Log("3: " + PlayerPrefs.GetFloat("bestTime3"));
                                Debug.Log("2");
                            }
                        }
                    }
                   /* else if (PlayerPrefs.HasKey("highScore3") == true && PlayerPrefs.GetFloat("bestTime3") > time)
                    {
                        PlayerPrefs.SetInt("highscore3", score);
                        PlayerPrefs.SetFloat("bestTime3", time);
                        isHighScore = true;

                        Debug.Log("3");

                        Debug.Log("1: " + PlayerPrefs.GetFloat("bestTime"));
                        Debug.Log("2: " + PlayerPrefs.GetFloat("bestTime2"));
                        Debug.Log("3: " + PlayerPrefs.GetFloat("bestTime3"));
                    }*/
                }

                else if (score == PlayerPrefs.GetInt("highScore") && time > PlayerPrefs.GetFloat("bestTime"))
                {
                    if (PlayerPrefs.HasKey("highScore2") == false && PlayerPrefs.HasKey("highScore3") == false) 
                    {
                        PlayerPrefs.SetInt("highScore2", score);
                        PlayerPrefs.SetFloat("bestTime2", time);
                        isHighScore = true;
                    }

                    else if(PlayerPrefs.HasKey("highScore2") == true && PlayerPrefs.HasKey("highScore3") == false)
                    {
                        if(PlayerPrefs.GetFloat("bestTime2") < time)
                        {
                            PlayerPrefs.SetInt("highScore3", score);
                            PlayerPrefs.SetFloat("bestTime3", time);
                            isHighScore = true;
                        }

                        else if(PlayerPrefs.GetFloat("bestTime2") > time)
                        {
                            PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                            PlayerPrefs.SetFloat("bestTime3", PlayerPrefs.GetFloat("bestTime2"));

                            PlayerPrefs.SetInt("highScore2", score);
                            PlayerPrefs.SetFloat("bestTime2", time);
                            isHighScore = true;
                        }
                    }

                    else if(PlayerPrefs.HasKey("highScore") == true && PlayerPrefs.HasKey("highScore2") == true && PlayerPrefs.HasKey("highScore3") == true)
                    {
                        if(PlayerPrefs.GetFloat("bestTime2") > time)
                        {
                            PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("highScore2"));
                            PlayerPrefs.SetFloat("bestTime3", PlayerPrefs.GetFloat("bestTime2"));

                            PlayerPrefs.SetInt("highScore2", score);
                            PlayerPrefs.SetFloat("bestTime2", time);
                            isHighScore = true;
                        }

                        else if(PlayerPrefs.GetFloat("bestTime3") > time)
                        {
                            PlayerPrefs.SetInt("highScore3", score);
                            PlayerPrefs.SetFloat("bestTime3", time);
                            isHighScore = true;
                        }
                    }
                }

                else if ((score > PlayerPrefs.GetInt("highScore2") && PlayerPrefs.HasKey("highScore2") == true) || (score < PlayerPrefs.GetInt("highScore") && PlayerPrefs.HasKey("highScore2") == false))
                {
                    isHighScore = true;
                    PlayerPrefs.SetFloat("bestTime2", time);
                    PlayerPrefs.SetInt("highScore2", score);
                }

                else if ((score > PlayerPrefs.GetInt("highScore3") && PlayerPrefs.HasKey("highScore3") == true) || (score < PlayerPrefs.GetInt("highScore2") && PlayerPrefs.HasKey("highScore3") == false))
                {
                    isHighScore = true;
                    PlayerPrefs.SetFloat("bestTime3", time);
                    PlayerPrefs.SetInt("highScore3", score);
                }                                         
            }
            else
            {
                if (isHighScore == false)
                {
                    finText.text = "Thank you for playing!!\nThe Leaderboard is:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore") + "\nTime: " + PlayerPrefs.GetFloat("bestTime2") + "\nScore: " + PlayerPrefs.GetInt("highScore2") + "\nTime: " + PlayerPrefs.GetFloat("bestTime3") + "\nScore: " + PlayerPrefs.GetInt("highScore3");
                }
                else if (isHighScore == true)
                {
                    if (PlayerPrefs.HasKey("highScore2") == false)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore") + "\nTime: " + "N/A" + "\nScore: " + "N/A" + "\nTime: " + "N/A" + "\nScore: " + "N/A";
                    }
                    else if (PlayerPrefs.HasKey("highScore2") == true && PlayerPrefs.HasKey("highScore3") == false)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore") + "\nTime: " + PlayerPrefs.GetFloat("bestTime2") + "\nScore: " + PlayerPrefs.GetInt("highScore2") + "\nTime: " + "N/A" + "\nScore: " + "N/A";
                    }
                    else if (PlayerPrefs.HasKey("highScore2") == true && PlayerPrefs.HasKey("highScore") == true && PlayerPrefs.HasKey("highscore3") == true)
                    {
                        finText.text = "Congrats you made it on the Leaderboard!!\nThe Leaderboard is:\nTime: " + PlayerPrefs.GetFloat("bestTime") + "\nScore: " + PlayerPrefs.GetInt("highScore") + "\nTime: " + PlayerPrefs.GetFloat("bestTime2") + "\nScore: " + PlayerPrefs.GetInt("highScore2") + "\nTime: " + PlayerPrefs.GetFloat("bestTime3") + "\nScore: " + PlayerPrefs.GetInt("highScore3");
                    }
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