using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wachsbleiche : MonoBehaviour
{
    // Display states that the game can be in 
    public enum State
    {
        normal, zoom, ChangedView
    };
    
    public State CurrentState { get; set; }
    public int CurrentWall
    {
        get { return _currentWall; }
        set
        {
            if (value == 5)
                _currentWall = 1;
            else if (value == 0)
                _currentWall = 4;
            else
                _currentWall = value;
        }
    }
    private int _currentWall;
    private int _previousWall; 
    // 
    private GameObject _open; 
    public int unlocked;
    public bool finished = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _previousWall = 0;
        _currentWall = 1;
        // 
        _open = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        // check in every frame whether currentWall equals previousWall
        if (_currentWall != _previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + _currentWall.ToString()); 
        }
        _previousWall = _currentWall; 
        
        //
        if (unlocked == 5)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/finalescape");
            finished = true;
        }
    }
}