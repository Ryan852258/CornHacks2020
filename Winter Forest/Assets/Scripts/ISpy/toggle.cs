using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class toggle : MonoBehaviour
{

    public Hand hand;

    SteamVR_Input_Sources correctHand;
    RaycastHit hit;

    private LineRenderer line;
    public GameObject lazer;
    // Start is called before the first frame update
    void Start()
    {

        line = lazer.GetComponent<LineRenderer>();
        line.SetPosition(1, new Vector3(0, 0, 0));

    }


    void Update()
    {
        hand = this.transform.GetComponentInParent<Interactable>().attachedToHand;
        if (hand)
        {
            correctHand = hand.handType;
        }

        if (SteamVR_Actions.default_GrabPinch.GetStateDown(correctHand))
        {

            if (hand != null)
            {
                ShootRay();
            }
        } else
        {
            line.SetPosition(1, new Vector3(0, 0, 0));
        }

    }

    void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(lazer.transform.position, lazer.transform.forward, out hit))
        {
            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.transform.parent.gameObject.name);
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
            }

        }
    }
}
