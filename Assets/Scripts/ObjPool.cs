using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour {

    public int columnPoolsize = 4;
    public GameObject columnPrefab;
    public GameObject columnPrefab2;
    public GameObject columnPrefab3;
    public GameObject columnPrefab4;
    public GameObject columnPrefab5;
    public float spawnRate = 4f;
    public float columnMin = -3f;
    public float columnMax = -2f;

    private GameObject[] columns;
    private Vector2 objectPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 3f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start ()
    {
        columns = new GameObject[columnPoolsize];
        for (int i=0; i<columnPoolsize; i++)
        {
            if (i == 0)
            {
                columns[i] = (GameObject)Instantiate(columnPrefab, objectPosition, Quaternion.identity);
            }
            else if (i==1)
            {
                columns[i] = (GameObject)Instantiate(columnPrefab2, objectPosition, Quaternion.identity);
            }
            else if (i == 2)
            {
                columns[i] = (GameObject)Instantiate(columnPrefab3, objectPosition, Quaternion.identity);
            }
            else if (i == 3)
            {
                columns[i] = (GameObject)Instantiate(columnPrefab5, objectPosition, Quaternion.identity);
            }
            else if (i == 4)
            {
                columns[i] = (GameObject)Instantiate(columnPrefab4, objectPosition, Quaternion.identity);
            }

        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        timeSinceLastSpawned += Time.deltaTime;
        
        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolsize)
            {
                currentColumn = 0;
            }
        }
	}
}
