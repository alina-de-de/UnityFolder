using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private GameObject _inventory;

    public enum property
    {
        usable,
        displayable, 
        empty
    };

    public property ItemProperty { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _inventory.GetComponent<Inventory>().previousSelectedSlot =
            _inventory.GetComponent<Inventory>().currentSelectedSlot;
        _inventory.GetComponent<Inventory>().currentSelectedSlot = this.gameObject;

    }

    public void AssignProperty(int orderNumber)
    {
        ItemProperty = (property) orderNumber; 
        
    }
}