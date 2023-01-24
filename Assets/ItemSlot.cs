
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItems item;
    private Inventar inventory;

    public Image image;
    private TextMeshProUGUI textBox;

    private Verb verb;
    private CharakterMove charakter;

    public void OnPointerEnter(PointerEventData eventData)
    {
        
       //toTO
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       //toDO
    }

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventar>();

        verb = FindObjectOfType<Verb>();
        charakter = FindObjectOfType<CharakterMove>();

        textBox = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItem(InventoryItems thisItem)
    {
        
                item = thisItem;
       
        textBox.text = item.itemName;
        

        image.sprite = item.itemIcon;
   
        gameObject.SetActive(true);
    }

    public void ClearItem()
    {
        item = null;
        image.sprite = null;
        gameObject.SetActive(false);
    }

    public void OnItemClick()
    {
        
        //if(verb.currentVerb = Verb.Action.use && verb.)
    }
}
