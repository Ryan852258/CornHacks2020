using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    // Update is called once per frame
    void Update()
    {
        if (lock1.GetComponent<Lock>().done && lock2.GetComponent<Lock>().done && lock3.GetComponent<Lock>().done)
        {
            Debug.Log("all done all done all done");
        }
    }
}
