using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : ScriptableObject
{

    private GameObject thisGame;
    private InventoryItems item;

    private Inventar inventory;

    public GameObject player;
    public GameObject pickupIndicator;

    private bool isItemInRange;
    private bool itemWasPressend;


     void Start()
    {
        inventory = FindObjectOfType<Inventar>();

    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(isItemInRange && Input.GetMouseButtonDown(0) && pickupIndicator.GetComponent<Buttons>().pressed)
        {
            //Item auschalten und Collider auschalten
            this.gameObject.SetActive(false);

            //Item zum Inventar hinzufügen
            inventory.AddItem(this.gameObject);
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            // Show Pickup indicator
            pickupIndicator.SetActive(true);
            isItemInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            pickupIndicator.SetActive(false);
            isItemInRange = false;
        }
    }
    private void OnMouseUpAsButton()
    {
        itemWasPressend = true;
        //print("item was pressed");
    }

    public void inInventar(GameObject gameObjekt)
    {
        
        Start();
        
        
        thisGame = gameObjekt;

        //Item zum Inventar hinzufügen
        inventory.AddItem(thisGame);

        //Item auschalten und Collider auschalten
        thisGame.SetActive(false);

        
        Debug.Log("Ende");
    }

    public void inInventar(InventoryItems thisitem, GameObject gameObjekt)
    {

        Start();
        //item = thisitem;
        //Instantiate(item);
        

        //Item zum Inventar hinzufügen
        inventory.AddItem(thisitem);



        //Item auschalten und Collider auschalten
        //gameObjekt.SetActive(false);


        Debug.Log("Ende");
    }
}
