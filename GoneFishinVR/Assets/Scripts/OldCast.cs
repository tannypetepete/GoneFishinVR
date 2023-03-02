using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OldCast : MonoBehaviour
{
    public GameObject bobber;
    public GameObject bobbertop;
    public GameObject bait;         //This is new
    public GameObject ring;
    public float distance;
    public float distanceOffset;
    public float baitOffset;        //This is new
    public bool hasFishingRod;
    Rigidbody bobberT;
    Rigidbody bobberB;
    public GameObject bobberPrefab;
    public bool createBobber;

    // Start is called before the first frame update
    void Start()
    {
        hasFishingRod = false;
        createBobber = false;
    }
    // Update is called once per frame
    void Update()
    {
        Cast();
    }

    public void setFishingRod()
    {
        hasFishingRod = true;
    }

    void Cast()
    {
        if (hasFishingRod == true)
        {
            distance = Vector3.Distance(bobber.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + distance, ring.transform.position.z));
            distanceOffset = Vector3.Distance(bobbertop.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + 0.01f + distanceOffset, ring.transform.position.z));
            baitOffset = Vector3.Distance(bait.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + baitOffset, ring.transform.position.z));
            bobber.transform.position = Vector3.MoveTowards(bobber.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + distance, ring.transform.position.z), Time.deltaTime * 30f);
            bobbertop.transform.position = Vector3.MoveTowards(bobbertop.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + 0.01f + distanceOffset, ring.transform.position.z), Time.deltaTime * 30f);

            //Line under is new
            bait.transform.position = Vector3.MoveTowards(bait.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y + 0.01f + baitOffset, ring.transform.position.z), Time.deltaTime * 30f);

            if (distance <= 0 && distanceOffset <= 0)
            {
                if (GameObject.Find("Bobber(Clone)") != null)
                {
                    createBobber = false;
                }
                else
                {
                    createBobber = true;
                }
                if (createBobber == true)
                {
                    Instantiate(bobberPrefab, new Vector3(ring.transform.position.x, ring.transform.position.y, ring.transform.position.z), Quaternion.identity);
                    bobber.SetActive(false);
                    bobbertop.SetActive(false);
                }

            }
        }
    }
}