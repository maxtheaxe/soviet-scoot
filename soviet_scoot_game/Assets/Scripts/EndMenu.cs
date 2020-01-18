using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("OwenTestScene");
        // set the right name
    }

    public void Quit()
    {
        Application.Quit();
    }
}
