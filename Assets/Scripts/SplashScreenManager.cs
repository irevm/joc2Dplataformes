using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadMainMenu", 2f);  //2 = Delay
    }

    void loadMainMenu() {
        SceneManager.LoadScene(1); 
    }
}
