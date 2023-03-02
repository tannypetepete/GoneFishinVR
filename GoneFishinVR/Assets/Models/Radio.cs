using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Radio : MonoBehaviour
{
    public AudioSource radio_music;
    public bool radioPowered;
    

    private float ProcMin = 5f; //minimum time for radio proc (basically 5 seconds)
    private float ProcMax = 10f; //maximum time for radio proc (basically 10 seconds)

    public float proc_timer;
    private int proc_chance;
    
    void Awake()
    {
        radioPowered = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        proc_timer = Random.Range(ProcMin, ProcMax);
    }
  
    void FixedUpdate()
    {
        if (radioPowered == true)
        {
            radio_music.volume = .5f; 
        }

        if (radioPowered == false) //only while radio is off
        {
            radio_music.volume = 0f;
            proc_timer -= Time.deltaTime; //timer starts ticking
            if (proc_timer <= 0f)
            {
                proc_timer = Random.Range(ProcMin, ProcMax); //reset timer to a new, random amount
                proc_chance = Random.Range(1, 100); //see if radio turns on
                if (proc_chance <= 0) //currently at a 75% TO TURN ON.
                {
                    radioPowered = true;
                }
            }
        }
        
    }

    public void RadioPower()
    {
        radioPowered = !radioPowered;
    }
}
