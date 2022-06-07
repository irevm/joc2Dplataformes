using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource asMusic;
    public AudioSource asFx;

    public bool isMusicEnabled = true;
    public bool isFxEnabled = true;

    public float musicVolume;
    public float fxVolume;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip jumpFx;
    public AudioClip collectedFx;
    public AudioClip finishFx;
    public AudioClip deadFx;
    public AudioClip spawnFx;

    // Start is called before the first frame update
    void Start() {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");
        if(objs.Length > 1){
           Destroy(this.gameObject); 
        }

        if(PlayerPrefs.GetInt("music") == 1){
            isMusicEnabled = true;
        } else {
            isMusicEnabled = false;
        }

        if(PlayerPrefs.GetInt("fx") == 1){
            isFxEnabled = true;
        } else {
            isFxEnabled = false;
        }

        DontDestroyOnLoad(this.gameObject); //Perquè no s'elimini es game object, per evitar talls de so en canviar escena
        PlayMusic(0);
    }

    public void PlayMusic(int i) {
        if(isMusicEnabled){

            if (i==0)
                asMusic.clip = menuMusic;
            else if (i==1)
                asMusic.clip = gameMusic;

            //asMusic.vol
            asMusic.enabled = true;
            asMusic.loop = true;
            asMusic.Play();
        } 
    }

    public void PlayFx(int i) {
        
        if(isFxEnabled){

            if(i==0)
                asFx.clip = jumpFx;
            else if (i==1)
                asFx.clip = collectedFx;
            else if (i==2)
                asFx.clip = finishFx;
            else if (i==3)
                asFx.clip = deadFx;
            else
                asFx.clip = spawnFx;
            asFx.enabled = true;
            asFx.loop = false;
            asFx.Play();
        }
    }

    public void StopMusic(){
        asMusic.Stop();    
    }

    public void SetMusicEnabled(bool b){
        isMusicEnabled = b;
        if(!isMusicEnabled)
            StopMusic();
        else 
            PlayMusic(0);
    }

    public void SetFxEnabled(bool b){
        isFxEnabled = b;
    }
}
