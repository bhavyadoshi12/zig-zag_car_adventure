using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameStarted;
    public GameObject platformSpawner;


    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject newHighScoreImage;
    public Text g_overScoreText;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText;
    public Text starText;

    int score;
    int bestScore=0, totalDiamond=0, totalStar=0; //oldscorebyrev=0;
    bool countScore;
   

    [Header("for Player")]
    public GameObject[] player;
    Vector3 playerStartPos = new Vector3(0,2,0);
    int selectedCar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //Get Selected Car
        selectedCar = PlayerPrefs.GetInt("SelectCar");
        Instantiate(player[selectedCar], playerStartPos,Quaternion.identity);
    } // Awake

    // Start is called before the first frame update
    void Start()
    {
        
        //play with old Score
        
        if(PlayerPrefs.GetInt("oldscore") !=0)
        {
            score = PlayerPrefs.GetInt("oldscore");
            PlayerPrefs.SetInt("oldscore",0);

        }
        

        //total Diamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();
        //total Star
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();
        //best Score
       bestScore = PlayerPrefs.GetInt("bestScore");
       bestText.text = bestScore.ToString();
        
    }//start

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    } // Update

    public void GameStart()
    {
        isGameStarted = true;
        countScore =true;
        StartCoroutine(UpdateScore());
        if (PlayerPrefs.GetInt("incoming") ==1)
        {
            Debug.Log(score);
            score = PlayerPrefs.GetInt("lastScoreText");
            Debug.Log(score);
        }
        else
        {
            Debug.Log(score);
            score =0;
            Debug.Log(score);
        }
        platformSpawner.SetActive(true);
    }//GameStart

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        PlayerPrefs.SetInt("lastScoreText",score); 
        countScore =false;
        platformSpawner.SetActive(false);
        g_overScoreText.text = score.ToString();
        if(score>bestScore)
        {
             PlayerPrefs.SetInt("bestScore",score);
             newHighScoreImage.SetActive(true);
        }
    }//GameOver

    public void  StartWithScore()
    {
        
        //Debug.Log(oldscorebyrev);
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("incoming",1);
        score = PlayerPrefs.GetInt("lastScoreText");

        Debug.Log(score);
    }

    IEnumerator UpdateScore()
    {
        while (countScore)
        {
            yield return new WaitForSeconds(1f); // Changed 'if' to '1f' assuming 1 second delay
            score++;
            if(score>bestScore)
            {
                scoreText.text = score.ToString();

                bestText.text = score.ToString();

            }
            else
            {
                scoreText.text = score.ToString();
            }
            
        }
    }//UpdateScore
    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
        PlayerPrefs.SetInt("incoming",0);
    }//ReplayGame

    public void GetStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar",newStar);
        starText.text = totalStar.ToString();
    }//GetStar

    public void GetDiamond()
    {
        int newDiamond = totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond",newDiamond);
        diamondText.text = totalDiamond.ToString();
    }//GetStar
    public void gohome()
    {
        SceneManager.LoadScene("ChooseCar");
        score =0;
    }
}
