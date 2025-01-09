using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_design : MonoBehaviour
{
    public Image player_fish;
    public Image[] img_color_fish;
    private int index_sel_type = 0;
    private int index_sel_color = 0;
    public GameObject button_buy;
    public Button button_play;
    private Sprite[] skin_fish;
    private bool buy_all_fish = false;
    private bool[] buy_fish_info;
    public Sprite icon_sel_color;
    public Sprite icon_nomal_color;
    private bool is_ready = false;
    public GameObject button_next_fish;
    public GameObject button_prev_fish;
    public GameObject panel_sel_color_fish;

    public void load_desing(Sprite[] arr_sin_fish,bool[] arr_info_buy_skin,int index_color,bool is_buy_all)
    {
        this.buy_all_fish = is_buy_all;
        this.skin_fish = arr_sin_fish;
        this.buy_fish_info = arr_info_buy_skin;
        this.sel_color_fish(index_color);
        this.check_info_fish();
        this.load_skin_fish_random();
    }

    private void load_skin_fish_random()
    {
        List<int> list_fish = new List<int>();
        for(int i = 0; i < this.buy_fish_info.Length; i++) if(buy_fish_info[i])list_fish.Add(i);

        int index_r = Random.Range(0, list_fish.Count);
        this.index_sel_type = index_r;
        this.check_info_fish();
    }

    public void next_fish()
    {
        GameObject.Find("game").GetComponent<game>().play_sound(0);
        this.index_sel_type--;
        if (this.index_sel_type < 0)
        {
            this.index_sel_type = this.skin_fish.Length - 1;
        }
        this.check_info_fish();
    }

    public void prev_fish()
    {
        GameObject.Find("game").GetComponent<game>().play_sound(0);
        this.index_sel_type--;
        if (this.index_sel_type < 0)
        {
            this.index_sel_type = this.skin_fish.Length - 1;
        }
        this.check_info_fish();
    }

    private void check_info_fish()
    {
        this.player_fish.sprite = this.skin_fish[this.index_sel_type];
        if (this.buy_all_fish)
        {
            this.button_buy.SetActive(false);
            this.button_play.gameObject.SetActive(true);
        }
        else
        {
            if (this.buy_fish_info[this.index_sel_type])
            {
                if (PlayerPrefs.GetInt("id_buy_fish" + this.index_sel_type, 0) == 0)
                {
                    this.button_buy.SetActive(true);
                    this.button_play.gameObject.SetActive(false);
                    GameObject.Find("game").GetComponent<game>().set_index_buy_fish_product(this.index_sel_type);
                }
                else
                {
                    this.button_buy.SetActive(false);
                    this.button_play.gameObject.SetActive(true);
                }
            }
            else
            {
                this.button_buy.SetActive(false);
                this.button_play.gameObject.SetActive(true);
            }
        }
    }
    public void sel_color_fish(int index)
    {
        this.rest_btn_sel_color_fish();
        this.player_fish.color = this.img_color_fish[index].color;
        this.img_color_fish[index].sprite = this.icon_sel_color;
        this.index_sel_color = index;
        GameObject.Find("game").GetComponent<game>().check_color_where_sel_fish_play_two();
    }

    public void set_hide_fish(int index)
    {
        for(int i=0;i<this.img_color_fish.Length;i++)this.img_color_fish[i].gameObject.SetActive(true);
        this.img_color_fish[index].gameObject.SetActive(false);
    }

    private void rest_btn_sel_color_fish()
    {
        for (int i = 0; i < this.img_color_fish.Length; i++)
        {
            this.img_color_fish[i].sprite = this.icon_nomal_color;
        }
    }

    public void btn_start_game()
    {
        if (this.is_ready == false)
        {
            this.button_next_fish.SetActive(false);
            this.button_prev_fish.SetActive(false);
            this.panel_sel_color_fish.SetActive(false);
            this.button_play.GetComponentInChildren<Text>().text = "Ready!";
            this.is_ready = true;
            GameObject.Find("game").GetComponent<game>().game_play();
        }
        else
        {
            this.reset_status();
        }

    }

    public void buy_item_fish()
    {
        GameObject.Find("game").GetComponent<game>().buy_fish_product(this.index_sel_type);
    }

    public bool get_ready()
    {
        return this.is_ready;
    }

    public Sprite get_skin()
    {
        return this.skin_fish[this.index_sel_type];
    }

    public Color32 get_color()
    {
        return this.img_color_fish[this.index_sel_color].color;
    }

    public void reset_status()
    {
        this.button_play.GetComponentInChildren<Text>().text = "Play";
        this.is_ready = false;
        this.button_next_fish.SetActive(true);
        this.button_prev_fish.SetActive(true);
        this.panel_sel_color_fish.SetActive(true);
    }

    public int get_index_color_sel()
    {
        return this.index_sel_color;
    }
}
