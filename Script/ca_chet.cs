using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ca_chet : MonoBehaviour
{

    void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * 1.4f);
    }
}
