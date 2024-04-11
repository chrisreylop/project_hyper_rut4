using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public KeyCode jumpKey = KeyCode.Space;
    public float gravityForce = -20f;
    public float thrust = 20f;
    private float maxThrust;
    private bool playJumpSFX = true;
    private bool jumping = false;
    public Animator animator;
    public AudioSource audioSource;
    public LineRenderer lineRenderer;
    public int pointsCount;
    public float maxRadius;
    public float speed;
    public float startWidth;
    public bool movingLeft = false;
    public bool movingRight = false;
    
    public void MoveBus()
    {
        if(!Pause.gameIsPaused)
        {
            if (transform.position.x > -3.5)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
                    transform.Translate(moveAmount, 0, 0);
                    //Debug.Log(Input.GetAxis("Horizontal") + "move left");
                }
                else if (movingLeft)
                {
                    float moveAmount = (moveSpeed/2) * Time.fixedDeltaTime * -1;
                    transform.Translate(moveAmount, 0, 0);
                }
            }
            if (transform.position.x < 3.5)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    float moveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
                    transform.Translate(moveAmount, 0, 0);
                    //Debug.Log(Input.GetAxis("Horizontal") + "move right");
                }
                else if(movingRight)
                {
                    float moveAmount = (moveSpeed / 2) * Time.fixedDeltaTime;
                    transform.Translate(moveAmount, 0, 0);
                }
            }
        }
    }
    public void Jump()
    {
        jumping = true;
        if(playJumpSFX)
        {
            audioSource.Play();
            playJumpSFX = false;
        }
    }
    /*public void OnAir()
    {
        if (jumping && maxThrust > 0)
        {
            transform.Translate(0, maxThrust * Time.deltaTime, 0);
            StartCoroutine(Blast());
            maxThrust -= 1f;
            //Debug.Log("Jumped");
        }
        else if (transform.position.y > 0.6)
        {
            transform.Translate(0, gravityForce * Time.deltaTime, 0);
        }
        if (transform.position.y <= 0.6)
        {
            maxThrust = thrust;
            playJumpSFX = true;
            jumping = false;
        }
    }*/
    public void OnAir()
    {
        if(!Pause.gameIsPaused)
        {
            if (jumping && maxThrust > 0)
            {
                transform.Translate(0, maxThrust * Time.fixedDeltaTime, 0);
                StartCoroutine(Blast());
                maxThrust -= 1f;
                //Debug.Log("Jumped");
            }
            else if (transform.position.y > 0.6)
            {
                transform.Translate(0, gravityForce * Time.fixedDeltaTime, 0);
            }
            if (transform.position.y <= 0.6)
            {
                maxThrust = thrust;
                playJumpSFX = true;
                jumping = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Passenger"))
        {
            GameManager.gameManagerInstance.ShowPassengerDialogue();
            GameManager.gameManagerInstance.UpdateFuel(30, 0);
            GameManager.gameManagerInstance.passengerAlreadySpawned = false;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Dron"))
        {
            animator.SetTrigger("SOFIHit");
            Debug.Log("Crashed with Dron");
        }
    }
    private IEnumerator Blast()
    {
        float currentRadius = 0f;
        while (currentRadius < maxRadius)
        {
            currentRadius += Time.fixedDeltaTime * speed;
            Draw(currentRadius);
            yield return null;
        }
    }
    private void Draw(float currentRadius)
    {
        float angleBetweenPoints = 360f / pointsCount;        
        for(int i = 0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }
        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);
    }
    private void Awake()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        maxThrust = thrust;
    }
    // Update is called once per frame
    void Update()
    {
        OnAir();
        if (Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
        MoveBus();
    }
}
