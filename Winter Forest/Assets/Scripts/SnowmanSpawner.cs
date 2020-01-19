using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanSpawner : MonoBehaviour
{
    public float spawnFrequency = 4.0f;
    public int maxSpawns = 5;
    public int scoreToWin = 100;
    public int missPenalty = 3;
    public GameObject snowmanPrefab;
    public GameObject spawns;
    private List<GameObject> spawnList;
    private float secondsSinceLastSpawn = 0.0f;
    private int totalSnowmen = 0;
    public int score = 0;
    private bool gameComplete = false;
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        spawnList = new List<GameObject>();
        foreach (Transform child in spawns.transform)
        {
            spawnList.Add(child.gameObject);
        }
        Debug.Log("Game initialized");
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= scoreToWin && !gameComplete)
        {
            CompleteGame();
        }

        else if (!gameComplete)
        {
            if (secondsSinceLastSpawn >= spawnFrequency && totalSnowmen < maxSpawns)
            {
                SpawnSnowman();
                secondsSinceLastSpawn = 0.0f;
            }

            secondsSinceLastSpawn += Time.deltaTime;
        }
    }

    void SpawnSnowman()
    {
        Debug.Log("Spawning snowman");
        GameObject spawnLocation = ChooseRandomSpawnLocation();
        GameObject snowman = Instantiate(snowmanPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation) as GameObject;
        Snowman snowmanScript = snowman.GetComponent<Snowman>();
        snowmanScript.SetParent(this);
        ShootingGallerySpawn spawnScript = spawnLocation.GetComponent<ShootingGallerySpawn>();
        snowmanScript.SetScore(spawnScript.score);
        snowmanScript.StartTimer(spawnScript.time);
        totalSnowmen += 1;
        Debug.Log(System.String.Format("Total snowmen: {0}", totalSnowmen));
    }

    GameObject ChooseRandomSpawnLocation()
    {
        int i = random.Next(spawnList.Count);
        return spawnList[i];
    }

    public void Miss()
    {
        Debug.Log("You suck.");
        Debug.Log(score);
        totalSnowmen -= 1;
        if (score > 2) score -= missPenalty;
        else
        {
            score = 0;
        }
    }

    public void Score(int score)
    {
        Debug.Log("Hit!");
        Debug.Log(score);
        totalSnowmen -= 1;
        this.score += score;
    }

    void CompleteGame()
    {
        Debug.Log("You win!");
        gameComplete = true;
    }
}
