using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class Threat : MonoBehaviour
{
    public GameObject RadioRef;
    public bool radio_isPowered;

    //Bird Variables
    public GameObject Bird;
    public AudioSource bird_cue;
    public float bird_timer;
    private int bird_yoink;
    public Vector3 birdLanding;
    public Vector3 birdSpawning;
    public bool birdIn;
    public bool birdOut;
    public bool birdActive;

    //Wolf Variables
    public GameObject Wolf;
    public AudioSource wolf_cue;
    public float wolf_timer;
    private int wolf_attack;
    public Vector3 wolfStanding;
    public Vector3 wolfSpawning;
    public bool wolfIn;
    public bool wolfOut;
    public bool wolfActive;



    //Radio Variables
    private float ProcMin = 7f; //minimum time for radio proc (basically 7 seconds)
    private float ProcMax = 14f; //maximum time for radio proc (basically 14 seconds)
    public float proc_timer;
    private int proc_chance;
    public float wolf_proc_timer;
    private int wolf_proc_chance;


    void Awake()
    {
        birdLanding = Bird.transform.position; //sets birds scene position as its landing position
        birdSpawning = new Vector3(Bird.transform.position.x - 4.75f, Bird.transform.position.y + 4.53f, Bird.transform.position.z - 1.78f); //where the bird should come from--needs to be changed for every level but i will update it to use local values one day
        Bird.SetActive(false);
        wolfStanding = Wolf.transform.position; //sets wolf scene position as its landing position
        wolfSpawning = new Vector3(Wolf.transform.position.x + 2f, Wolf.transform.position.y, Wolf.transform.position.z); //same as bird lmao
        Wolf.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        birdActive = false;
        birdIn = false;
        birdOut = false;
        Bird.transform.position = birdSpawning;

        wolfActive = false;
        wolfIn = false;
        wolfOut = false;
        Wolf.transform.position = wolfSpawning;

        proc_timer = Random.Range(ProcMin, ProcMax);
        wolf_proc_timer = Random.Range(ProcMin, ProcMax);
        radio_isPowered = RadioRef.GetComponent<Radio>().radioPowered;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        radio_isPowered = RadioRef.GetComponent<Radio>().radioPowered;

        if (radio_isPowered == false) //only while radio is off
        {
            if (birdActive == false)
            {
                proc_timer -= Time.deltaTime; //timer starts ticking 
            }
            
            if (proc_timer <= 0f)
            {
                proc_timer = Random.Range(ProcMin, ProcMax); //reset timer to a new, random amount
                proc_chance = Random.Range(1, 100); //see if bird appears
                //would need a further if nest here for the bear and wolves (random 1 through 3 to see which comes up)
                if (proc_chance <= 20) //currently at a 20% to spawn a bird
                {
                    if (birdActive == false)
                    {
                        birdActive = true;
                        BirdAttack();
                    }
                }
            }
            if (wolfActive == true)
            {
                WolfLeave(); 
            }
        }
        if (radio_isPowered == true) //only while radio is on
        {
            if (wolfActive == false)
            {
                wolf_proc_timer -= Time.deltaTime; //timer starts ticking 
            }

            if (wolf_proc_timer <= 0f)
            {
                wolf_proc_timer =  Random.Range(ProcMin, ProcMax); //reset timer to a new, random amount
                wolf_proc_chance = Random.Range(1, 100); //see if wolf appears     
                if (wolf_proc_chance <= 100) //currently at a 70% to spawn a wolf
                {
                    if (wolfActive == false)
                    {
                        wolfActive = true;
                        WolfAttack();
                    }
                }
            }
        }

        if (birdIn == true)
        {
            Bird.transform.position = Vector3.MoveTowards(Bird.transform.position, birdLanding, Time.deltaTime * 2);
            if (Bird.transform.position == birdSpawning)
            {
                birdIn = false;
            }
        }
        if (birdOut == true)
        {
            Bird.transform.position = Vector3.MoveTowards(Bird.transform.position, birdSpawning, Time.deltaTime);
            
            if (Bird.transform.position == birdSpawning)
            {
                birdActive = false;
                Bird.SetActive(false);
                birdOut = false;
            }
        }

        if (wolfIn == true)
        {
            Wolf.transform.position = Vector3.MoveTowards(Wolf.transform.position, wolfStanding, Time.deltaTime * 2);
            if (Wolf.transform.position == wolfSpawning)
            {
                wolfIn = false;
            }
        }
        if (wolfOut == true)
        {
            Wolf.transform.position = Vector3.MoveTowards(Wolf.transform.position, wolfSpawning, Time.deltaTime);

            if (Wolf.transform.position == wolfSpawning)
            {
                wolfActive = false;
                Wolf.SetActive(false);
                wolfOut = false;
            }
        }
    }

    void BirdAttack()
    {
        Bird.SetActive(true);
        bird_cue.volume = .5f;
        bird_cue.Play();
        birdIn = true;

        //for stealing fish, i would probably use a while loop to make a timer go down. then when it hits
        //0 it subtracts a fish. 
    }

    public void BirdShoo()
    {
        birdIn = false;
        birdOut = true;
    }

    void WolfAttack()
    {
        Wolf.SetActive(true);
        wolf_cue.volume = .5f;
        wolf_cue.Play();
        wolfIn = true;
    }

    public void WolfLeave()
    {
        wolfIn = false;
        wolfOut = true;
    }
}
