using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class con_ca : MonoBehaviour
{
    public GameObject bong_bong_prefab;
    float timer_create_bongbong=0f;
    float timer_location_km = 0f;
    public Transform cai_mo;
    public Rigidbody2D rigidbody_ca=null;
    private float kich_thuoc= 0.1f;
    public GameObject canh_bao;
    private bool is_control_jump = false;
    private bool is_die = false;
    private int socre = 0;
    public SpriteRenderer skin;
    public void load()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.canh_bao.SetActive(false);
    }

    void Update()
    {
            if (is_control_jump)
            {
                if (Input.GetMouseButtonDown(0)) this.jump();
            }

            this.timer_create_bongbong += Time.deltaTime * 1f;
            if (this.timer_create_bongbong > 1.5f)
            {
                GameObject bongbong = Instantiate(this.bong_bong_prefab);
                bongbong.transform.position = this.cai_mo.position;
                this.timer_create_bongbong = 0;
                Destroy(bongbong, 2f);
            }
    }

    public void jump()
    {
        if (this.is_die == false)
        {
            rigidbody_ca.AddForce(Vector3.up * 20, ForceMode2D.Impulse);
            GameObject.Find("game").GetComponent<game>().play_sound(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "con_moi")
        {
            con_moi dich = collision.GetComponent<con_moi>();
            if (this.kich_thuoc > dich.get_kich_thuoc())
            {
                if (this.kich_thuoc > 1f)
                    this.tang_kich_thuong(0.002f);
                else if(this.kich_thuoc>0.05f)
                    this.tang_kich_thuong(0.005f);
                else
                    this.tang_kich_thuong(0.01f);
                GameObject.Find("game").GetComponent<game>().add_ca_chet(collision.transform);
                GameObject.Find("game").GetComponent<game>().add_eat_fish(dich.type);
                this.socre++;
                Destroy(collision.gameObject);
            }
            else this.die();
            
            GameObject.Find("game").GetComponent<game>().play_sound(1);
        }

        if (collision.gameObject.name == "canh_bao") this.canh_bao.SetActive(true);

        if (collision.gameObject.name == "diem_chet") this.die();

        if(collision.gameObject.name == "con_muc") this.die();

        if (collision.gameObject.name == "vat_pham")
        {
            GameObject.Find("game").GetComponent<game>().play_sound(4);
            collision.GetComponent<gift_items>().get_items();
            if (collision.GetComponent<gift_items>().get_type() == 3) this.go_right_fish();
            if (collision.GetComponent<gift_items>().get_type() == 4) this.go_left_fish();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "canh_bao") this.canh_bao.SetActive(false);
    }

    public void tang_kich_thuong(float do_lon)
    {
        this.kich_thuoc += do_lon;
        this.transform.localScale = new Vector3(this.kich_thuoc, this.kich_thuoc, 0f);
    }

    public void reset_ca()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.kich_thuoc = 0.1f;
        this.transform.localScale = new Vector3(this.kich_thuoc, this.kich_thuoc, 0f);
        this.transform.position = new Vector3(-4.38f, Random.Range(-1f, 1f), 0f);
        this.is_die = false;
        this.timer_location_km = 0f;
        this.socre = 0;
        this.gameObject.SetActive(true);
    }

    public void off()
    {
        this.gameObject.SetActive(false);
    }

    public void set_control_jump(bool is_jump)
    {
        this.is_control_jump = is_jump;
    }

    public bool get_die_status()
    {
        return this.is_die;
    }

    private void die()
    {
        GameObject.Find("game").GetComponent<game>().add_ca_chet(this.transform);
        this.timer_location_km = GameObject.Find("game").GetComponent<game>().quang_canh_view.get_location_km();
        this.gameObject.SetActive(false);
        this.is_die = true;
        GameObject.Find("game").GetComponent<game>().show_gameover();
    }

    public int get_socre()
    {
        return this.socre;
    }

    public void play_now()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public float get_location_km()
    {
        return this.timer_location_km;
    }

    public void go_right_fish()
    {
        if(this.transform.localPosition.x<6f)rigidbody_ca.AddForce(Vector3.right * 20, ForceMode2D.Impulse);
    }
    
    public void go_left_fish()
    {
        if (this.transform.localPosition.x >-6f) rigidbody_ca.AddForce(Vector3.left * 20, ForceMode2D.Impulse);
    }

}
