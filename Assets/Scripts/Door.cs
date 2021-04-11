using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI; 

public class Door : MonoBehaviour, IInteractable 
{
    public string UnlockItem;

    private GameObject _inventory; 
    //
    public int unlocked; 
    private GameObject _numberOfKeys;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory"); 
        //
        _numberOfKeys = GameObject.Find("Wachsbleiche");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact(Wachsbleiche _currentDisplay)

    {
        if (_inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0)
            .GetComponent<Image>().sprite.name == UnlockItem)
        {
            _inventory.GetComponent<Inventory>().currentSelectedSlot.GetComponent<Slot>().ItemProperty =
                Slot.property.empty;
            _inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0)
                .GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item");
            // if int is == 0 then the game is finished 
            _numberOfKeys.GetComponent<Wachsbleiche>().unlocked += 1;
            unlocked = _numberOfKeys.GetComponent<Wachsbleiche>().unlocked;
        }
    }
}