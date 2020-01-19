using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class toggle : MonoBehaviour
{

    public Hand hand;
    SteamVR_Input_Sources correctHand;
    RaycastHit hit;
    bool lazertoggle;
    private LineRenderer line;
    public GameObject lazer;
    private string last_obj;
    private float time;
    public GameObject game;

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
                lazertoggle = true;
            }
        }
        else if (SteamVR_Actions.default_GrabPinch.GetStateUp(correctHand)) 
        {
            lazertoggle = false;
        }
        
        if (lazertoggle)
        {
            RaycastHit hit;
            if (Physics.Raycast(lazer.transform.position, lazer.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    line.SetPosition(1, new Vector3(0, 0, hit.distance));
                    
                    if (last_obj == hit.collider.tag && (Time.time - time) >= 1 && hit.collider.tag != "Untagged")
                    {
                        game.SendMessage("CheckHit", hit.collider.tag);
                    } else if(last_obj != hit.collider.tag)
                    {
                        time = Time.time;
                        last_obj = hit.collider.tag;
                    } 

                }
                else
                {
                    line.SetPosition(1, new Vector3(0, 0, 1500f));
                }

            }
        } else if (!lazertoggle)
        {
            line.SetPosition(1, new Vector3(0, 0, 0));
        }

    }
}
