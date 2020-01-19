using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private float currentLockRotation;
    public GameObject circle;
    public float goal;
    public bool done;

    private void Update()
    {
        Vector3 rotVector = circle.transform.eulerAngles;
        currentLockRotation = rotVector.x;

        if (rotVector.z == 90.0)
        {
            currentLockRotation = 90 + (90 - rotVector.x);
            if (currentLockRotation < 0)
            {
                currentLockRotation += 360;
            }
        }
        Debug.Log(circle.name + " " + currentLockRotation);
        if((currentLockRotation >= (goal-20)) && (currentLockRotation <= (goal + 20))){
            done = true;
        }
        else
        {
            done = false;
        }

    }
    
}
