using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Buttons : MonoBehaviour
{

    Verb verb;
    public bool pressed = false;
    private TextMeshProUGUI buttonText;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        verb = FindObjectOfType<Verb>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(verb.currentVerb == Verb.Action.walk)
        {
            buttonText.color = new Color32(255, 255, 255, 255);
            
        }
        if (verb.buttonPressed != this.gameObject)
        {
            buttonText.color = new Color32(255, 255, 255, 255);

        }


        //OnMouseDown();
        if (this.gameObject.activeSelf == false)
        {
            pressed = false;
        }
    }


     public void mausDruck()
    {
        print("Maus war gedrückt"); 
        pressed = true; 
        verb.getButton(this.gameObject.name);
        verb.buttonPressed = this.gameObject;
        buttonText.color = new Color32(255, 0, 214, 255);

        


    }

     public void Reset()
     {
         pressed = false;
     }
}
