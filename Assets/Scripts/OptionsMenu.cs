using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle togMusic;
    public Toggle togFx;
    private SoundManager sndManager;

    void Start(){
        sndManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
    
    public void EnableMusic(){
        PlayerPrefs.SetInt("music", togMusic.isOn==true?1:0);
       
        if(togMusic.isOn){
            sndManager.PlayMusic(0);
        } else {
            sndManager.StopMusic();
        }       
    }
}
