using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DestroyAfterPeriod : MonoBehaviour
{
    public float lifespan = 7.0f;
    private float currentLife = 0.0f;
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = gameObject.GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand == null)
        {
            if (currentLife > lifespan)
            {
                Destroy(gameObject);
            }
            currentLife += Time.deltaTime;
        }
        else
        {
            currentLife = 0.0f;
        }
    }
}
