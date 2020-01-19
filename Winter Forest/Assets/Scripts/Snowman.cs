using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    private bool counting = false;
    private int score;
    private float time;
    private SnowmanSpawner parent;

    void Update()
    {
        if (counting)
        {
            if (time <= 0) Fail();

            time -= Time.deltaTime;
        }
    }

    public void SetParent(SnowmanSpawner parent)
    {
        this.parent = parent;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public void StartTimer(float time)
    {
        this.time = time;
        counting = true;
    }

    private void Fail()
    {
        parent.Miss();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "snowball")
        {
            Win();
        }
    }

    private void Win()
    {
        parent.Score(score);
        Destroy(gameObject);
    }
}
