using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;
    
    private Rigidbody rb;
    private int count;
    private int lives;
    Vector3 initialPosition;
    float timer = 0;
    float timeToWait = 0.5f;
    bool checkingTime;
    bool timerDone;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    void Start ()
    {
        initialPosition = transform.position;
        
        rb = GetComponent<Rigidbody> ();
   
        count = 0;
        lives = 5;
        
        SetCountText();
        SetLivesText();
        
        winText.text= "";
        loseText.text= "";

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 0.0f, -2.0f);

    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
    }
    
    

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag ("PickUps"))
            {
                other.gameObject.SetActive (false);
                transform.localScale += new Vector3(0.01F,0.01F,0.01F);
                count = count + 1;
                SetCountText();
        }
        
        if (other.gameObject.CompareTag ("SpikeBall"))
            {
                other.gameObject.SetActive (false); 
                transform.position = initialPosition;
                lives = lives - 1;
                SetLivesText();
        }
        
    }
    
    void SetLivesText ()
    {

        livesText.text = "Lives: " + lives.ToString();
        if (lives < 1)
        {
            SceneManager.LoadScene("Game Over");
           
        }
    }

    
    
    
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

}
