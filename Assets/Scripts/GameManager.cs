using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Hat die �bersicht �ber alle Eingaben un ruft die entsprechenden Methoden der Items und Verbindungen auf.

    public GameObject verbs;

    public static GameManager instance;

    //�bersicht aller Buttons:

    //....

    // Verbundene Skripte

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    
    
    
}
