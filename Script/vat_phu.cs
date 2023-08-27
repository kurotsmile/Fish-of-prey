using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vat_phu : MonoBehaviour
{
    private float speed = 1.2f;
    private int direction = 0;

    void Update()
    {
        if (this.direction==0)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
            if (this.transform.position.x > 20)
            {
                this.direction = 1;
                this.transform.localScale=new Vector3(-2f, 2f, 5f);
                GameObject.Find("game").GetComponent<game>().quang_canh_view.tao_muc();
            }
        }
        
        if(this.direction==1)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
            if (this.transform.position.x < -20f)
            {
                this.direction = 0;
                this.transform.localScale = new Vector3(2f, 2f, 5f);
                GameObject.Find("game").GetComponent<game>().quang_canh_view.tao_muc();
            }
        }
    }
}
