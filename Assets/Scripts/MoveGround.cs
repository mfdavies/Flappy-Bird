using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public Transform start;
    public Transform end;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.currSpeed * Time.deltaTime;
        if (transform.position.x < end.position.x) {
            transform.position = start.position;
        }
    } // end Update
} // end class MoveGround
