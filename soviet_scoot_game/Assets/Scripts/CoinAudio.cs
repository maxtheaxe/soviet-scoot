using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{
    private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            //audio.Play();
        }
    }


}
