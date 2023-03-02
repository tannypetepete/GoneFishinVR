using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Casting : MonoBehaviour
{
    public GameObject bobber; //the child gameobject bobber
    public GameObject bobbertop;
    public GameObject ring;
    public Vector3 ringPos;
    public float distance;
    public float proximity;

    public bool inWater;


    float initialAngle = 45;

    public bool hasFishingRod;
    Rigidbody bobberT;
    Rigidbody bobberB;
    public GameObject bobberPrefab; //the prefab in the folder it takes from Assets>Items>Bobber
    public GameObject bobberMain; //the prefab that is created in the game world
    bool casting;

    void Start()
    {
        hasFishingRod = false;
        casting = false;
        proximity = 100f; //random number as long as its greater than 0.03
    }

    void Update()
    {
        if (bobberMain != null)
        {
            if (bobberMain.GetComponent<BuoyancyObject>().touchingWater == true)
            {
                inWater = true;
            }
            else if (bobberMain.GetComponent<BuoyancyObject>().touchingWater == true)
            {
                inWater = false;
            }

            proximity = Vector3.Distance(bobberMain.transform.position, new Vector3(ring.transform.position.x, ring.transform.position.y, ring.transform.position.z)); //checks if bobber is in proximity to the ring
            if (inWater == true && casting == true)
            {
                casting = false; //makes you allowed to cast again if bobber is in the water
            }
        }

        ringPos = ring.transform.position;


    }

    public void setFishingRod()
    {
        
        hasFishingRod = true; //if pick up rod
    }

    public void dropFishingRod()
    {

        if (hasFishingRod == true)
        {
            hasFishingRod = false;
            
        }
        else if (hasFishingRod == false)
        {
            hasFishingRod = true;
        }
    }

    public void Cast()
    {
        
        if (hasFishingRod == true && casting == false) //checks if youre holding rod and if theres no bobber in the water
        {
            casting = true; //this variable makes it so that you cant keep casting a new bobber until its landed in the water. in the end you should only be able to cast whenever you havent casted yet at all


            Vector3 startPosition = bobber.transform.position;
            bobber.SetActive(false);
            bobbertop.SetActive(false);

            if (bobberMain != null)
            {
                Destroy(bobberMain);
            }

            bobberMain = Instantiate(bobberPrefab, startPosition, Quaternion.identity);
            startPosition = bobberMain.transform.position;

            
            Vector3 direction = ringPos - startPosition;
            float angle = initialAngle * Mathf.Deg2Rad;

            float gravity = Physics.gravity.magnitude;

            Vector3 planarTarget = new Vector3(ringPos.x, 0, ringPos.z);
            Vector3 planarPostion = new Vector3(startPosition.x, 0, startPosition.z);
            distance = Vector3.Distance(planarTarget, planarPostion);
            float yOffset = startPosition.y - ringPos.y;

            float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));
            Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

            float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);

            if (planarTarget.x - planarPostion.x < 0)
            {
                angleBetweenObjects = 360 - angleBetweenObjects;
            }

            Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;


            bobberMain.GetComponent<Rigidbody>().AddForce(finalVelocity * bobberMain.GetComponent<Rigidbody>().mass, ForceMode.Impulse); //add force to bobber;


        }
    }

    private float CalculateVelocity(float arcHeight, float gravity)
    {
        return Mathf.Sqrt(2 * arcHeight * gravity);
    }
}