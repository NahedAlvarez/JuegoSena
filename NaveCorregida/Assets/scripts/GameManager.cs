using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject endUI;
    public Text ScoreText;
    public Text ScoreGame;
    public static string Nicknametext;
    public InputField Nicknameinput;
    public GameObject CanvasScore;
    public AudioSource[] AudiosFx;
    public Text nicnameText;


    public int myLevel = 0;
    public Player player;

    public bool getControlOfPlayerAtStart = false;



 
    void Start()
    {
        if (Nicknametext == null)
        Nicknametext = "Nabuconodosor";

        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        if (getControlOfPlayerAtStart)
        {
            player.hasControl = false;
        }
        //If we are at a start level
        if (startUI != null)
        {
            startUI.SetActive(true);
            if (myLevel != 0)
            {
                loadLevel(0);
            }
            Player.Score = 0;
        }
        else
        {
            startGame();
        }
        //If we are at an end level
        if (endUI != null)
        {
            endUI.SetActive(false);
        }

        player.manager = this;
    }
    void Update()
    {
        ScoreText.text = "Tu puntaje Es: " + Player.Score.ToString("0");

        if (nicnameText!=null)
        nicnameText.text = Nicknametext;
    }

    public void Nickname(string textnicname)
    {
        Nicknametext = textnicname;
    }

    /// <summary>
    /// This is called from the UI button
    /// </summary>
    public void startGame()
    {
        if (startUI != null)
        {
            startUI.SetActive(false);

            CanvasScore.SetActive(true);
        }

        player.hasControl = true;
    }

    /// <summary>
    /// This is called when the player ends a level
    /// </summary>
    public void endLevel()
    {
        if (endUI != null)
        {
            CanvasScore.SetActive(false);
            endUI.SetActive(true);
            endUI.gameObject.SetActive(true);
            ScoreText.text = "Tu puntaje Es: " + Player.Score.ToString("0");
            if (myLevel==3)
            {
                ScoreGame.text = "Puntaje final: " + Player.Score.ToString("0");
            }



        }
        else
        {
            loadLevel(myLevel + 1);
        }

    }


    public void loadLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }



}