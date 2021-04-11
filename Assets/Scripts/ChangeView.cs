using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using System; 

public class ChangeView : MonoBehaviour, IInteractable
{
    public string SpriteName;

    public void Interact(Wachsbleiche _currentDisplay)
    {
        //Load specific sprite from resources folder
        _currentDisplay.GetComponent<SpriteRenderer>().sprite = 
            Resources.Load<Sprite>("Sprites/" + SpriteName);
        _currentDisplay.CurrentState = Wachsbleiche.State.ChangedView; 

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}