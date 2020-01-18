using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Playgame()
    {
        SceneManager.LoadScene("OwenTestScene");
    }

    public void ShowRule()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
