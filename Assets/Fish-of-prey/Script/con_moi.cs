using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class con_moi : MonoBehaviour
{
    private float speed = 1.2f;
    private float kich_thuoc = 0.03f;
    public int type;
    public void khoi_tao()
    {
        this.speed = Random.Range(1.2f, 3f);
        this.kich_thuoc = Random.Range(0.03f, 0.3f);
        this.transform.localScale = new Vector3(-this.kich_thuoc, this.kich_thuoc);
    }
    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        if (this.transform.position.x < -10) Destroy(this.gameObject);
    }

    public float get_kich_thuoc()
    {
        return this.kich_thuoc;
    }

    public void act_magic_resize()
    {
        this.kich_thuoc = 0.05f;
        this.transform.localScale = new Vector3(-0.05f, 0.05f,0.05f);
    }
}
