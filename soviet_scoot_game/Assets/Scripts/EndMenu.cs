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
        GameManager.Instance.ResetDifficulty();
        gm.SetCoins(gm.GetCoins() - gm.minCoinCount);
        SceneManager.LoadScene(1);
        // set the right name
    }

    public void ToMainMenu()
    {
        GameManager.Instance.ResetDifficulty();
        gm.SetCoins(0);
        SceneManager.LoadScene("mainscreen");
        // set the right name
    }

    public void Quit()
    {
        gm.SetCoins(0);
        Application.Quit();
    }
}
