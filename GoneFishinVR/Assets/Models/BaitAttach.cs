using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitAttach : MonoBehaviour
{
    public GameObject Rod;
    public GameObject worm;
    public GameObject bug;
    public GameObject lure;
    public GameObject bone;

    // Start is called before the first frame update
    void Start()
    {
        bone.SetActive(false);
        lure.SetActive(false);
        bug.SetActive(false);
        worm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //had to do several ifs because you cant compare strings with || /shrug
        if (other.gameObject.tag == "BugBait")
        {
            Attach("BugBait");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "FishBait")
        {
            Attach("FishBait");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "DogBait")
        {
            Attach("DogBait");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "WormBait")
        {
            Attach("WormBait");
            Destroy(other.gameObject);
        }

    }
    public void Attach(string Tag)
    {
        switch (Tag) 
        {
            case "FishBait":
                bone.SetActive(false);
                lure.SetActive(true);
                bug.SetActive(false);
                worm.SetActive(false);
                break;
            case "DogBait":
                bone.SetActive(true);
                lure.SetActive(false);
                bug.SetActive(false);
                worm.SetActive(false);
                break;
            case "BugBait":
                bone.SetActive(false);
                lure.SetActive(false);
                bug.SetActive(true);
                worm.SetActive(false);
                break;
            case "WormBait":
                bone.SetActive(false);
                lure.SetActive(false);
                bug.SetActive(false);
                worm.SetActive(true);
                break;
        }
    }
}
