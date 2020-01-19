using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFeeding : MonoBehaviour
{
    public GameObject[] animals;
    int current;
    int count = 0;
    public GameObject good;
    public GameObject bad;
    public GameObject smoke;

    //Random random = new Random();

    void Start()
    {
        current = Random.Range(0, 9);
        animals[current].SetActive(true);
    }

    public void Hit()
    {
        animals[current].SetActive(false);
        count++;
        if(count >= 9)
        {
            smoke.SetActive(true);
            good.SetActive(true);
            bad.SetActive(false);
        }
        else
        {
            int next = Random.Range(0, 9);
            // int i = random.Next(animals.Count);
            while(next == current)
            {
                next = Random.Range(0, 9);
            }
            animals[current].SetActive(false);
            animals[next].SetActive(true);
            current = next;
        }
    }
}
