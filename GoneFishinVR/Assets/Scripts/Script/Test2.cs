using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test2 : MonoBehaviour
{
    public InputActionReference toggleReference = null;
    public GameObject Point;
    public GameObject Open;
    public GameObject Closed;
    bool isClosed = false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        toggleReference.action.started += Toggle;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Toggle(InputAction.CallbackContext context)
    {
        isClosed = Closed.active;
        if (isClosed == false)
        {
            bool isActive = !Point.active;
            bool isActiveO = !Open.active;
            Point.SetActive(isActive);
            Open.SetActive(isActiveO);
        }
    }
}
