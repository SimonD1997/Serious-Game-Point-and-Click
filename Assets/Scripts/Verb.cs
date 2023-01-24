using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;


public class Verb : MonoBehaviour
{

    //Übersicht aller Buttons:
    public string use ="Use ";
    public string pickUp ="Pick up ";
    public string look = "Look at ";
    public string talk = "Talk to ";

    public GameObject IndicatorUse;
    public GameObject IndicatorPickup;
    public GameObject IndicatorTalkto;
    public GameObject IndicatorLookat;

    public Flowchart UseFlowchart;
    public Flowchart lookFlowchart;
    public Flowchart talkFlowchart;
    public Flowchart pickFlowchart;

    public string verbString = "Walk to ";

    public TextMeshProUGUI verbTextBox;

    public enum Action {walk, use, pickup, talkto, lookat}

    public Action currentVerb = Action.walk;
    public GameObject buttonPressed;

    private void Start()
    {
        verbTextBox = GetComponentInChildren<TextMeshProUGUI>();
        verbTextBox.text = "Walk to ";
    }
 

    public void getButton(string button)
    {
        if (button == pickUp)
        {
            currentVerb = Action.pickup;
            verbString = "Pick up ";
            verbTextBox.text = verbString;
            FlowChartAus(); // Das die Flowcharts aus gehen auch wenn der Button gewechselt wird.
            pickFlowchart.gameObject.SetActive(true);
            print("pickup");      
        } else if (button==use)
        {
            currentVerb = Action.use;
            verbString = "Use ";
            verbTextBox.text = verbString ;
            FlowChartAus();
            UseFlowchart.gameObject.SetActive(true);
            print("use");   
        }
        else if (button==look)
        {
            currentVerb = Action.lookat;
            verbString = "Look at ";
            verbTextBox.text = verbString;
            FlowChartAus();
            lookFlowchart.gameObject.SetActive(true);
            print("look");          
        }
        else if (button==talk)
        {
            currentVerb = Action.talkto;
            verbString = "Talk to ";
            verbTextBox.text = verbString;
            FlowChartAus(); 
            talkFlowchart.gameObject.SetActive(true);
            print("talk");           
        }

    }

    public void setBackToWalk()
    {
        if (UseFlowchart.HasExecutingBlocks() || lookFlowchart.HasExecutingBlocks() || talkFlowchart.HasExecutingBlocks())
        {
            return;
        }

        
         currentVerb = Action.walk;


        

        UseFlowchart.gameObject.SetActive(false);
        lookFlowchart.gameObject.SetActive(false);
        talkFlowchart.gameObject.SetActive(false);
        pickFlowchart.gameObject.SetActive(false);
        
        

    }

    private void Update()
    {
        if(currentVerb == Action.walk)
        {
            setBackToWalk();  
        }
    }

    public void FlowChartAus()
    {
        while (UseFlowchart.HasExecutingBlocks() || lookFlowchart.HasExecutingBlocks() || talkFlowchart.HasExecutingBlocks() || pickFlowchart.HasExecutingBlocks())
        {
            
        }

        //currentVerb = Action.walk;


        // Walk String im Movement setzen!!!

        //UseFlowchart.gameObject.SetActive(false);
        lookFlowchart.gameObject.SetActive(false);
        talkFlowchart.gameObject.SetActive(false);
        pickFlowchart.gameObject.SetActive(false);
    }
}
