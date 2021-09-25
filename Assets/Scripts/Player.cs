using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 leftRight;

    // 해야 할 것
    /* 1. boxcollider 캐릭터가 부딛히게만들기
     * 2. 캐릭터 스피드 특정지역 갔을때 느려지게 할 수 있도록 만들기
     * 3. 캐릭터가 움직이는 방향으로 캐릭터 회전시키기
     */
   
    private BoxCollider2D boxCollider;
    public float xSpeed = 1.0f;
    public float ySpeed = 0.75f;


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

        leftRight = new Vector3(x, y, 0);
        // leftRight = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);


        if (leftRight.x > 0)
            transform.localScale = Vector3.one;
        else if (leftRight.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(leftRight * Time.deltaTime);
    }
}
