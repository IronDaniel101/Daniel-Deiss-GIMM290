using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Mmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
