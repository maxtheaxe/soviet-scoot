using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public Story story;
    private bool First = false;

    public void TriggerStory()
    {
        if (First == false)
        {
            FindObjectOfType<StoryManager>().StartStory(story);
            First = true;
        }
        else
        {
            FindObjectOfType<StoryManager>().DisplayNextSentence();
        }
    }

}
