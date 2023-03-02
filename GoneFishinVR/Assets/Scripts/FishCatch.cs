using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;


public class FishCatch : MonoBehaviour
{
    public GameObject Bait;
    public Transform BaitPos;
    public GameObject Self;
    private Rigidbody rb;
    public bool caught;
    public GameObject bobber;
    public GameObject text;
    public MeshRenderer textmesh;
    public InputActionReference toggleReference = null;
    public AudioSource hooked;
    public AudioSource win;

    // Start is called before the first frame update
    void Start()
    {
        toggleReference.action.started += Toggle;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bobber")
        {
            Debug.Log("Touching");
            other.gameObject.tag = "Untagged";
            attach(BaitPos);
            rb.useGravity = false;
            hooked.Play();
            //bobber = other.gameObject.transform.position;
            caught = true;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            GetComponent<AIController>().enabled = false;
        }
    }
    void attach(Transform newspot)
    {
        Self.transform.SetParent(newspot, true);
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        Debug.Log("perhaps");

        if (caught)
        {
            Self.transform.position = bobber.transform.position;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            textmesh.enabled = true;
            win.Play();
        }


    }
}
