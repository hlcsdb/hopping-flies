using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMyAudio : MonoBehaviour
{
    public AudioSource audS;
    public AudioClip aud;
     

    public void OnClick()
    {
        Debug.Log("croak");
        audS.PlayOneShot(aud);
    }
}
