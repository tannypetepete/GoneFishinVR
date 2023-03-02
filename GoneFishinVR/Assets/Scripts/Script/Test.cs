using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




    public class Test : MonoBehaviour
    {
    public InputActionReference toggleReference = null;
    public GameObject Close;
    public GameObject Open;
    public GameObject Point;
    bool isPointing  =false;
    void Awake()
    {
    }
        void Start()
        {
        toggleReference.action.started += Toggle;
    }

        void Update()
        {
    }
    void Toggle(InputAction.CallbackContext context)
    {
        //Allows player to close hand but makes sure that player can't have the hand pointing at the same time
        isPointing = Point.active;
        if (isPointing == false)
        {
            bool isActive = !Close.active;
            bool isActiveO = !Open.active;
            Close.SetActive(isActive);
            Open.SetActive(isActiveO);
        }
    }
}
