using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject itemBall;
    public GameObject trapBall;

    int nBalls = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nBalls < 3)
            instantiateBall();
        nBalls++;

        if (this.transform.position.y < -20)
        {
            Destroy(this);
            nBalls--;
        }
        
    }


    private void instantiateBall()
    {
        Instantiate(this, new Vector3(70, 10, 0), Quaternion.identity);
    }
}
