using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;
    public float minY, maxY;

    float timer;
    public float maxTime;

    // List to keep track of spawned columns
    private List<GameObject> spawnedColumns = new List<GameObject>();

    void Start()
    {
        SpawnColumn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            SpawnColumn();
            timer = 0;
        }
    }

    void SpawnColumn()
    {
        float randomYPosition = Random.Range(minY, maxY);

        // Create a copy of the prefab
        GameObject newColumn = Instantiate(columnPrefab);
        newColumn.transform.position = new Vector2(transform.position.x, randomYPosition);

        // Add the spawned column to the list
        spawnedColumns.Add(newColumn);
    }

    // Function to destroy all spawned columns
    public void DestroyAllColumns()
    {
        foreach (var column in spawnedColumns)
        {
            Destroy(column);
        }
        spawnedColumns.Clear(); // Clear the list
    }
}
