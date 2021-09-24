using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // transform.LookAt(target, Vector3.zero); -> 타겟을 따라서 XYZ가 같이 움직임
        // transform.position = target.transform.position; -> 여기 position Z에  -1을 넣고싶은데 하는 방법을 모르겠음
        //transform.position = player.transform.position + new Vector3(0,0,-1);

        transform.position = new Vector3(target.position.x, target.position.y, -1);

    }
}   
