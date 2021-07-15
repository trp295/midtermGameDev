using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{

    public GameObject collectiblePrefab;
    public float spawnIntervals = 5.0f;
    public float timeSinceLastSpawn = 0f; //timer
    int spawnID = 0;

    public GameObject spawnParent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //spawn a collectible
    public void SpawnNewCollectible()
    {
        float randomYPosition = Random.Range(-3.0f, 1.0f);
        float randomXPosition = Random.Range(-6.0f, 6.0f);
    
        Vector2 spawnPosition = new Vector2(randomXPosition, randomYPosition);

        GameObject newCollectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        newCollectible.transform.parent = spawnParent.transform;
        newCollectible.name = "Collectible_" + spawnID;
        spawnID++;
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn > spawnIntervals)
        {
            SpawnNewCollectible();
            timeSinceLastSpawn = 0f;
        }
    }
}
