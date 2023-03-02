using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using static System.Net.Mime.MediaTypeNames;


public class Reel : MonoBehaviour
{
    public GameObject Self;
    public GameObject Teleport;
    public Vector3 TpPos;
    private Rigidbody rb;
    


    public InputActionReference toggleReference = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        toggleReference.action.started += Toggle;
        
        Teleport = GameObject.FindGameObjectWithTag("Tele");
        TpPos = Teleport.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    private void Toggle(InputAction.CallbackContext context)
    {
        Debug.Log("please");
        if(Self.tag == "Untagged")
        {
            Debug.Log("pretty please");
            Self.transform.position = TpPos;
            rb.constraints = RigidbodyConstraints.FreezeAll;


        }
        

    }
}
