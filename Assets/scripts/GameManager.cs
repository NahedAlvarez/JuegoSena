using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    int c;
    public GameObject startUI;
    public GameObject endUI;

    public Text ScoreText;
    public Text ScoreGame;

    public GameObject CanvasScore;
  
    public InputField nicknameinputfield;
    public string nameUser;

    public int myLevel = 0;
    public Player player;

    public bool getControlOfPlayerAtStart = false;



 
    void Start()
    {
        //Se inicializa un contador para la leaderboard esto se usa para que pueda enviar una sola vez los datos 
        c = 0;
        //esto se hace para que no reporte como null ni genere error se especifica el uso de la pantalla final y la pantalla inicial y crear los procedimiento que deven seguir 
        if (endUI != null)
        {
            //al comienzo el final de pantalla si es diferenta a null se desactiva 
            endUI.SetActive(false);
        }
        //este condicional  se usa para que en el menu inicial no se mueva la nave 
        if (getControlOfPlayerAtStart)
        {
            //se le quita el control del player en el menu inicial del juego 
            player.hasControl = false;
        }
      
        if (startUI != null)
        {
            //se activa el menu inicial  si es diferente a null 
            startUI.SetActive(true);
            //Se inicial el score en 0 
            Player.Score = 0;
        }
        else
        { 
            // se llama la 
            startGame();
        }
        


        player.manager = this;
    }

    void Update()
    {

        ScoreText.text = "Tu puntaje es " + Player.Score.ToString("0");
        if (nicknameinputfield != null)
        {
            nameUser = nicknameinputfield.text;
        }
        
    }
    public void ContinueButtonMethod()
    {
        loadLevel(Player.theLevel);
    }





    public void ReStar()
    {

        loadLevel(0);

    }


   public void startGame()
    {
        if (startUI != null)
        {
            //desactivo el menu inicial 
            startUI.SetActive(false);
            //Activo el canvas de interactividad
            CanvasScore.SetActive(true);
            //my level= 0;
            myLevel = 0;
            
        }
        //le doy el control al jugador 
        player.hasControl = true;
    }

   //creo una variable puntaje ya que mi puntaje es lo que avanzo en z pero al final el player sigue hacia el infinito el puntaje sigue avanzando 
   //utilizo esta variable para enviar puntaje al laederboard al final pero el puntaje que tiene al cruzar al final 
    float Puntaje;

    public void endLevel()
    {
    

        if (endUI != null)
        {
            //desactivo interactividad canvas  al final 
            CanvasScore.SetActive(false);
            //activo el final canvas  
            endUI.SetActive(true);
            endUI.gameObject.SetActive(true);
            //Tomo el puntaje puntaje y lo paso a la pantalla final 
            ScoreGame.text =  Player.Score.ToString("0");
           
            //igualo puntaje al player score en este momento 
            Puntaje = Player.Score;
        }
        else
        {
            //si no hay pantalla final carga un nivel 
            loadLevel(myLevel + 1);
        }

    }


    public void NombreJugador()
    {
        if (c==0)
        {
            //se envia el name User y el puntaje y se le aumenta el contador para que solo se envvie una vez 
            GetComponent<Score>().CheckeandoLosScores(Puntaje, nameUser);
            c++;
        }
       
    }


    public void loadLevel(int level)
    {
        //Este metodo cambia la escena con un argumento tipo int llamado level
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }



}