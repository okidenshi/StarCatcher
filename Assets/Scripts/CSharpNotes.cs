using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpNotes : MonoBehaviour
{
    //Erica Adamek
    // Two forward slashes allows for comments these are not read by the engine
    //The top part of the Script is where Variables are stores
    //Numbers, references to objects or references to other scripts
    //Variables have 3 parts, first is public/private. Second is TYPE of variable, third is whatever you name the variable

    //NUMBER VARIABLES
    //Two common types of number variables, floats, and ints
    public float number; //float stands for floating point number, meaning the number has a decimal point. Example: 1.25 is a float. It's not a whole number
    public int wholenumber; //1,2,3 are ints
    private float myhiddennumber; //a private variable is not visible inside the inspector

    //BOOLS (true/false statements)
    public bool yesorno; //abool is a yes or no statement, a binary, like a light switch. It's either on or off. 

    //Other common variables
    public GameObject mygameObject; //we can reference any object in our scene. all items in the hierarchy are considered game objects 
    public CSharpNotes CSN; //we can also reference any script that has written as long as it's public
    public Rigidbody2D myRB2D; // we use rigibodies on players and enemies and anything we want to be affected by unity's physics engine
    public BoxCollider2D myboxcollider; //we can also reference colliders of all types like...
    public CircleCollider2D mycirclecollider; 
    //we usually put these references at the top of the script. We need to call them here first If we need to manipulate them later in the script.
    



    // Start is called before the first frame update
    void Start()
    {

        //anything you want to happen when the game starts goes here!
        //sometimes we don't want to have too many drag/drop items in the inspector
        //sometimes we want to spawn new items during gameplay. In this case, we can use a few  simple commands to have the script automatically find objects!

        myRB2D = GetComponent<Rigidbody2D>(); // this will get the rigidbody, but only if it's on the same object as our script
        myRB2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //this will find aby object in our scene that has the tag player and get it's rigidbody!
        myRB2D = GameObject.FindObjectOfType<Rigidbody2D>();
        //this only works whenthere is no more than one rigidbody!

        //when the game starts, you might want to look at a few different properties of your game objects, such as Transforms, POsition, and rotation, and scale. 
        transform.position = new Vector2(0, 0);
        //tranforms position is our location on x and y. Tranforms are read by Unity as something called a Vector (Vector 2 or Vecttor 3, which is for 3D). 
        //Think of the of a vector like a bar grapg, x horizontal (walking), y on the vertical (jumping)
        //The Vector 2 above is set at the origion position; another example would be ...
        transform.position = new Vector2(24, 128); //this would move us 24 units right and 128 units up
        //we can also manipulate scale this way
        transform.localScale = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0); //this is for 3D. Both of these would be invisible until you put an asset on the thing
        //the above is scale...rotation is a little bit more complication. 
        //For rotation, we use Quaternion and EULER (oiler)
        transform.rotation = Quaternion.Euler(0, 0, 0); //this is mor of a 3d thing, but good to know. 2d rotation can just be done in animation~!
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Inside the update function is wher eyou call things that we want to update in real time!! It's called constantly!

        //IF STATEMENTS
        if (yesorno == true)

        {
            //we say yes
            //theplayer lives
        }

        if (yesorno == false)
        {
            //we say no
            //the player dies
        }

        //this is also an example of how bools can work. If the bool is tue, one thing happens, if it is false, somethign else happens!
        //For the IF statement to work, you need a doubel equal sign. A Single sign meants that the bool IS true or IS false, where the double sign checks to see IF it's true or false!

        if(number >= 10)
        {
            //we do something (respawn, die, ect)
        }

        //We can also use IF statements to control the player!
        if (Input.GetAxis("Horizontal") > 0) ;
        {

            //we move the player
            myRB2D.velocity = new Vector2(25, 0);
        }

        if (Input.GetAxis("Horizontal") == 0) ;
        {
            //we want to stop the player
            myRB2D.velocity = new Vector2(0, 0); //this is a zero velocity
            //to see all the different rigibody options we have, just start typeing myRB2D. example below...
            myRB2D.gravityScale = .5f; //gives me half gravity!

            myRB2D.simulated = false; //this means the rigidbody is no longer affected by the phsycics engine, liek if you want him to be invisible for a little bit

            myRB2D.isKinematic = true; //kinematic rigidbody only moves if the code tells it to
            myRB2D.isKinematic = false; //non kinematic is the same dynamic,which means it is affects by the physics engine!

            // IF ELSE STATEMENTS

            //If statements get read one after the other, which can somtime cause weird behavior
            //We can avoid this by using IF ELSE Statements

            if (yesorno == true)

            {
                //we say yes
                //theplayer lives
                //if this turns our to be true, you won't need the below else statement
            }

           else  if (yesorno == false)
            {
                //we say no
                //the player dies
                //if the above If statements is not true,  you will read this else statement
            }

            //Because this cose is int he update, changes can happens quickly and we can cycle multiple statements faster than we want to. This is why we use else!
            // Else makes it stop if it gets like. Funky. A big string of if statements can ge WILD...

        }
    }

    public void FixedUpdate()
    {

        //regular update is based on frem reate which means that a newer computer will run the code faster and an odler one will run it slower- this is not ideal
        //For the most part, graphical elements can live inside the update loop w/o any issue
        //the Fixed Update loop is used for Physics calculations as its called on a set interval which means that all computers run the code at the same speed

    }
}


