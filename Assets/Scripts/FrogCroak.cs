using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySelfAudio : MonoBehaviour
{
    public AudioSource thisSound;

    private void OnMouseDown(){
        thisSound.Play();
    }
}
