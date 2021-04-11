using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManage : MonoBehaviour
{
    private Wachsbleiche _currentDisplay; 
    public GameObject[] ObjectsToManage; 
    
    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("Wachsbleiche").GetComponent<Wachsbleiche>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ManageObjects();
    }

    void ManageObjects()
    {
        for (int i = 0; i < ObjectsToManage.Length; i++)
        {
            if (ObjectsToManage[i].name == _currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else
            {
                ObjectsToManage[i].SetActive(false);
            }
        }
    }
}