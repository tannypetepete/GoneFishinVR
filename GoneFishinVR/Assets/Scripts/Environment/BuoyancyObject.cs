using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BuoyancyObject : MonoBehaviour
{
    public Transform[] floatPoints;
    public Transform[] sinkPoints;
    int floatPointsUnderwater, sinkPointsUnderwater;
    public float underwaterDrag = 5f;
    public float underwaterAngularDrag = 6f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 130f;
    public float sinkingPower = 1f;
    public float waterHeight = 23.5f;
    float objectWaterHeight;

    Rigidbody rb;

    bool underwater;

    public bool touchingWater;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchingWater = true;
    }

    void FixedUpdate()
    {
        floatPointsUnderwater = 0;
        sinkPointsUnderwater = 0;
        for (int i = 0; i < floatPoints.Length; i++)
        {
            float depth = floatPoints[i].position.y - waterHeight; //finds difference between rigidbody and height of the water

            if (depth < 0)
            {
                rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(depth), floatPoints[i].position, ForceMode.Force); //adds force to make object float
                floatPointsUnderwater += 1;
                if (!underwater) //if below water and bool is currently false, sets it to true
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }

        for (int i = 0; i < sinkPoints.Length; i++)
        {
            float depth = sinkPoints[i].position.y - waterHeight; //finds difference between rigidbody and height of the water

            if (depth < 0)
            {
                rb.AddForceAtPosition(Vector3.down * sinkingPower * Mathf.Abs(depth), sinkPoints[i].position, ForceMode.Force); //adds force to make object sink
                sinkPointsUnderwater += 1;
                if (!underwater) //if below water and bool is currently false, sets it to true
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }

        if (underwater && floatPointsUnderwater == 0 && sinkPointsUnderwater == 0) //if none of the floatpoints are underwater
        {
            underwater = false;
            SwitchState(false);
        }
    }

    /*void OnTriggerEnter(Collider col) //if object is touching water surface
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            touchingWater = true;
        }
    }

    void OnTriggerExit(Collider col) //if object stops touching water surface (is above or under it)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            touchingWater = false;
        }
    }*/

    void SwitchState(bool underwater) //changes the drag and angular drag depending on if it goes under / above water
    {
        if (underwater)
        {
            rb.drag = underwaterDrag;
            rb.angularDrag = underwaterAngularDrag;
        }
        else if (!underwater)
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}
