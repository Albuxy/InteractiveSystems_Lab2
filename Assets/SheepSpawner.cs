using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; // 1
    public GameObject sheepPrefab; // 2
    public List<Transform> sheepSpawnPositions = new List<Transform>(); // 3 
    public List<GameObject> sheepList = new List<GameObject>();
    public float timeBetweenSpawns;    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnSheep() 
    {
	Vector3 randomPosition = sheepSpawnPositions[Random.Range(0,sheepSpawnPositions.Count)].position; // 1
	GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // 2
	sheepList.Add(sheep); // 3
	sheep.GetComponent<Sheep>().SetSpawner(this); // 4 
    }
    private IEnumerator SpawnRoutine() // 1 
    {
	while (canSpawn) // 2 
	{
		SpawnSheep(); // 3
		yield return new WaitForSeconds(timeBetweenSpawns); // 4 
    	}
    }
    public void RemoveSheepFromList(GameObject sheep) 
    {
	sheepList.Remove(sheep); 
    }
}


