
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryItems item;
    private Inventar inventar;

    public Image image;
    private TextMeshProUGUI textBox; 

    private Verb verb;
    private CharakterMove charakter;

    public GameObject zoomPanel;
    public ItemsInGroﬂ itemsInGroﬂ;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (verb.currentVerb == Verb.Action.use && inventar.combineAuwahl != null)
        {
            verb.verbTextBox.text = verb.verbString + inventar.combineAuwahl.itemName + " with " + this.item.name;
        }else if (verb.currentVerb == Verb.Action.walk)
        {
            // nix tun
            verb.verbTextBox.text = "";
            
        }
        else
        {
            verb.verbTextBox.text = verb.verbString + this.item.name;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (verb.currentVerb == Verb.Action.use)
        {

        }
        else if (verb.currentVerb == Verb.Action.walk)
        {
            // nix tun
            verb.verbTextBox.text = "";
        }
        else
        {
            verb.verbTextBox.text = verb.verbString;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventar = FindObjectOfType<Inventar>();

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
        //ToDo: 
        //Abfragen ob bereits ein Objekt angew‰hlt wurde. Dann dass zweite Objekt verbinden. Falls beide Objekte zusammenpassen
        if (this.item.zoom == true || verb.currentVerb == Verb.Action.lookat)
        {

            itemsInGroﬂ.panelAn();
            var object1 = Instantiate(this.item.gameObject, zoomPanel.transform);
            itemsInGroﬂ.item = object1;
            

            Debug.Log("zoom");
        }else if (inventar.combineAuwahl != null)
        {
            inventar.CombineItems(item, inventar.combineAuwahl);

            verb.setBackToWalk();
        }
        else
        {
            inventar.combineAuswahl(item);
            verb.currentVerb = Verb.Action.use;
            verb.verbString = "Use ";
            verb.verbTextBox.text = verb.verbString + this.item.name;
        }
        //if(verb.currentVerb = Verb.Action.use && verb.)
    }
}
