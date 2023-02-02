using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Fungus;
using UnityEngine.UI;


public class Inventar : MonoBehaviour
{
    private ArrayList inventory = new ArrayList();
    private int letztePosition;

    private CharakterMove charakterMove;

    public InventoryItems[] inventoryItem;
    public ItemSlot[] itemSlots;

    private Flowchart[] flowcharts;
    public VariableReference use1;
    public VariableReference use2;

    public InventoryItems combineAuwahl;

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inventoryItem.Length);
        letztePosition = inventory.Count;
    }

    // Update is called once per frame
    void Update()
    {
        InitializeItemSlots();
        //use1.Set<string>(combineAuwahl.itemName);
        
        
        
    }

    public void AddItem(GameObject item)
    {
       

        for (int i = 0; i < inventoryItem.Length; i++)
        {
            
        }

        // großes Problem, Keine Ahnung was da Los ist
        foreach (InventoryItems invItem in inventoryItem)
        {
            if (invItem.name == item.name)
            {
                invItem.itemOwend = true;           
            }
        }

    }

    public void AddItem(InventoryItems item)
    {

         item.itemOwend = true;

    }

    public void CobinableTrue(InventoryItems item)
    {
        item.combinable = true;
    }

    public void CobinableTrue(GameObject item)
    {
        foreach (InventoryItems invItem in inventoryItem)
        {
            if (item.name.StartsWith(invItem.name))
            {
                invItem.combinable = true;
                invItem.zoom = false;
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        foreach(InventoryItems invItem in inventoryItem)
        {
            if (invItem.name == item.name)
            {
                invItem.itemOwend = false;
            }
        }

    }


    //sucht für ein Gameobjekt nach dem entsprechenden Inventoryitems. Da diese alle hierhinterlegt sind. Wenn sie benutzt werden können.
    //heist Items müssen einmalig sein und falls das Ojekt in der Spielwelt vorkommt mit dem Objekt verbunden sein.
    public InventoryItems GetItem(GameObject item)
    {
       InventoryItems thisItem = InventoryItems.CreateInstance<InventoryItems>(); 
        foreach (InventoryItems invItem in inventoryItem)
        {
            if (item.name.StartsWith(thisItem.name))
            {
                thisItem=invItem;
            }
        }
        return thisItem;

    }

   

    public void showInventory()
    {
        int counter = 1;
        foreach (GameObject item in inventory)
        {
            Instantiate(item, new Vector2(1 * counter, -3), item.transform.rotation);
            counter += 1;
        }
      
    }

    public void InitializeItemSlots()
    {
        List<InventoryItems> owendItems = GetOwnedItems(inventoryItem.ToList());
        for (int i = 0; i < itemSlots.Length; i++){

            if(i< owendItems.Count)
            {
                itemSlots[i].DisplayItem(owendItems[i]);
            }
            else
            {
                itemSlots[i].ClearItem();
            }
        }
        
            }

    public List<InventoryItems> GetOwnedItems(List<InventoryItems> inventoryItems)
    {
        List<InventoryItems> ownedItems = new List<InventoryItems>();
        foreach (InventoryItems item in inventoryItems)
        {
            if (item.itemOwend)
            {
                ownedItems.Add(item);
                    }

        }
        return ownedItems;
    }

    public void CombineItems(InventoryItems item1, InventoryItems item2)
    {
        use1.Set<string>(item1.itemName);
        use2.Set<string>(item2.itemName);
        if (item1.combinable == true && item2.combinable == true)
        {
            for (int i = 0; i < item1.combinableItems.Length; i++)
            {
                if (item1.combinableItems[i] == item2)
                {
                    
                    AddItem(item1.combinableErgebnis[i]);
                    //item1.cobineBlockEnd.StartExecution();
                    item1.itemOwend = false;
                    item2.itemOwend = false;
                }
            }
     
        }
        else
        {
            if (item1.combinable == false)
            {
               // item1.failBlock.StartExecution();
            }
            else if (item2.combinable == false)
            {
              //  item2.failBlock.StartExecution();
            }
            
        }
        //überprüfen, welches ergebnis rauskommen soll. 
        // suche das enstprechende Item 

        // und füge es dem Inventar des Spieler hinzu mit AddItem();

        //die zwei anderen Items gehen kaputt (falls des nicht immer so sein soll, braucht es die Eigenschaft noch in den InventoryItems)
        // heißt: RemoveItem();

        combineAuwahl = null;
    }

    public void combineAuswahl(InventoryItems item)
    {
        combineAuwahl = item;
        use1.Set<string>(item.itemName);
    }
}
