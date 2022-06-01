using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject itemBall;
    int nItems = 0;
    
    public void DestroyItem() {
        Destroy(this.gameObject);
    }


    public void Start()
    {
        InstantiateBall();
    }
    public void Update()
    {
        
        

        if (itemBall.transform.position.y < -20)
        {
            Destroy(itemBall);
            InstantiateBall();

        }
    }

    

public void InstantiateBall()
    {
        Instantiate(itemBall, new Vector3(70, 10, 0), Quaternion.identity);
    }


}
