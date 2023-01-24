using UnityEngine;


[CreateAssetMenu(menuName = "New InventoryItem", order = 1)]
public class InventoryItems : ScriptableObject
{
    public bool itemOwend;

    public string itemName;
    public Sprite itemIcon;

    public GameObject gameObject;

    public bool combinable;
    public InventoryItems[] combinableItems;


}
