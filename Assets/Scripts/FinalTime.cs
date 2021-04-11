using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour
{
    private GameObject _timer;
    private GameObject _finished;

    public Text timerText; 
    // Start is called before the first frame update
    void Start()
    {
        _timer = GameObject.Find("TimerText");
        _finished = GameObject.Find("Wachsbleiche");
    }

    // Update is called once per frame
    void Update()
    {
        if (_finished.GetComponent<Wachsbleiche>().finished == true)
        {
            timerText.text = _timer.GetComponent<Text>().text;
        }
    }
}
