using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static float Score = 0;

    public Slider LifeSlider;


    public static int theLevel=0;

    public AudioManagerFx reproductorAudio;

    static public int life=100;
    static public int maxLife = 100;
    static public int minLife = 0;

  
    public float turnSpeed = 1;
    public float MaxPlaneRotationDegrees = 45;

    public float maxSpeed = 10;
    public float acceleration = 1;

    protected float currentSpeed = 0;
    public GameObject AudioManagerMusic;
    

    protected Transform plane;

    protected FollowTarget[] followers;

    public float secondsOnEnd = 2;
    public bool hasControl = true;

    protected Vector3 initialPos;

    public LayerMask stopMask;


    public GameObject particlesPrefab;
    public float secondsWaitingOnDeath = 3;
    public GameManager manager;
    public GameObject Gamemanager;

  
    

   
    void Start()
    {
        //Especifico el tiempo que debe tener al iniciar la partida.
        Time.timeScale = 1;

        //defino el maximo de vida que puedo tener en el slider.
        LifeSlider.maxValue = maxLife;
        //utilizo la variable de tipo vector la cual unity me pidio que protegiera la inicializo guardando la primera posicion del player 
        initialPos = transform.position;
        //Plane es igual al transform de el hijo  gameObJECT PLAYER en el cual Player es un objeto vasio que contiene la nave la arma dispara lasers 
        plane = transform.GetChild(0);
        //followers son la camara y el horizonte.
        followers = FindObjectsOfType<FollowTarget>();
    }

   
    void Update()
    {
        //mando la informacion al lifeslider para actualizarlo con la vida en el update
        LifeSlider.value = life;
        //hago un condicional para saber cuando el personaje muere
        if (life<0)
        {
            //llamo una corrutina que contiene el proceso de el respawn 
            StartCoroutine(Respawn());
        }

        //si vida es mayor a la vida maxima 
        if (life > maxLife)
        {
        // vida va a ser igual a vida maxima este condicional se usa para que no pueda obtener mas vida de la maxima
            life = maxLife;
        }
        if (life <= minLife)
        {
        //esto se hace para que la vida minima siempre sea 0
            life = minLife;

        }


        //Esta variable has control de tipo bool se utiliza para controlar cuando el personaje se puede mover
        if (hasControl)
        {
            // currentSpeed es la variable que controla el avanze hacia adelante aceleracion se multiplica por Time delta time.
            currentSpeed += Time.deltaTime * acceleration;
            //Esto condicional se usa para mantener una velocidad estable frame por frame
            if (currentSpeed > maxSpeed)
            {
                //se iguala la velocidad a la maxima velocidad
                currentSpeed = maxSpeed;
               
            }

            //esta variable llama al metodo para moverse hacia los lados horizontal.
            var horiz = Input.GetAxis("Horizontal");
            //se cambia la posicion segun lo que mande horiz 
            var direction = (transform.right * turnSpeed * horiz * Time.deltaTime).normalized;

  
            //se lanza un rayo hacia donde se vaya el personaje para comprobar la posicion
            if (!Physics.Raycast(transform.position, direction, turnSpeed *  Time.deltaTime + 0.5f, stopMask))
            {
                transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;
            }


            //aqui se aplica el efecto que hace la nave al moverse que se inclina hacia donde uno  toa
            var r = plane.rotation.eulerAngles;
            r.z = Mathf.Lerp(-MaxPlaneRotationDegrees, MaxPlaneRotationDegrees, (-horiz + 1) / 2);

            plane.rotation = Quaternion.Lerp(plane.rotation, Quaternion.Euler(r), 0.1f);
        }


       //Esto le indica a nuestra nave que siempre vaya hacia adelante 
        transform.position = transform.position + transform.forward * Time.deltaTime * currentSpeed;
        //le sumo al score la posicion de z para valancear lo multiplique con un decimal hasta que me pareciera justo el score 
        Player.Score += transform.position.z*0.00051f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (hasControl)
        {
            //Trigger end level es el final del nivel aqui especificamos que para cuando chocas con el final del nivel
            if (other.tag == "TriggerEndLevel")
            {
                //se llama el audio ganar desde el fxaudiomnanager 
                reproductorAudio.activandoAudio("Ganar");
                //se llama a la corrutina wair and end 
                StartCoroutine(waitAndEnd());
                //Se pausa la musica para dar paso al sonido de victoria.
                AudioManagerMusic.GetComponent<AudioSource>().Pause();
                //esto tiene que ver con el sistema de continue aqui asigno que al pasar un nivel aumente uno para que el player pueda pasar.
                Player.theLevel+=1;
             

               

            }
            else if (other.tag == "Obstacles")
            {
                //aqui asigno que al chocar con un obstaculo haga respawn en el punto inicial
                StartCoroutine(Respawn());
            }
            else if (other.tag == "Moneda")
            {
                //desactivo el sphere collider de la esphera  que es la moneda para que no lo pueda agarrar otra vez el player 
                other.GetComponent<SphereCollider>().enabled = false;
                //desactivo el mesh rederer de la sphere para volverlo invisible
                other.GetComponent<MeshRenderer>().enabled=false;
                //aumento el score en 10 por cada moneda
                Player.Score += 10;
          

      
            }
            else if (other.tag == "Heal")
            {

                other.GetComponent<BoxCollider>().enabled = false;
                other.GetComponent<MeshRenderer>().enabled = false;
                //aumento  en 50 la vida
                Player.life += 50;


            }
   
         
            else if (other.tag == "Dron")
            {
                Player.life -= 25;
            }

     

            LifeSlider.value = life;
        }
    }


    protected IEnumerator Respawn()
    {
        //quito la velocidad de movimiento hacia adelante
        currentSpeed = 0;
        //quito el control
        hasControl = false;
        //Devuelvo la nave a la vida maxima
        Player.life = maxLife;
        //desactivo la nave
        plane.gameObject.SetActive(false);
        //llamo al efecto de audio explosion desde el audio manager fx
        reproductorAudio.activandoAudio("Explosion");
        //instancio la particula de explosion
        var particles = Instantiate(particlesPrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z - 6f), transform.rotation);
        //lo devuelvo despues del tiempo aignado en la variable secondsWaitingOnDeath
        yield return new WaitForSeconds(secondsWaitingOnDeath);
        //destruyo las particulas
        Destroy(particles);
        //devuelvo la nave a la posicion inicial
        transform.position = initialPos;
        //vuelvo a activar la nave
        plane.gameObject.SetActive(true);
        //le doy el control
        hasControl = true;
        //score lo devuelvo a 0 
        Player.Score = 0;
    
        yield return null;
    }

    protected IEnumerator waitAndEnd()
    {
        // en esta corroutina les digo a los objetos que me siguen que se queden quietos
        for (int i = 0; i < followers.Length; i++)
        {
            followers[i].enabled = false;
        }

        //desactivo el control de la nave  
        hasControl = false;

        yield return new WaitForSeconds(secondsOnEnd);
     

        //avisar fin de nivel/cargar nuevo nivel.
        manager.endLevel();
    }
}
