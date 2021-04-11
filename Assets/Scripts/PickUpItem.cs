using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PickUpItem : MonoBehaviour, IInteractable
{
    public string DisplaySprite;
    private GameObject _inventorySlots;

    public enum property
    {
        usable, displayable
    };

    public property itemProperty; 

    void Start()
    {
        _inventorySlots = GameObject.Find("Slots");
    }

    void Update()
    {
        
    }

    public void Interact(Wachsbleiche _currentDisplay)
    {
        ItemPickUp(); 
    }

    // Put clicked item in first free inventory box and destroy item in scene
    void ItemPickUp()
    {
        foreach (Transform slot in _inventorySlots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite
                    = Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                slot.GetComponent<Slot>().AssignProperty((int) itemProperty);  // comment out to make key disappear again 
                Destroy(gameObject);
                break;
            }
        }
    }
}