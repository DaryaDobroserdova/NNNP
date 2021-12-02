using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrologEnd : MonoBehaviour
{
    //public VideoPlayer videoPlayer;
    public List<GameObject> scenes;
    public Text podskazka;
    int click;
    ScenesManager sm = new ScenesManager();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (videoPlayer.isPaused)
        //    NextScene(2);
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }
    public void Next()
    {
        click++;
        if (scenes.Count > 1)
        {
            if (click % 2 == 0)
            {
                scenes[0].SetActive(false);
                scenes.RemoveAt(0);
                scenes[0].SetActive(true);
                podskazka.gameObject.SetActive(false);
            }
            else
            {
                scenes[0].GetComponent<PrintedText>().skip = true;
                podskazka.gameObject.SetActive(true);
            }
        }
        else
            sm.NextScene(2);
    }
}
