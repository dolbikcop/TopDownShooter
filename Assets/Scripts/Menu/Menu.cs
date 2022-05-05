using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Kek()
    {
        Debug.Log("KEK");
    }
    public void Play() => SceneManager.LoadScene(1);
    public void Exit() => Application.Quit();
}
