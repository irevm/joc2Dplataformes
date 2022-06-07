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
        if (sndManager.isMusicEnabled){
            togMusic.isOn = true;
        } else {
            togMusic.isOn = false;
        }
         if (sndManager.isFxEnabled){
            togFx.isOn = true;
        } else {
            togFx.isOn = false;
        }
    }
    
    public void EnableMusic(){
        PlayerPrefs.SetInt("music", togMusic.isOn==true?1:0);
       
        if(togMusic.isOn){            
            sndManager.SetMusicEnabled(true);
        } else {
            sndManager.SetMusicEnabled(false);
        }       
    }

    public void EnableFx(){
        PlayerPrefs.SetInt("fx", togFx.isOn==true?1:0);
       
        if(togFx.isOn){
            sndManager.SetFxEnabled(true);
        } else {
            sndManager.SetFxEnabled(false);
        }       
    }
}
