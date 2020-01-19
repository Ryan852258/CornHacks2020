using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedCheck : MonoBehaviour
{
    public string collisionTag;
    AnimalFeeding driver;

    private void Start()
    {
        driver = this.gameObject.transform.root.GetComponent<AnimalFeeding>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(collisionTag))
        {
            driver.Hit();
        }
    }
}
