using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharakterMove : MonoBehaviour
{


    private Vector2 lastPosition;
    private Vector2 followSpot;
    public float speed;
    public float perspektiveScale;
    public float perspektiveRatio;

    // Start is called before the first frame update
    void Start()
    {
        followSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            followSpot = mousePosition;
        }
        CharakterFlip();
        AdjustPerspektive();
        transform.position = Vector2.MoveTowards(transform.position, followSpot, speed * Time.deltaTime);
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
        Vector2 Scale = transform.localScale;
        Scale.x = perspektiveScale * (perspektiveRatio - transform.position.y);
        Scale.y = perspektiveScale * (perspektiveRatio - transform.position.y);
        transform.localScale = Scale;

    }
}
