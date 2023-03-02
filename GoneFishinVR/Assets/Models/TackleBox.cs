using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TackleBox : MonoBehaviour
{
    public GameObject bait;
    public GameObject spawn;
    private GameObject baitObj;
    private Rigidbody rb;
    private Rigidbody rb2;
    public bool taken;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        //baitObj = (GameObject)Instantiate(bait, spawn.transform.position, spawn.transform.rotation);
        taken = false;
        //bait.tag = "Untagged";
    }


    // Update is called once per frame
    void Update()
    {
        if (taken == true) //prevents instance from creating new instances once taken.
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.isKinematic = false;
            rb.angularDrag = 0.05f;
        }
    }
    public void SpawnBait()
    {
        if (taken == false) //prevents instance from creating new instances once taken.
        {
            taken = true;
            baitObj = (GameObject)Instantiate(spawn, spawn.transform.position, spawn.transform.rotation);   
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            baitObj.GetComponent<TackleBox>().taken = false;
            spawn.tag = bait.tag;
        }


        //if (GameObject.Find("worm(Clone)") != null)
        //{
        //    Destroy(baitObj);
        //    baitObj = (GameObject)Instantiate(bait, spawn.transform.position, spawn.transform.rotation);

        //}
        //if (GameObject.Find("bugLure 1(Clone)") != null)
        //{
        //    Destroy(baitObj);
        //    baitObj = (GameObject)Instantiate(bait, spawn.transform.position + yoffset, spawn.transform.rotation);

        //}
        //if (GameObject.Find("boneBait(Clone)") != null)
        //{
        //    Destroy(baitObj);
        //    baitObj = (GameObject)Instantiate(bait, spawn.transform.position + yoffset, spawn.transform.rotation);

        //}
        //if (GameObject.Find("FishLure(Clone)") != null)
        //{
        //    Destroy(baitObj);
        //    baitObj = (GameObject)Instantiate(bait, spawn.transform.position, spawn.transform.rotation);

        //}
        //else
        //{
        //    baitObj = (GameObject)Instantiate(bait, spawn.transform.position, spawn.transform.rotation);
        //}
    }
}
        

