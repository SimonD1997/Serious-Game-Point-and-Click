using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharakterMove : MonoBehaviour
{

    private Verb verb;
    private Vector2 lastPosition;
    private Vector2 followSpot;
    public float speed;
    public float perspektiveScale;
    public float perspektiveRatio;

    public GameObject onClickable;
    private Collider2D collision;

    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        followSpot = transform.position;
        verb = FindObjectOfType<Verb>();
    }

    // Update is called once per frame
    void Update()
    {
        

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0) && mousePosition.y >= -4.2 && verb.currentVerb == Verb.Action.walk)
        {
            followSpot = mousePosition;
            
            verb.setBackToWalk();
            verb.verbString = "Walk to ";
            verb.verbTextBox.text = verb.verbString;
        }else
        

        // Funktionsf�higkeit ist noch zu �berpr�fen........!!!!
        if (Input.GetMouseButtonDown(0) &&  onClickable == null && mousePosition.y >= -4.2)
        {
            
            verb.setBackToWalk();
            followSpot = mousePosition;
            
        }

        // muss alles dauerhaft geuprdatet werden sonst funktioniert die Bewegung nicht.
        transform.position = Vector2.MoveTowards(transform.position, followSpot, speed * Time.deltaTime);
        CharakterFlip();
        AdjustPerspektive();



        // testen ob des tut !!!!!!!!!!!!!!!!:::::::::::::::::::::::
        /*
        if (Input.GetMouseButtonDown(0) && onClickable != null && verb.currentVerb == Verb.Action.walk)
        {
            while (collision == null)
            {
                followSpot = mousePosition;
                CharakterFlip();
                AdjustPerspektive();
            }
            collision = null;
        }*/
    }

    

    private void OnCollisionStay2D(Collision2D collision)
    {
        followSpot = transform.position;

    }

    private void CharakterFlip()
    {
        if (followSpot.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (followSpot.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void AdjustPerspektive()
    {
        
        Vector2 Scale= transform.localScale;
        Scale.x = perspektiveScale * (perspektiveRatio - transform.position.y);
        Scale.y = perspektiveScale * (perspektiveRatio - transform.position.y);
        transform.localScale = Scale;

    }

    public void WalkToObjekt(GameObject gameobject)
    {
        this.followSpot = gameobject.transform.position;
        CharakterFlip();
        AdjustPerspektive();

        /*
        while (collision == null)
        {
            this.followSpot = gameobject.transform.position;
            CharakterFlip();
            AdjustPerspektive();
        }
        collision = null;*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.collision = collision;
    }


}
