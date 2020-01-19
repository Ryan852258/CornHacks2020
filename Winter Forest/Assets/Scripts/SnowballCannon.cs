using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SnowballCannon : MonoBehaviour
{
    public float firingAngle = 0.0f;
    public float firingVelocity = 2.0f;
    public GameObject snowballPrefab;
    public Transform snowballSpawnPosition;
    public int maxCapacity = 3;
    public int currentCapacity = 0;
    private Hand hand;
    private SteamVR_Input_Sources correctHand;

    public void LoadSnowball(GameObject snowball)
    {
        // if the cannon is firing ignore the snowball
        if (snowball.GetComponent<Interactable>().attachedToHand && currentCapacity < maxCapacity)
        {
            Destroy(snowball);
            currentCapacity += 1;
        }
    }

    void Update()
    {
        hand = this.transform.GetComponentInParent<Interactable>().attachedToHand;

        if (hand)
        {
            correctHand = hand.handType;
        }

        if (hand && SteamVR_Actions.default_GrabPinch.GetStateDown(correctHand))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (currentCapacity > 0)
        {
            // fire a snowball
            // spawn the snowball
            GameObject snowball = Instantiate(snowballPrefab, snowballSpawnPosition.position, Quaternion.identity) as GameObject;

            // apply force to the snowball
            Rigidbody rb = snowball.GetComponent<Rigidbody>();
            rb.AddForce(-1 * transform.forward * firingVelocity * 500);

            currentCapacity -= 1;
        }
        else
        {
            // play an empty noise
        }
    }
}
