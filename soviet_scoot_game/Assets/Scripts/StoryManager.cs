using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoryManager : MonoBehaviour
{
    private Queue<string> Stories;
    public Text storytext;
    public Button SkipButton;
      

    void Start()
    {
        Stories = new Queue<string>();
    }

    public void StartStory(Story story)
    {
        //Debug.Log("start");
        Stories.Clear();
        foreach (string sentence in story.stories)
        {
            Stories.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Stories.Count == 1)
        {
            EndDialog();
        }
        else if (Stories.Count == 0)
        {
            Skip();
            return;
        }
        string sentence = Stories.Dequeue();
        storytext.text = sentence;
    }

    public void EndDialog()
    {
        SkipButton.gameObject.SetActive(false);
    }

    public void Skip()
    {
        //move to the right scene
        SceneManager.LoadScene("tutorial");
    }
}
