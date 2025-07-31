using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioSourceController : MonoBehaviour
{
    public static AudioSourceController Instance;
    public Sound_Index[] SFXLable;
    public AudioSource  SFX_Src;
    #region AWAKE
    private void Awake()
    {
        if (Instance == null)//if there is no instance in the audio source
        {
            Instance = this;//set instance to the index of the sound name.
            DontDestroyOnLoad(gameObject);//do not destroy
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    public void PlaySFX(string Name)
    {
        Sound_Index s = Array.Find(SFXLable, X => X.Sound_Name == Name);

        if (s == null)
        {
            Debug.Log("Sound Error");
        }
        else
        {
            SFX_Src.clip = s.SoundClip;
            SFX_Src.Play();
        }
    }
}