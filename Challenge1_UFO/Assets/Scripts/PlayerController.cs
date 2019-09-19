using System.Collections;
using System.Collections.Generic;
using UnityEngine; // to use the MonoBehvior
using UnityEngine.UI; //making it use the UI text stuff

public class PlayerController : MonoBehaviour
{
    //create the controll the ufo speed
    public float speed;

    // create the counttext to hold reference to UI text component
    public Text countText;
    public Text livesText;
    public Text winText;
    

    // to create variable to hold the reference
    private Rigidbody2D rb2d;

    //making the thing count the variable # of pickup
    private int count;
    private int lives;


    //setting the reference ^ in start function
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();

        //make count = to 0 so it can start counting up
        count = 0;
        lives = 3;
        winText.text = ""; //set the "" empty so it start as empty
        SetCountText(); //calling function
        SetLivesText();
    }

    //update or fixedupdate check for input
    private void FixedUpdate()
    {
        
        // seeing if player input key to move the ufo
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //get the 2 float value "movement" into vector2 value (x,y)
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //use the rb2d to make the movement ^ along with the speed
        rb2d.AddForce(movement * speed);

        //make the escape key as quit game
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    //make the pickup and ufo collide so that the ufo will make the gold go away as pickup
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false); //this make the gold disapear from the map after being collide with the ufo
            count = count + 1; //make the count count up everytime ufo pick up the gold
            SetCountText(); // calling function
            SetLivesText();
        }
        else if (other.gameObject.CompareTag("Enemy")) //if player pickup enemy, it will not only pick the object up but also remove the point
        {
            other.gameObject.SetActive(false);
            //count = count - 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();

        }
        // making the player teleport to lvl 2 if they pickup all the gold
        if (count == 14)
        {
            transform.position = new Vector2(50.0f, 50.0f);
        }

    }
    void SetCountText() //create a function to do the stuff when u called it
    {
        countText.text = "Count: " + count.ToString(); //have to be set AFTER the count = 0 becuz it have to be declared first to add up the pickup
        if (count >= 27) //make the if statement so that if player pick up all gold, winText appear
        {
            winText.text = "You win! Made by Hanniee Tran.";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Destroy(gameObject); //kill the noob player
            winText.text = "You Lost!!";
        }
        
    }
}
