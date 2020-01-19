using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public string flashlight; //used to determine which flashlight is being used (yellow or purple)

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag.Equals(flashlight)) //checks to see if the thing the flashlight is pointed at has been tagged with a flashlight color
        {
            other.GetComponent<MeshRenderer>().enabled = true; //if it was tagged, make the object visible
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals(flashlight)) //checks to see if the thing the flashlight just left a tagged object with a flashlight color
        {
            other.GetComponent<MeshRenderer>().enabled = false; //if it was tagged, make the object invisible
        }
    }
}
