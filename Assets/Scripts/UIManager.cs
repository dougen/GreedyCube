using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{

    public void Play()
    {
        Application.LoadLevel(0);
        GetComponent<AudioSource>().Play();
    }
}
