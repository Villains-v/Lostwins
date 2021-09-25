using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movement;

    // 해야 할 것
    /* 1. boxcollider 캐릭터가 부딛히게만들기 -> OK!!
     * 2. 캐릭터 스피드 특정지역 갔을때 느려지게 할 수 있도록 만들기 -> 이건 특정지역 정한 후 적용
     * 3. 캐릭터가 움직이는 방향으로 캐릭터 회전시키기 -> 좌우(?)회전은 이미 적용 되어있음
     */
   
    private BoxCollider2D boxCollider;
    public float xSpeed = 1.0f;
    public float ySpeed = 0.75f;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0);
        // leftRight = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);


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
