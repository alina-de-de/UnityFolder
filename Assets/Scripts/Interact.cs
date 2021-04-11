using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Interact : MonoBehaviour
{

    private Wachsbleiche _currentDisplay; 
    
    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("Wachsbleiche").GetComponent<Wachsbleiche>();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        // if we click with mouse, we zoom in to that point 
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);
            // if we hit interactable object, we interact with this object
            if (hit && hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<IInteractable>().Interact(_currentDisplay);
            }
            
        }
    }
}