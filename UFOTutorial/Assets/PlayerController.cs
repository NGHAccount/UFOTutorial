using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text lifeText;

    private Rigidbody2D rb2d;
    private GameObject enemy;
    private GameObject pickup;
    private GameObject player;
    private int count;
    private int lives;

    // Start is called before the first frame update
    void Start(){

        rb2d = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        pickup = GameObject.FindGameObjectWithTag("PickUp");
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText();
        SetLivesText();

    }


    void Update(){

        if (Input.GetKey("escape"))
            Application.Quit();
        

    }


    void FixedUpdate(){

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

       
    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Enemy")){
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();

        }

        if (count == 12 && pickup.activeInHierarchy == false){
            transform.position = new Vector2(-100.0f, 0.0f);
            rb2d.velocity = Vector2.zero;
        }

        
        

    }

    void SetCountText(){

        countText.text = "Count: " + count.ToString();

        if (count == 20) {
            winText.text = "You Win! My name is Nick Hennessy";
            
        }
    }


    void SetLivesText(){

        lifeText.text = "Lives: " + lives.ToString();

        if (lives == 0){
            loseText.text = "You Lose!";
            DestroyPlayer();
            
        }

    }

    void DestroyPlayer(){

        Destroy(player);
    }
}
