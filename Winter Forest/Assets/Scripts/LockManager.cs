using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    public GameObject snow;
    public AudioSource collect;

    // Update is called once per frame
    void Update()
    {
        if (lock1.GetComponent<Lock>().done && lock2.GetComponent<Lock>().done && lock3.GetComponent<Lock>().done)
        {
            snow.SetActive(true);
            collect.Play();
            SoundManager.tracker++;
        }
    }
}
