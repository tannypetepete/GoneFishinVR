using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{

    //Doing this instead of an array because I Just Don't Want To™ /shrug
    public AudioSource RavenRef;
    public AudioSource RavenRef2;
    public AudioSource HowlRef;
    public AudioSource HowlRef2;
    public AudioSource HowlRef3;
    public AudioSource SparrowRef;
    public AudioSource RobinRef;
    public AudioSource LeavesRef;

    //Proc for sound events
    private float ProcMin = 6f; //minimum time for radio proc (basically 10 seconds)
    private float ProcMax = 10f; //maximum time for radio proc (basically 20 seconds)
    public float proc_timer;
    public int proc_chance;
    public bool timerstop;
    public int lastSound;

    // Start is called before the first frame update
    void Start()
    {
        proc_timer = Random.Range(ProcMin, ProcMax);
        timerstop = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerstop == false)
        {
            proc_timer -= Time.deltaTime; //timer starts ticking
        }
        
        if (proc_timer <= 0)
        {
            timerstop = true;
            proc_timer = Random.Range(ProcMin, ProcMax); //reset timer to a new, random amount
            proc_chance = Random.Range(0, 5); //select a sound to occur, goes farther than case so sometimes no sound will happen                                 
            
            switch(proc_chance) //plays sounds
            {
                case 0:
                    if(lastSound != 0)
                    {
                        switch(Random.Range(0, 2))
                        {
                            case 0:
                                RavenRef.Play();
                                break;
                            case 1:
                                RavenRef2.Play();
                                break;
                        }
                        
                    }
                    break;
                case 1:
                    if (lastSound != 1)
                    {
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                HowlRef.Play();
                                break;
                            case 1:
                                HowlRef2.Play();
                                break;
                            case 2:
                                HowlRef3.Play();
                                break;
                        }
                    }
                    break;
                case 2:
                    if (lastSound != 2)
                    {
                        RobinRef.Play();
                        
                    }
                    break;
                case 3:
                    if (lastSound != 3)
                    {
                        SparrowRef.Play();
                    }
                    break;
                case 4:
                    if (lastSound != 4)
                    {
                        LeavesRef.Play();
                    }
                    break;

            }
            lastSound = proc_chance; //so same sound doesnt play twice in a row
            timerstop = false;
        }
    }
}
