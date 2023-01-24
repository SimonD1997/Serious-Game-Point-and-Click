using UnityEngine;
using Fungus;


[CreateAssetMenu(menuName = "New InventoryItem", order = 1)]
public class InventoryItems : ScriptableObject
{
    public bool itemOwend;

    public string itemName;
    public Sprite itemIcon;

    public GameObject gameObject;

    public bool combinable;
    public InventoryItems[] combinableItems; //Items die mit diesem Item kombiniert werden können
    public InventoryItems[] combinableErgebnis; //Items zu denen die Kombinationen werden

    public Block failBlock; //Block in Fungus der Aufgerufen wird, wenn die Kombination mit dem Block nicht korrekt war.
    public Block cobineBlockEnd; //Block in Fungus der Aufgerufen wird, wenn ein Neues Item entstanden ist.


}
