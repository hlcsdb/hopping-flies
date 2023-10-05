using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    //Music
    public Button musicButton;
    public bool isMusicOn = true;
    public Sprite[] musicImages = new Sprite[2];
    public GameObject song;

    public void Start()
    {
        musicButton.GetComponent<Image>().sprite = musicImages[0];
    }

    public void musicOnOff()
    {
        if (isMusicOn)
        {
            isMusicOn = false;
            musicButton.GetComponent<Image>().sprite = musicImages[1];
            song.SetActive(false);
        }
        else if (!isMusicOn)
        {
            isMusicOn = true;
            musicButton.GetComponent<Image>().sprite = musicImages[0];
            song.SetActive(true);
        }
    }
}
