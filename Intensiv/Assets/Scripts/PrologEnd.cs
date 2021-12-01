using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrologEnd : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPaused)
            NextScene(2);
    }
    public void NextScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
