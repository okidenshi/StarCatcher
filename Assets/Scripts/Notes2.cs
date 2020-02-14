using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this lets you call images which are using UI buttons, tuggles, ect
using UnityEngine.SceneManagement; //this lets you call scenemanager which loads levels
using UnityEngine.Audio; //this calls the audio mixer


public class Notes2 : MonoBehaviour
{

    //Erica Adamek
    public Notes2 n2;
    public GameObject GO;
    public Image myimage;
    public Button mybutton;
    public float timer;
    //start is called before the first frame update

    //AI

    //MOVE TOWARDS (moved objects towards another) flyinf follower enemy works this way!
    public Vector3 start; //the start location
    public Vector3 finish; //the end location or trget
    public float speed; //how fast the mover goes from start to finish

    //LOOT

    public GameObject money;

    //ARRAY is a collection of Gameobjects
    //they allow us to effect large groups of objects 
    public GameObject[] alltheenemies; //the straight brackets signify a cllection of gameobjects


    //PLAYERPREFS
    //these are values that will save even after the player leaves the game. This is good for unlockable content or overall progress. 
    //also work for character skin

    public int GreenBird; //this is not a player pref just a normal int



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("GreenBird", 2); //this will unlock the green bird so i would only do this when i am ready to unlock it before this is set to 0 or 1

        if (PlayerPrefs.HasKey("GreenBord"))
        {
            GreenBird = PlayerPrefs.GetInt("GreenBord"); //if i beat the game it will be 2, if i didn't beat the game yet, it will be 1. 
        }

        if (GreenBird == 2)
        {

            //i can select the green bird
        }

        alltheenemies = GameObject.FindGameObjectsWithTag("enemy"); //this grabs all enemies
        //ENABLED vS SET ACTIVE
        //We enabled and disable components attatched to gameObjects
        //we set active true or false entire gameObjects

        n2.enabled = true; //enabled the notes2script (box collider, scripts, any component)
        GO.SetActive(true); //enabled the entire game object
        StartCoroutine(StarPower()); //this line calls the Ienumerator (don't do this in update)

    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        //we can create timers using commanded Time.deltaTime. This means time that had passed since the last frame (so a constant timer)
        //We can take a float and add or subjtract Time.deltaTime to create a timer that counts up or down!
        timer -= Time.deltaTime; //-= subtracts time from the timer consistently
        timer += Time.deltaTime; // this adds time to the timer

        if (timer >= 0)
        {
            mybutton.interactable = true; // this allows the button to be pressed

        }

        if (timer < 0)
        {
            mybutton.interactable = false; //this greys the button out and connot be pressed
        }

        Vector3.MoveTowards(start, finish, speed); //this line will move the objects (under AI notes)
        //the start position is set to the mover's position
        //the target position gets set to another game object (usually the player)
        //the speed is constant


        //INSTANTIATE is a way to make things appear in our scene. This could be enemies, loot, power ups, 

        GameObject loot = Instantiate(money, transform.position, transform.rotation);
        //the above line makes a new gameobject by creating money at our current location
        //we say Gameobject loot because we are creating new gamobjects in the hierarchy called loot
        //money is usually a prefab that we can  call over and over again. This means money eon't be in the hierarchy but inside the game's asset folder
        Destroy(money, 5f); //this destroyes the moeny if you don't get it fast enough. Not super mobile friendly but...

        //AUTOPOOLING we are using a plug in called Mob Farm Auto Pooler
        GameObject loot2 = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        //this is the mobile friendly version! (it's a plug in)

        MF_AutoPool.Despawn(this.gameObject, 5f); //this line would be on the money gameobject and would put it back into the pool without any left over issues!

        //ARRAY (how to go through yout list and affect each object one at a time)
        //FOR LOOP
        for (int i = 0; i < alltheenemies.Length; i++)
        {
            alltheenemies[i].SetActive(true); //we set each enemy active 
        }
        //int i 0 means we start at the top of the list
        // i < allenemies, means as long as the number we're on isn't lerger than the list
        //lets say the list is 10 long, if we are at 0,  0 <10, so we add 1, if 1 is less than 10 so we add another one until we get to 10
        // i++ we move down the list by one
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this statement is used when we want a player to walk into a specific area and trigger something
        //this could be animation, enemy, or anything you want! :)
        //an event is triggered when a player passes through a collider that is marked as a triger. 
        // Either the player or the collider must have a rigibody 2d in order for the hit to trigger!

        //different OnTrigger things have different effects, just try and use the one best for you

        if (collision.tag == "Player")
        {
            //then we trigger the event. this will only trigger if the collider has the tag player so enemies can't trigger this event. 
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // unlike a trigger, a collision happens when two colliders bump into eachother but do not pass through 
        //use this for something solid in a world (like a moving platform)

    }

    //CO-ROUTINE which unity calls IEnumerator
    //normal functions in unity are read top to bottom all at once. Sometimes we want to pause before finishing the function whihc is when we use IEnumerator
    //this of this as the star power in super mario. when you get the star, the player is invincible. For a short time, the sprite/music changes, and it evetnualyl wears off

    public IEnumerator StarPower();
    
    //or nam it whatever you want, doesn;t have to be star pwoer 
    
         //give mario Start power
         //change music
         //change sprite graphics
         //then we want to wait
         yield return new WaitForSeconds(5f); //this line makes unity wait five seconds
                                              //star power wears off, sprite goes back)
        
    // to call an IEnumerator we use the word Co-Rutine (see start loop)

}
