using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    public GameObject fallingItem;
    public GameObject fallingTrap;
    private float spawnRate = 10f;
    private float nextSpawn=0;
    private bool hasSpawned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn) // if time is greater than nextSpawn spawn object
        {
            
            nextSpawn = Time.time + spawnRate;
            hasSpawned = false;
        }

        if (hasSpawned == false)
        {
            Instantiate(fallingTrap, new Vector3(this.transform.position.x + 10, 20, 0), Quaternion.identity);
            Instantiate(fallingItem, new Vector3(this.transform.position.x + 12, 20, 0), Quaternion.identity);
            hasSpawned = true;
        }
        
    }


    private void instantiateItem()
    {
        //Debug.Log("Dins instantiate falling item");
        Instantiate(fallingItem, new Vector3(this.transform.position.x + 10, 20, 0), Quaternion.identity);
    }

    private void instantiateTrap()
    {

        Instantiate(fallingTrap, new Vector3(this.transform.position.x + 10, 20, 0), Quaternion.identity);

    }

    private void fiveTraps()
    {
        for (int i = 0; i < 10; i = i + 2)
        {
            Invoke("instantiateTrap", (float)i);
        }
    }
}
