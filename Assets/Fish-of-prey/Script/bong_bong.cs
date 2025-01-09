using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bong_bong : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * this.speed);
    }
}
