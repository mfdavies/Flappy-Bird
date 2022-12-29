using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.currSpeed * Time.deltaTime;
    } // end Update
} // end class MovePipes
