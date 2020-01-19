using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    public AudioSource collect;
    public AudioSource music;
    private bool mutex = false;
    public AudioSource wind;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("1 " + lock1.GetComponent<Lock>().done);
        Debug.Log("2 " + lock2.GetComponent<Lock>().done);
        Debug.Log("3" + lock3.GetComponent<Lock>().done);
        if (lock1.GetComponent<Lock>().done && lock2.GetComponent<Lock>().done && lock3.GetComponent<Lock>().done && !mutex)
        {
            Debug.Log("YO");
            //snow.SetActive(true);
            //Debug.Log(snow);
            collect.Play(0);
            mutex = true;
            music.Play(0);
            wind.Stop();
        }
    }
}
