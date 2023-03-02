using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

//attach to xr origin

public class Target : MonoBehaviour
{
    public GameObject rayInteractor;
    public GameObject ring;
    public GameObject rodObject;
    bool hasfishingrod;
    bool handFree;
    bool targetAvailability;
    bool targetActive;

    float lastCheckedTriggerPosition;

    public GameObject reticle;
    Vector3 reticlePos;
    Vector3 reticleNormal;


    public InputActionProperty triggerDown;

    void Start()
    {
        rayInteractor.SetActive(false);
        handFree = true;

    }

    void Update()
    {
        float triggerHeld = triggerDown.action.ReadValue<float>();



        if (triggerHeld > 0.1f && lastCheckedTriggerPosition != triggerHeld)
        {
            ActivateTarget();
        }

        //hasfishingrod = rodObject.GetComponent<Casting>().hasFishingRod;

        if (hasfishingrod == true && handFree == true)
        {
            targetAvailability = true;
        }
        else if (hasfishingrod == false || handFree == false)
        {
            targetAvailability = false;
        }

        if (targetActive && targetAvailability == false)
        {
            rayInteractor.SetActive(false);
            targetActive = false;
        }

        lastCheckedTriggerPosition = triggerHeld;
    }



    public void ActivateTarget()
    {
        bool triggerPress = true;

        if (triggerPress && targetAvailability && !targetActive)
        {
            targetActive = true;
            //activate teleport line renderer in left hand
            rayInteractor.SetActive(true);
            triggerPress = false;
        }

        if (triggerPress && targetAvailability && targetActive)
        {
            rayInteractor.GetComponent<XRRayInteractor>().TryGetHitInfo(out reticlePos, out reticleNormal, out _, out _);

            ring.transform.position = reticlePos;

            rayInteractor.SetActive(false);
            targetActive = false;
            triggerPress = false;
        }
    }
}
