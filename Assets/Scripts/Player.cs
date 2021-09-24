using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 leftRight;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        leftRight = new Vector3(x, y, 0);

        if (leftRight.x > 0)
            transform.localScale = Vector3.one;
        else if (leftRight.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(leftRight * Time.deltaTime);
    }
}
