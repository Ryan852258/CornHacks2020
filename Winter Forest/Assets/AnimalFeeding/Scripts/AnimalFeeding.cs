using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFeeding : MonoBehaviour
{
    public GameObject[] animals;
    int current;
    int count = 0;
    //Random random = new Random();

    void Start()
    {
        current = Random.Range(0, 10);
        animals[current].SetActive(true);
    }

    public void Hit()
    {
        animals[current].SetActive(false);
        count++;
        if(count >= 9)
        {
            //do
        }
        else
        {
            int next = Random.Range(0, 10);
            // int i = random.Next(animals.Count);
            while(next == current)
            {
                next = Random.Range(0, 10);
            }
            animals[current].SetActive(false);
            animals[next].SetActive(true);
            current = next;
        }
    }
}
