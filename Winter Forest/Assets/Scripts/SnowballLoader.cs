using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballLoader : MonoBehaviour
{
    public SnowballCannon cannon;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "snowball")
        {
            cannon.LoadSnowball(other.gameObject);
        }
    }
}
