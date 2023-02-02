using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class morsecode : MonoBehaviour
{
    public string code;
    public TMP_InputField inputField;
    public Flowchart flowchart;
    public VariableReference variable;

    private Inventar inventar;
    public InventoryItems item;
    private string oldCode;
    private GameManager game;

    public string loesung = "6920";



    // Start is called before the first frame update
    void Start()
    {
        
        game = FindObjectOfType<GameManager>();
        inventar = FindObjectOfType<Inventar>();
        //item = inventar.GetItem(this.gameObject);
        
        oldCode = game.morsecode;
        // textBox.text = variable.Get<string>();
        Debug.Log(code);
        inputField.text = oldCode;

        Debug.Log(inputField.text);

        //textBox = GetComponent<TextMeshProUGUI>();
        // item = new InventoryItems();
        //Instantiate(item,item.transform);

    }

    // Update is called once per frame
    void Update()
    {
        code = inputField.text;
        game.morsecode = code;
        variable.Set<string>(code);
        
        if (code.StartsWith(loesung))
        {

            inventar.CobinableTrue(this.gameObject);
        }
        else{
 
            //item.combinable = false;
        }


    }
}
