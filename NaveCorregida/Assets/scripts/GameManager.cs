using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    public GameObject startUI;
    public GameObject endUI;
    public Text ScoreText;
    public Text ScoreGame;
	public Text CargarPuntaje;
	public int ComparacionPuntaje;
    public GameObject CanvasScore;
	public float  c=0;
    public float c1 = 0;
    public int i=0;

    public int myLevel=0;
    public Player player;

    public bool getControlOfPlayerAtStart = false;

    

    // Use this for initialization
    void Start () {
        //Used to be able to play directly from play when testing levels
        CanvasScore.SetActive(false);
        if (getControlOfPlayerAtStart)
        {
            player.hasControl = false;
        }
        //If we are at a start level
        if (startUI != null)
        {
            startUI.SetActive(true);
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
        ScoreGame.text = "Score: " + Player.Score;
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
			endUI.gameObject.SetActive(true);
            ScoreText.text = "Tu puntaje Es: " + Player.Score.ToString("0");


            if (i == 0 )
			{
				
				PlayerPrefs.SetFloat ("PlayerScore1", Player.Score);
						
			}
            if (i == 1)
            {

                PlayerPrefs.SetFloat("PlayerScore2", Player.Score);
               
            }
            if (i == 2)
            {

                PlayerPrefs.SetFloat("PlayerScore2", Player.Score);

            }




            i += 1;



        }
        else
        {
            loadLevel(myLevel+1);
        }

    }
    

    public void loadLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
	
	
}
