using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }
    public void Continue()
    {
        gm.SetCoins(gm.GetCoins() - gm.minCoinCount);
        SceneManager.LoadScene("OwenTestScene");
        // set the right name
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("mainscreen");
        // set the right name
    }

    public void Quit()
    {
        Application.Quit();
    }
}
