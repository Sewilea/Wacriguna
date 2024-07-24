using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioSource Click;

    public void ClickMusic()
    {
        Click.Play();
    }
}
