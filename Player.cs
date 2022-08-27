using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {
    int JumpVelocity = 3; //Variable for the player's jump height.
    float Jump; //Variable for a jump timer.
    public GameObject Player1; //The player.
    protected bool jump;
    public GameObject maincharacter;
    public float walkspeed = 0.05f;
    public float runspeed = 0.1f;
    public float speed;
    public bool destroyed;
    public GameObject product;
    public float timer;
    public Texture noblood;

    // Use this for initialization
    void Start () {
        destroyed = false;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        Jump += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && (Jump >= 1.0f)) //The player clicks a button to jump but will only jump if the jump variable time is greater then 1.5seconds.
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * JumpVelocity; //Makes the player jump based on the jump velocity.
            Jump = 0f; //Resets the jump variable to 0 to begin counting again.
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        { 
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkspeed;
        }

        if (Input.GetKey(KeyCode.Q) && destroyed == true)
        {
            JumpVelocity = 5;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneName: "MainMenu");
        }


        //If player collides with tag cannot collide back with that collider
        if (DoorClose.Hodor == true)
        {
            transform.gameObject.tag = "PlayerTrapped";
            //print("Tag switch");
        }
         timer = gameObject.GetComponent<testimer>().myTimer;

        if (timer >= 600.0f)
        {
            speed = speed =+ 0.04f;
        }
        if (timer >= 650.0f)
        {
            speed = speed = +0.03f;
        }
        if (timer >= 700.0f)
        {
            speed = speed = +0.02f;
        }
        if (timer >= 750.0f)
        {
            speed = speed = +0.01f;
        }
        if (timer >= 800.0f)
        {
            SceneSwitch();
        }




    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

    //Code added so game ends when player collides with exit tag game ends 
    //Can change to a scene switch at a later date
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Exit")
        { 
            //Used to end game atm in build version
           Application.Quit();
           //Used to end game atm in editior version
          // UnityEditor.EditorApplication.ExitPlaymode();
        }
            destroyed = true;
    }

}
