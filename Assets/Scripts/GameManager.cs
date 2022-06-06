using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numItems = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if(objs.Length > 1){
           Destroy(this.gameObject); 
        }

        DontDestroyOnLoad(this.gameObject); //Perquè no s'elimini es game object, per evitar talls de so en canviar escena
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
