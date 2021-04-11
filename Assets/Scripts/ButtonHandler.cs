using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    private Wachsbleiche _currentDisplay;
    private float _initialCameraSize; //camera size before zoomed in 
    private Vector3 _initialCameraPosition; //camera position before zoomed in 

    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("Wachsbleiche").GetComponent<Wachsbleiche>();
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition = Camera.main.transform.position; 
    }
    
    //when we click right arrow
    public void OnRightClickArrow()
    {
        // when we click right arrow, we increase the wall by one 
        _currentDisplay.CurrentWall = _currentDisplay.CurrentWall + 1;
    }

    public void OnLeftClickArrow()
    {
        _currentDisplay.CurrentWall = _currentDisplay.CurrentWall - 1;
    }

    public void OnClickReturn()
    {
        // change state back to normal view, if in zoom state
        if (_currentDisplay.CurrentState == Wachsbleiche.State.zoom)
        {
            GameObject.Find("Wachsbleiche").GetComponent<Wachsbleiche>().CurrentState = Wachsbleiche.State.normal;
            var zoomInObjects = FindObjectsOfType<ZoomInObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0; //change layer back to 0
            }
            //change back to initial camera settings
            Camera.main.orthographicSize = _initialCameraSize; 
            Camera.main.transform.position = _initialCameraPosition;
        }
        else
        {
            // Change the view
            _currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/wall" + _currentDisplay.CurrentWall);
            // Change current State
            _currentDisplay.CurrentState = Wachsbleiche.State.normal; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
