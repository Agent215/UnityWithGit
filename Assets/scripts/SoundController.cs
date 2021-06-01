using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource[] sound;
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    // Start is called before the first frame update
    void Start()
    {

        sound = GetComponents<AudioSource>();
        sound1 = sound[0];
        sound2 = sound[1];
        sound3 = sound[2];


    }


    public void playCashRegisterSound()
    {

        sound1.Play();
    }

    public void playPackingSound()
    {

        sound2.Play();
    }


    public void playButtonClick()
    {

        sound3.Play();
    }
}
