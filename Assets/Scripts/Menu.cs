using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string playGameLevel;


    public void Play()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

}