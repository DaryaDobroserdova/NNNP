using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassmatesHelp : MonoBehaviour
{
    public Text t;
    private int click;
    public Text podskazka;
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
            click++;
            t.GetComponent<PrintedText>().skip = true;
            if (click % 2 == 0)
            {
                podskazka.gameObject.SetActive(false);
                sm.NextScene(4);
            }
            else
            {
                podskazka.gameObject.SetActive(true);
            }
        }
    }
}
