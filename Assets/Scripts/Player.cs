using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movement;

   
    private BoxCollider2D boxCollider;
    public Vector2 Speed = new Vector2(1.0f, 0.75f);

     
    //통과 불가능 한 레이어를 만들기 위한 선언
    private RaycastHit2D hit;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(Speed.x * x,Speed.y * y , 0);

        
        if (movement.x > 0)
            transform.localScale = Vector3.one;
        else if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movement.y), Mathf.Abs(movement.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, movement.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(movement.x * Time.deltaTime, 0, 0);
        }
    }
}
