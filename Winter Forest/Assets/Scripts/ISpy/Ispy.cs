using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ispy : MonoBehaviour
{
    private List<string> animals = new List<string>();
    string current_animal;
    public TextMeshPro text;
    private 
    // Start is called before the first frame update
    void Start()
    {
    // init animal kingdom 
        animals.Add("brown fox");
        animals.Add("red fox");
        animals.Add("blue ray");
        animals.Add("cardinal");
        animals.Add("crow");
        animals.Add("black squirel");
        animals.Add("brown squirel");

        // Get a random element and remove it from the list 
        var index = Random.Range(0, animals.Count);
        current_animal = animals[index];
        animals.RemoveAt(index);
        text.SetText("a " + current_animal + ".");


    }

    // function to check lazer hits
    void CheckHit(string tag)
    {
        if (tag == current_animal && animals.Count != 0)
        {
            var index = Random.Range(0, animals.Count);
            current_animal = animals[index];
            animals.RemoveAt(index);
            text.SetText("a " + current_animal);
        } else if (animals.Count <= 0)
        {
            text.SetText("a winner!");
        }
    }
}
