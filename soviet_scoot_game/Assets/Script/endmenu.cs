using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endmenu : MonoBehaviour
{
    public void Continue()
    {
        ;
        SceneManager.LoadScene(0);
        // set the right index
    }

    public void Quit()
    {
        Application.Quit();
    }
}
