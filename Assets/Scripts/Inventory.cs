using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Inventory : MonoBehaviour
{
    public GameObject currentSelectedSlot { get; set; }
    public GameObject previousSelectedSlot { get; set; }

    private GameObject _slots;
    //
    private GameObject _finished; 
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
        _slots = GameObject.Find("Slots");
        _finished = GameObject.Find("Wachsbleiche");
    }

    // Update is called once per frame
    void Update()
    {
        SelectSlot();
        if (_finished.GetComponent<Wachsbleiche>().finished == true)
        {
            Destroy(gameObject);
        }
    }
    
    void InitializeInventory()
    {
        var slots = GameObject.Find("Slots");
        foreach (Transform slot in slots.transform)
        {
            slot.transform.GetChild(0).GetComponent<Image>().sprite
                = Resources.Load<Sprite>("Inventory Items/empty_item");
        }
    }

    void SelectSlot()
    {
        foreach (Transform slot in _slots.transform)
        {
            if (slot.gameObject == currentSelectedSlot && slot.GetComponent<Slot>().ItemProperty == Slot.property.usable)
            {
                slot.GetComponent<Image>().color = new Color(0.2735849f, .2735849f, .2735849f, 1); 
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}