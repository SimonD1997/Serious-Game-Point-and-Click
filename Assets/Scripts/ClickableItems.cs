using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.EventSystems;

public class ClickableItems : MonoBehaviour , IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Inventar inventar;
    PickupItem pickupItem;

    public bool use;
    public bool pickup;
    public bool talkto;
    public bool lookat;

    public GameObject player;
    private CharakterMove charakterMove;

    private GameObject indicatorUse;
    private GameObject indicatorPickup;
    private GameObject indicatorTalkto;
    private GameObject indicatorLookat;
    public object[] showVerbs;
    private ArrayList showVerbsList;

    public  Verb.Action  standartAction;

    private bool isItemInRange;
    private bool itemWasPressend;

    Verb verb;
    public string verbstring = "";

    private string raycastString;

    public InventoryItems item;

    private void Start()
    {

        AddPhysics2DRaycaster();
        //showVerbs = new GameObject[4];
        verb = FindObjectOfType<Verb>();
        inventar = FindObjectOfType<Inventar>();
        pickupItem = PickupItem.CreateInstance<PickupItem>();
        charakterMove = FindObjectOfType<CharakterMove>();
        
        indicatorUse = verb.IndicatorUse;
        indicatorPickup = verb.IndicatorPickup;
        indicatorTalkto = verb.IndicatorTalkto;
        indicatorLookat = verb.IndicatorLookat;
        showVerbsList = new ArrayList();
        ShowVerbs();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (verb.currentVerb == Verb.Action.use && use == true && raycastString == this.gameObject.name)
        {
            verbstring = "Use ";
        }
        else if (verb.currentVerb == Verb.Action.pickup && pickup == true && raycastString == this.gameObject.name)
        {
            verbstring = "Pick Up ";
        }
        else if (verb.currentVerb == Verb.Action.lookat && lookat == true && raycastString == this.gameObject.name)
        {
            verbstring = "Look at ";
        }
        else if (verb.currentVerb == Verb.Action.talkto && talkto == true && raycastString == this.gameObject.name)
        {
            verbstring = "Talk to ";
        }

        

        // pickupItem = GetComponent<PickupItem>();


    }

    //die richtigen Indicator suchen nach nach den ausgewählten Sachen
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            foreach (GameObject item in showVerbs)
            {
                item.SetActive(true);
            }
            // Show  indicator
            
            isItemInRange = true;
        }
    }
    */

    /* // 
     * 
     * Weglassen da die Trigger nicht so gut funktioniern und man dann auch immer mit allen Objekten interagieren kann.
     *
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            foreach (GameObject item in showVerbs)
            {
                item.SetActive(true);
            }
            // Show  indicator

            isItemInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            foreach (GameObject item in showVerbs)
            {
                item.SetActive(false);
            }
            isItemInRange = false;
        }
    }
    */
    private void OnMouseUpAsButton()
    {
        itemWasPressend = true;
        print("item was pressed");

       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        raycastString = eventData.pointerCurrentRaycast.gameObject.name;
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        print(verb.currentVerb);
        print("use" + use);
        print("pickup" + pickup);
        print(raycastString);


        if (isItemInRange==false)
        {
            // Charaktermove aufrufen in richtung Objekt zu gehen und danach die Standart Aktion auszuführen.
            charakterMove.WalkToObjekt(this.gameObject);

            //darauf achten, dass wenn noch ein zweiter klick irgendwohin passiert die Aktion abgebrochen wird.
        }
        if (verb.currentVerb == Verb.Action.use && use == true && raycastString == this.gameObject.name)
        {
            Use();
        }
        else if (verb.currentVerb == Verb.Action.pickup && pickup == true && raycastString == this.gameObject.name)
        {
            PickUp();
        }
        else if (verb.currentVerb == Verb.Action.lookat && lookat == true && raycastString == this.gameObject.name)
        {
            LookAt(); // keine speziellen Funktionen außer das durch des Verb die Flowchart aktiviert wird. 
        }
        else if (verb.currentVerb == Verb.Action.talkto && talkto == true && raycastString == this.gameObject.name)
        {
            TalkTo(); // keine speziellen Funktionen außer das durch des Verb die Flowchart aktiviert wird. 
        }else if (verb.currentVerb == Verb.Action.use && use == false && raycastString == this.gameObject.name)
        {
            inventar.combineAuwahl = null;
        }
        /*
        else if (verb.currentVerb == Verb.Action.walk)
        {
            charakterMove.WalkToObjekt(this.gameObject);
        }*/
        else
        {
            // für Anzeige Verb auf die richtige Aktion setzen
            verb.currentVerb = standartAction;
            /// (Achtung wird dadurch gespeichert und dann einfach ausgeführt . Beim zweiten Click könnte wieder in den walk Modus gegangen werden.)
            

            //standart Nutzung ausführen.
            // wird jedem Gameobjekt als Varable mitgegegeben


           // verb.setBackToWalk();
        }
    }

    private void ShowVerbs()
    {
        //print(showVerbs.Length);
        for (int i = 0; i < 4; i++)
        {
            if (use == true)
            {
                print("test");
                showVerbsList.Add(indicatorUse);
                //showVerbs[i] = indicatorUse;
                i++;
            }
            if (pickup == true)
            {
                showVerbsList.Add(indicatorPickup);
                //showVerbs[i] = indicatorPickup;
                i++;
            }
            if (talkto == true)
            {
                showVerbsList.Add(indicatorTalkto);
                // showVerbs[i] = indicatorTalkto;
                i++;
            }
            if (lookat == true)
            {
                showVerbsList.Add(indicatorLookat);
                // showVerbs[i] = indicatorLookat;
                i++;
            }
            showVerbs = showVerbsList.ToArray();
        }
    }
        private void AddPhysics2DRaycaster()
        {
        
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        
        if (physicsRaycaster == null)
            {
           
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
            }
        }


    private void Use()
    {

        //ToDo: 
        //Abfragen ob bereits ein Objekt angewählt wurde. Dann dass zweite Objekt verbinden. Falls beide Objekte zusammenpassen
        if (inventar.combineAuwahl != null)
        {

            verbstring = "Use ";
            inventar.CombineItems(item, inventar.combineAuwahl);
            
            verb.setBackToWalk();
        }
        else
        {
            inventar.combineAuswahl(item);
        }

        
        //print("Das soll ich verwenden?");
        //print(verbstring);

        
    }

    private void UsewithGameobject()
    {

        //ToDo: 
        //Abfragen ob bereits ein Objekt angewählt wurde. Dann dass zweite Objekt verbinden. Falls beide Objekte zusammenpassen
        if (inventar.combineAuwahl != null)
        {

            verbstring = "Use ";

            //brauchen eine Methode um das Item zu zerstören und eine Aktion auszulösen
            inventar.CombineItems(item, inventar.combineAuwahl);
            //verbstring = "";
            verb.setBackToWalk();
        }
         
        

    }


        private void PickUp()
    {

        //verbstring = "";
        print("inside pickup");
        pickupItem.inInventar(this.item, this.gameObject);
        //pickupItem.inInventar(this.gameObject);
        verb.verbTextBox.text = "";
        verb.setBackToWalk();
    }

    private void LookAt()
    {
        verbstring = "LookAt" ;
        verb.verbTextBox.text = "";
        //verb.setBackToWalk();
    }

    private void TalkTo()
    {
        //verbstring = "";
        verb.verbTextBox.text = "";
        //verb.setBackToWalk();
    }


    // zum Anzeigen der Itemnamen in der VerbTextBox
    public void OnPointerEnter(PointerEventData eventData)
    {
        charakterMove.onClickable = this.gameObject;
        if (verb.currentVerb == Verb.Action.use && inventar.combineAuwahl != null)
        {
            verb.verbTextBox.text = verb.verbString + inventar.combineAuwahl.itemName + " with " + this.gameObject.name;
        }else if (verb.currentVerb == Verb.Action.walk )
        {
            /// Direkt die Standartaktion anzeigen oder nicht ???
            
             verb.verbTextBox.text = verb.verbString + this.gameObject.name;
        }
        else
        {
            verb.verbTextBox.text = verb.verbString + this.gameObject.name;
        }

    }

    // zum Anzeigen der Itemnamen in der VerbTextBox
    public void OnPointerExit(PointerEventData eventData)
    {
        charakterMove.onClickable = null;
        if (verb.currentVerb == Verb.Action.use )
        {
            
        }
        else
        {
            verb.verbTextBox.text = verb.verbString;
        }
        
    }
}
