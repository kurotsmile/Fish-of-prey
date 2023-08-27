using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quan_canh : MonoBehaviour
{
    private Sprite[] skin_con_moi;
    public GameObject con_moi_prefab;
    public GameObject con_muc_prefab;
    public GameObject effect_boom_prefab;
    public GameObject[] items_gift_prefab;
    public Transform[] diem_tao;
    public Transform[] diem_tao_muc;
    public Transform arean_item_ca_moi;
    public Text txt_location_km;

    private float timer_create_con_moi = 0f;
    private float timer_create_vat_pham = 0f;
    private float timer_location_km = 0f;
    private bool is_play = false;

    public void khoi_tao(Sprite[] arr_skin_ca)
    {
        this.skin_con_moi = arr_skin_ca;
    }

    void Update()
    {
        this.timer_create_con_moi += Time.deltaTime * 1f;

        if (this.is_play)
        {
            this.timer_location_km += Time.deltaTime * 1f;
            this.txt_location_km.text = this.timer_location_km + " km";
            this.timer_create_vat_pham += Time.deltaTime * 1f;
        }

        if (this.timer_create_con_moi > 2f)
        {
            this.create_con_moi();

            GameObject item_bong_ca = Instantiate(this.con_moi_prefab);
            item_bong_ca.name = "bong_ca";
            item_bong_ca.transform.SetParent(this.transform);
            item_bong_ca.transform.position = this.get_diem_tao_random().position;
            item_bong_ca.transform.position = new Vector3(item_bong_ca.transform.position.x, item_bong_ca.transform.position.y, 1f);
            item_bong_ca.GetComponent<SpriteRenderer>().sprite = this.get_skin_random();
            item_bong_ca.GetComponent<SpriteRenderer>().color = Color.black;
            item_bong_ca.GetComponent<con_moi>().khoi_tao();
            Destroy(item_bong_ca.GetComponent<CircleCollider2D>());

            this.timer_create_con_moi = 0f;
        }

        if(this.timer_create_vat_pham> 12f)
        {
            GameObject item_qua = Instantiate(this.items_gift_prefab[0]);
            item_qua.name = "vat_pham";
            item_qua.transform.SetParent(this.transform);
            item_qua.transform.position = this.get_diem_tao_random().position;
            item_qua.GetComponent<gift_items>().load_random_type();
            this.timer_create_vat_pham = 0f;
        }
    }

    public void create_con_moi(int index_pos=-1)
    {
        GameObject item_con_moi = Instantiate(this.con_moi_prefab);
        item_con_moi.name = "con_moi";
        item_con_moi.transform.SetParent(this.arean_item_ca_moi);
        if(index_pos==-1)
            item_con_moi.transform.position = this.get_diem_tao_random().position;
        else
            item_con_moi.transform.position = this.diem_tao[index_pos].position;
        int index_rand = Random.Range(0, this.skin_con_moi.Length);
        item_con_moi.GetComponent<SpriteRenderer>().sprite = this.skin_con_moi[index_rand];
        item_con_moi.GetComponent<con_moi>().type = index_rand;
        item_con_moi.GetComponent<con_moi>().khoi_tao();
    }

    public Transform get_diem_tao_random()
    {
        int index_rand = Random.Range(0, this.diem_tao.Length);
        return this.diem_tao[index_rand];
    }

    public Sprite get_skin_random()
    {
        int index_rand = Random.Range(0, this.skin_con_moi.Length);
        return this.skin_con_moi[index_rand];
    }

    public void xoa_toan_bo_ca_moi()
    {
        foreach(Transform ca in this.arean_item_ca_moi)
        {
            if(ca.name=="con_moi"|| ca.name == "con_muc")
            {
                Destroy(ca.gameObject);
            }
        }
        
    }

    public void tao_muc()
    {
        int index_rand = Random.Range(0, this.diem_tao_muc.Length);
        GameObject i_muc = Instantiate(this.con_muc_prefab);
        i_muc.name = "con_muc";
        i_muc.transform.SetParent(this.arean_item_ca_moi);
        i_muc.transform.localPosition = this.diem_tao_muc[index_rand].localPosition;
        i_muc.GetComponent<con_muc>().khoi_tao();
        Destroy(i_muc, 25f);
    }

    public void play_quan_canh()
    {
        this.timer_location_km = 0f;
        this.is_play = true;
    }

    public void stop_quan_canh()
    {
        this.timer_create_vat_pham = 0f;
        this.is_play = false;
    }

    public float get_location_km()
    {
        return this.timer_location_km;
    }

    public void act_boom_all_ca_moi()
    {
        foreach(Transform child in this.arean_item_ca_moi)
        {
            this.create_effect_boom(child);
            GameObject.Find("game").GetComponent<game>().add_ca_chet(child);
            Destroy(child.gameObject);
        }
        GameObject.Find("game").GetComponent<game>().play_sound(5);
        GameObject.Find("game").GetComponent<game>().carrot.play_vibrate();
    }

    private void create_effect_boom(Transform tr)
    {
        GameObject item_effect_boom = Instantiate(this.effect_boom_prefab);
        item_effect_boom.transform.localPosition = tr.localPosition;
        item_effect_boom.transform.localScale = tr.localScale;
        item_effect_boom.transform.SetParent(this.transform);
        Destroy(item_effect_boom, 1f);
    }

    public void act_magic_all_ca_moi()
    {
        foreach (Transform child in this.arean_item_ca_moi) if(child.name== "con_moi") child.GetComponent<con_moi>().act_magic_resize();
        GameObject.Find("game").GetComponent<game>().play_sound(6);
    }

    public void act_all_pos_fish()
    {
        for(int i = 0; i < this.diem_tao.Length; i++) this.create_con_moi(i);
        GameObject.Find("game").GetComponent<game>().play_sound(6);
    }
}
