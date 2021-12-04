using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepSilent : MonoBehaviour
{
    public List<GameObject> scenes;
    public Text podskazka;
    private int click;
    ScenesManager sm = new ScenesManager();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
        if (scenes[0].GetComponent<PrintedText>().textEnd)
            podskazka.gameObject.SetActive(true);
    }

    public void Next()
    {
        if (scenes[0].GetComponent<PrintedText>().textEnd)
        {
            if (scenes.Count > 1)
            {
                scenes[0].SetActive(false);
                scenes.RemoveAt(0);
                scenes[0].SetActive(true);
                podskazka.gameObject.SetActive(false);
            }
            
        }
        else
            scenes[0].GetComponent<PrintedText>().skip = true;
    }
}
