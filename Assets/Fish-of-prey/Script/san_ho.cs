using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class san_ho : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bong_bong_prefab;
    float timer_create_bongbong = 0f;
    public Transform diem_tao_bong_bong;
    void Update()
    {
        this.transform.Translate(Vector3.left*Time.deltaTime*this.speed);
        if (this.transform.position.x < -30)
        {
            this.transform.position = new Vector3(30,this.transform.position.y, this.transform.position.z);
        }

        this.timer_create_bongbong += Time.deltaTime * 1f;
        if (this.timer_create_bongbong > 1f)
        {
            GameObject bongbong = Instantiate(this.bong_bong_prefab);
            bongbong.transform.SetParent(this.transform);
            bongbong.transform.position = this.diem_tao_bong_bong.position;
            this.timer_create_bongbong = 0;
            Destroy(bongbong, 4f);
        }
    }
}
