using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gift_items : MonoBehaviour
{
    private float speed = 1.2f;
    public Animator anim;
    public GameObject obj_effect_border;
    private int type = 0;
    public Sprite[] sp_skin_item;

    public void load_random_type()
    {
        int type_random = Random.Range(0, this.sp_skin_item.Length);
        this.set_type(type_random);
        this.anim.Play("items_ready");
    }

    public void set_type(int index_type)
    {
        this.type = index_type;
        this.GetComponent<SpriteRenderer>().sprite = this.sp_skin_item[this.type];
    }

    void Update()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        if (this.transform.position.x < -10) Destroy(this.gameObject);
    }

    public int get_type()
    {
        return this.type;
    }

    public void get_items()
    {
        if (this.type == 0)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.obj_effect_border.SetActive(false);
            Destroy(this.gameObject, 2f);
            GameObject.Find("game").GetComponent<game>().carrot.delay_function(2f, act_boom);
            this.anim.Play("gift_items_boom");
        }else if (this.type == 1)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.obj_effect_border.SetActive(false);
            Destroy(this.gameObject, 2f);
            GameObject.Find("game").GetComponent<game>().carrot.delay_function(2f, act_magic);
            this.anim.Play("gift_items_boom");
        }else if (this.type == 2)
        {
            GameObject.Find("game").GetComponent<game>().quang_canh_view.act_all_pos_fish();
            Destroy(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void act_boom()
    {
        GameObject.Find("game").GetComponent<game>().quang_canh_view.act_boom_all_ca_moi();
    }

    private void act_magic()
    {
        GameObject.Find("game").GetComponent<game>().quang_canh_view.act_magic_all_ca_moi();
    }
}
