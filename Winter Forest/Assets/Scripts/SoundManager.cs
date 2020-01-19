using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static int tracker = 0;
    public int temp = 0;
    public AudioSource[] music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker > temp)
        {
            music[temp].Stop();
            music[tracker].Play();
            temp++;
        }
    }
}
