using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Hat die Übersicht über alle Eingaben un ruft die entsprechenden Methoden der Items und Verbindungen auf.

    public GameObject verbs;
    public GameObject mauer;
    public GameObject secenePort;
    public GameObject newBackground;
    public InventoryItems hammer;


    public static GameManager instance;
    private CharakterMove charakterMove;
    

    //Übersicht aller Variablen:

    public string morsecode;
    

    //....

    // Verbundene Skripte

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        charakterMove = FindObjectOfType<CharakterMove>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void CheckForNextScene()
    {
            Debug.Log("checkforSene");
            mauer.SetActive(false);
            secenePort.SetActive(true);
        newBackground.SetActive(true);
        hammer.itemOwend = false;
        charakterMove.onClickable = null;
        
    }

    
    
    
}
