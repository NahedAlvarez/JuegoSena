using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static float Score = 0;

    public Slider VolumenFxSlider;
    public Toggle VolumenFxtogle;

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

    //particles
    public GameObject particlesPrefab;
    
    public float secondsWaitingOnDeath = 3;
    public GameManager manager;
    public GameObject Gamemanager;

    // Use this for initialization
    void Start()
    {
        

        initialPos = transform.position;

        plane = transform.GetChild(0);

        followers = FindObjectsOfType<FollowTarget>();
    }

    // Update is called once per frame
    void Update()
    {

        particlesPrefab.GetComponent<AudioSource>().volume = VolumenFxSlider.value;
        if (VolumenFxtogle.isOn == false)
        {
            manager.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            manager.GetComponent<AudioSource>().volume = 1;
        }


        if (hasControl)
        {
            currentSpeed += Time.deltaTime * acceleration;
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
                //currentSpeed = currentSpeed + Time.deltaTime * acceleration > MaxSpeed ? MaxSpeed : currentSpeed + Time.deltaTime * acceleration > MaxSpeed;
            }


            var horiz = Input.GetAxis("Horizontal");

            var direction = (transform.right * turnSpeed * horiz * Time.deltaTime).normalized;

  

            if (!Physics.Raycast(transform.position, direction, turnSpeed *  Time.deltaTime + 0.5f, stopMask))
            {
                transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;
            }


            //Rotamos la nave en función del giro
            var r = plane.rotation.eulerAngles;
            r.z = Mathf.Lerp(-MaxPlaneRotationDegrees, MaxPlaneRotationDegrees, (-horiz + 1) / 2);

            plane.rotation = Quaternion.Lerp(plane.rotation, Quaternion.Euler(r), 0.1f);
        }


        //move forward
        transform.position = transform.position + transform.forward * Time.deltaTime * currentSpeed;

        Player.Score += transform.position.z*0.00051f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (hasControl)//Para evitar que esto pase varias veces seguidas
        {
            if (other.tag == "TriggerEndLevel")
            {
                StartCoroutine(waitAndEnd());
                AudioManagerMusic.GetComponent<AudioSource>().Pause();
              

            }
            else if (other.tag == "Obstacles")
            {
                StartCoroutine(Respawn());
            }
            else if (other.tag == "Moneda")
            {
                other.GetComponent<SphereCollider>().enabled = false;
                other.GetComponent<MeshRenderer>().enabled=false;
                Player.Score += 10;
            }

        }
    }


    protected IEnumerator Respawn()
    {

        currentSpeed = 0;
        hasControl = false;

        plane.gameObject.SetActive(false);
        particlesPrefab.GetComponent<AudioSource>().Play();
        particlesPrefab.GetComponent<AudioSource>().volume = VolumenFxSlider.value;
        if (VolumenFxtogle.isOn == false)
        {
            particlesPrefab.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            particlesPrefab.GetComponent<AudioSource>().volume = 1;
        }

        var particles = Instantiate(particlesPrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z - 6f), transform.rotation);

        yield return new WaitForSeconds(secondsWaitingOnDeath);

        Destroy(particles);

        transform.position = initialPos;
        plane.gameObject.SetActive(true);
        hasControl = true;
        Player.Score = 0;

        yield return null;
    }

    protected IEnumerator waitAndEnd()
    {
        for (int i = 0; i < followers.Length; i++)
        {
            followers[i].enabled = false;
        }

        //GetComponent<AudioSource>().Play();
        hasControl = false;
        yield return new WaitForSeconds(secondsOnEnd);
     

        //avisar fin de nivel/cargar nuevo nivel.
        manager.endLevel();
    }
}
