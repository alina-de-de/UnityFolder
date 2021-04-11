using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{
    public Text timerText;

    private float _startTime;

    private GameObject _display; 
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = 7f;
        _display = GameObject.Find("Wachsbleiche");
    }

    // Update is called once per frame
    void Update()
    {
        if (_display.GetComponent<Wachsbleiche>().finished == true)
        {
            return;
        }

        if (Time.time > 7f)
        {
            float t = Time.time - _startTime;
            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;      
        }
    }
}
