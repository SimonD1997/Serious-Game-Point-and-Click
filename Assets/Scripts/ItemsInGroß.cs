using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInGroß : MonoBehaviour

{

    public GameObject item;


    public void destreoyObject()
    {

        Destroy(item);

    }

    public void panelAn()
    {
        gameObject.SetActive(true);
    }

    public bool isPanelAn()
    {
        return gameObject.activeSelf == true;
    }
}
