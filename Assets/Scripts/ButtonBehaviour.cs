using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChangeButton,
        returnButton
    }

    public ButtonId ThisButtonId;

    private Wachsbleiche _currentDisplay;
    private GameObject _finished; 


    // Start is called before the first frame update
    void Start()
    {
        _currentDisplay = GameObject.Find("Wachsbleiche").GetComponent<Wachsbleiche>();
        _finished = GameObject.Find("Wachsbleiche");
    }

    // Update is called once per frame
    void Update()
    {
        HideDisplay();
        Display();
        if (_finished.GetComponent<Wachsbleiche>().finished == true)
        {
            Destroy(gameObject);
        }
    }

    // Cases when buttons should not be displayed 
    void HideDisplay()
    {
        if (_currentDisplay.CurrentState == Wachsbleiche.State.normal && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(
                GetComponent<Image>().color.r,
                GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false; // can´t use that button now 
            this.transform
                .SetSiblingIndex(0); //set to zero because down button below in hierarchy //display = hide the button
        }

        if (!(_currentDisplay.CurrentState == Wachsbleiche.State.normal) && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(
                GetComponent<Image>().color.r,
                GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }

    // Cases when buttons can be displayed
    void Display()
    {
        // If State=Zoom and Button=Return
        if (!(_currentDisplay.CurrentState == Wachsbleiche.State.normal) && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(
                GetComponent<Image>().color.r,
                GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        // If State=Normal and Button=Roomchange
        if (_currentDisplay.CurrentState == Wachsbleiche.State.normal && ThisButtonId == ButtonId.roomChangeButton)
        {
            GetComponent<Image>().color = new Color(
                GetComponent<Image>().color.r,
                GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
        
        // The return button should appear everytime we zoom into the scene in the same scale as without the zoom. The buttons should behave as a fixed object.
        // At some point during our project, this stopped working. 
        // As we could not find out how to solve this problem,
        // we did a quick-fix with adding the return buttons in the correct scale and position for each frame where we added a ZoomInObject. 
    }
}
