using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Playgame()
    {
        GameManager.Instance.ResetDifficulty();
        SceneManager.LoadScene(1);
    }

    public void ShowRule()
    {
        GameManager.Instance.ResetDifficulty();
        SceneManager.LoadScene("storyline");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
