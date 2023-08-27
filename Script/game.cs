  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public Carrot.Carrot carrot;
    public quan_canh quang_canh_view;
    public GameObject panel_home;
    public GameObject panel_play;
    public GameObject panel_play_help;
    public GameObject panel_play_help_two_play;
    public GameObject panel_play_score;
    public GameObject panel_gameover;

    public Sprite icon_sel_color;
    public Sprite icon_buy_all_fish;
    public Sprite icon_nomal_color;
    public Sprite icon_top_player;
    public Color32[] color_top_player;
    public Color32 color_select;

    public AudioSource[] sound;
    public AudioSource music_background;
    public GameObject ca_chet_prefab;

    public GameObject item_socre_prefab;
    public HorizontalLayoutGroup HorizontalLayoutGroup_player_sel;

    [Header("Player Game")]
    private int count_number_player = 0;
    public con_ca[] player_ca;
    public Player_design[] player_design;
    public Sprite[] skin_fish;
    public bool[] buy_fish;
    public bool buy_all_fish;
    public GameObject panel_player_jump;
    public control_fish[] control_ca;
    public Image[] img_btn_sel_number_player;

    [Header("Gameover one player")]
    public GameObject panel_over_player_one;
    public Text txt_game_scores;
    public Text txt_game_scores_game_over;
    private int game_scores_hight = 0;
    private List<int> list_eat_fish;
    public Transform area_body_item_game_over;
    public GameObject item_gameover_fish_prefab;
    public GameObject panel_scores_hight;
    public Text txt_scores_hight;
    public Text txt_over_location_hight;

    [Header("Gameover two player")]
    public GameObject panel_over_player_two;
    public HorizontalLayoutGroup HorizontalLayoutGroup_control_two;
    public over_item_p[] over_item_fish;

    [Header("Gamepad Player")]
    public List<GameObject> list_gamepad_main;
    public List<GameObject> list_gamepad_play_tip;
    public List<GameObject> list_gamepad_gameover;

    private int index_fish_buy = -1;
    private KeyCode[] KeyCode_default = new KeyCode[10];

    void Start()
    {
        this.carrot.Load_Carrot(this.check_exit_app);
        this.carrot.shop.onCarrotPaySuccess += this.onBuySuccessCarrotPay;
        this.carrot.act_after_close_all_box = this.set_list_gamepad_main;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (PlayerPrefs.GetInt("id_buy_all_fish", 0) == 0)
            this.buy_all_fish = false;
        else
            this.buy_all_fish = true;

        KeyCode_default[0] = KeyCode.O;
        KeyCode_default[1] = KeyCode.P;
        KeyCode_default[2] = KeyCode.I;
        KeyCode_default[3] = KeyCode.U;
        KeyCode_default[4] = KeyCode.Y;
        KeyCode_default[5] = KeyCode.H;
        KeyCode_default[6] = KeyCode.T;
        KeyCode_default[7] = KeyCode.J;
        KeyCode_default[8] = KeyCode.K;
        KeyCode_default[9] = KeyCode.L;

        Carrot.Carrot_Gamepad gamepad_player4 = this.carrot.game.create_gamepad("Player_4");
        gamepad_player4.set_gamepad_keydown_x(this.gamepad_press_select4);
        gamepad_player4.set_gamepad_keydown_a(this.gamepad_press_select4);
        gamepad_player4.set_gamepad_keydown_b(this.gamepad_press_select4);
        gamepad_player4.set_gamepad_keydown_start(this.gamepad_press_start4);
        gamepad_player4.set_gamepad_keydown_select(this.gamepad_press_select4);
        gamepad_player4.set_gamepad_keydown_left(this.gamepad_press_left4);
        gamepad_player4.set_gamepad_keydown_right(this.gamepad_press_right4);
        gamepad_player4.set_gamepad_keydown_down(this.gamepad_press_down);
        gamepad_player4.set_gamepad_keydown_up(this.gamepad_press_up);
        gamepad_player4.set_KeyCode_default(KeyCode_default);

        Carrot.Carrot_Gamepad gamepad_player3 = this.carrot.game.create_gamepad("Player_3");
        gamepad_player3.set_gamepad_keydown_x(this.gamepad_press_select3);
        gamepad_player3.set_gamepad_keydown_a(this.gamepad_press_select3);
        gamepad_player3.set_gamepad_keydown_b(this.gamepad_press_select3);
        gamepad_player3.set_gamepad_keydown_start(this.gamepad_press_start3);
        gamepad_player3.set_gamepad_keydown_select(this.gamepad_press_select3);
        gamepad_player3.set_gamepad_keydown_left(this.gamepad_press_left3);
        gamepad_player3.set_gamepad_keydown_right(this.gamepad_press_right3);
        gamepad_player3.set_gamepad_keydown_down(this.gamepad_press_down);
        gamepad_player3.set_gamepad_keydown_up(this.gamepad_press_up);
        gamepad_player3.set_KeyCode_default(KeyCode_default);

        Carrot.Carrot_Gamepad gamepad_player2 = this.carrot.game.create_gamepad("Player_2");
        gamepad_player2.set_gamepad_keydown_x(this.gamepad_press_select2);
        gamepad_player2.set_gamepad_keydown_a(this.gamepad_press_select2);
        gamepad_player2.set_gamepad_keydown_b(this.gamepad_press_select2);
        gamepad_player2.set_gamepad_keydown_start(this.gamepad_press_start2);
        gamepad_player2.set_gamepad_keydown_select(this.gamepad_press_select2);
        gamepad_player2.set_gamepad_keydown_left(this.gamepad_press_left2);
        gamepad_player2.set_gamepad_keydown_right(this.gamepad_press_right2);
        gamepad_player2.set_gamepad_keydown_down(this.gamepad_press_down);
        gamepad_player2.set_gamepad_keydown_up(this.gamepad_press_up);
        gamepad_player2.set_KeyCode_default(KeyCode_default);

        Carrot.Carrot_Gamepad gamepad_player1 = this.carrot.game.create_gamepad("Player_1");
        gamepad_player1.set_gamepad_keydown_x(this.gamepad_press_select1);
        gamepad_player1.set_gamepad_keydown_a(this.gamepad_press_select1);
        gamepad_player1.set_gamepad_keydown_b(this.gamepad_press_select1);
        gamepad_player1.set_gamepad_keydown_start(this.gamepad_press_start1);
        gamepad_player1.set_gamepad_keydown_select(this.gamepad_press_select1);
        gamepad_player1.set_gamepad_keydown_left(this.gamepad_press_left1);
        gamepad_player1.set_gamepad_keydown_right(this.gamepad_press_right1);
        gamepad_player1.set_gamepad_keydown_down(this.gamepad_press_down);
        gamepad_player1.set_gamepad_keydown_up(this.gamepad_press_up);

        this.panel_home.SetActive(true);
        this.panel_play.SetActive(false);
        this.panel_gameover.SetActive(false);
        this.quang_canh_view.khoi_tao(this.skin_fish);
        this.list_eat_fish = new List<int>();
        this.game_scores_hight = PlayerPrefs.GetInt("scores_hight");
        this.btn_select_number_player(0);

        for (int i = 0; i < this.player_ca.Length; i++)
        {
            this.player_ca[i].gameObject.SetActive(false);
            this.player_ca[i].load();
            this.control_ca[i].gameObject.SetActive(false);
        }

        this.carrot.game.set_list_button_gamepad_console(this.list_gamepad_main);

        this.carrot.game.load_bk_music(this.sound[7]);
    }

    private void check_exit_app()
    {
        if (this.panel_gameover.activeInHierarchy)
        {
            this.back_home();
            this.carrot.set_no_check_exit_app();
        }
        else
        {
            if (this.panel_play.activeInHierarchy)
            {
                this.back_home();
                this.carrot.set_no_check_exit_app();
            }
        }
    }

    private void set_list_gamepad_main()
    {
        this.carrot.game.set_list_button_gamepad_console(this.list_gamepad_main);
    }

    public void game_play()
    {
        this.play_sound(0);
        bool is_play = false;

        int count_ready = 0;
        for (int i = 0; i < this.player_design.Length; i++) {
            this.control_ca[i].gameObject.SetActive(false);
            if (this.player_design[i].get_ready() == true) count_ready++; 
        }

        if (count_ready == (this.count_number_player + 1))
        {
            is_play = true;
            for (int i = 0; i <= this.count_number_player; i++)
            {
                this.player_ca[i].skin.sprite = this.player_design[i].get_skin();
                this.player_ca[i].skin.color = this.player_design[i].get_color();
                this.player_ca[i].reset_ca();
                this.player_ca[i].set_control_jump(false);
                this.control_ca[i].gameObject.SetActive(true);
                this.control_ca[i].set_play(this.player_design[i].get_color(), this.player_design[i].get_skin());
            }
            this.panel_play_score.SetActive(false);
        }
        

        if (this.count_number_player == 0)
        {
            this.list_eat_fish = new List<int>();
            this.txt_game_scores.text = "0";
            this.panel_play_score.SetActive(true);
        }

        if (is_play)
        {
            this.panel_home.SetActive(false);
            this.panel_play.SetActive(true);
            this.panel_gameover.SetActive(false);
            this.quang_canh_view.xoa_toan_bo_ca_moi();
            this.panel_play_help.SetActive(true);
            this.panel_player_jump.SetActive(true);
            this.HorizontalLayoutGroup_control_two.enabled = true;
            this.carrot.game.set_list_button_gamepad_console(this.list_gamepad_play_tip,-250);
            this.panel_play_help.GetComponent<Image>().color = new Color32(0, 0, 0, 10);
        }
    } 

    public void game_replay()
    {
        this.ShowInterstitialAd();
        this.game_play();
    }

    public void back_home()
    {
        this.carrot.game.set_list_button_gamepad_console(this.list_gamepad_main);
        this.ShowInterstitialAd();
        this.play_sound(0);
        this.panel_home.SetActive(true);
        this.panel_play.SetActive(false);
        this.panel_gameover.SetActive(false);

        for(int i = 0; i < this.player_ca.Length; i++)
        {
            this.player_design[i].reset_status();
            this.player_ca[i].off();
        }
    }

    public void play_sound(int index)
    {
        if (this.carrot.get_status_sound()) this.sound[index].Play();
    }

    public void add_ca_chet(Transform tr_ca)
    {
        GameObject item_ca_chet = Instantiate(this.ca_chet_prefab);
        item_ca_chet.transform.SetParent(this.quang_canh_view.transform);
        item_ca_chet.transform.localPosition = new Vector3(tr_ca.localPosition.x, tr_ca.localPosition.y, 1f);
        item_ca_chet.transform.localScale = tr_ca.localScale;
        Destroy(item_ca_chet.gameObject, 5f);
    }

    public void show_setting()
    {
        Carrot.Carrot_Box box_setting=this.carrot.Create_Setting();

        if (this.buy_all_fish==false)
        {
            Carrot.Carrot_Box_Item setting_buy_all_fish = box_setting.create_item_of_top("buy_all_fish");
            setting_buy_all_fish.set_icon(this.icon_buy_all_fish);
            setting_buy_all_fish.set_title("Buy all the fish");
            setting_buy_all_fish.set_tip("Buy all kinds of fish in the game");
            setting_buy_all_fish.set_act(() => this.carrot.buy_product(2));
        }

        box_setting.set_act_before_closing(after_close_setting);
        box_setting.update_gamepad_cosonle_control();
    }

    public void after_close_setting(List<string> list_item_change)
    {
        if (this.panel_play.activeInHierarchy)
            this.carrot.game.set_enable_gamepad_console(false);
        else
        {
            this.set_list_gamepad_main();
        } 
    }

    public void add_eat_fish(int type_con_moi)
    {
        if (this.count_number_player==0)
        {
            this.list_eat_fish.Add(type_con_moi);
            this.txt_game_scores.text = this.list_eat_fish.Count.ToString();
        }
    }

    public void ShowInterstitialAd()
    {
        this.carrot.ads.show_ads_Interstitial();
    }

    public void game_rate()
    {
        this.carrot.show_rate();
    }

    public void btn_game_share()
    {
        this.carrot.show_share();
    }

    [ContextMenu("Delete All Data")]
    public void delete_all_data()
    {
        this.carrot.delete_all_data();
    }

    public void show_list_scores()
    {
        this.carrot.game.Show_List_Top_player();
    }

    public void btn_select_number_player(int number_player)
    {
        this.count_number_player = number_player;
        for (int i = 0; i < this.img_btn_sel_number_player.Length; i++)
        {
            this.img_btn_sel_number_player[i].color = Color.white;
            this.player_design[i].gameObject.SetActive(false);
        }

        this.img_btn_sel_number_player[number_player].color = this.color_select;
        for (int i = 0; i <= number_player; i++)
        {
            this.player_design[i].gameObject.SetActive(true);
            this.player_design[i].load_desing(this.skin_fish, this.buy_fish, i, this.buy_all_fish);
        }

        if (number_player == 0 || number_player == 1)
        {
            this.HorizontalLayoutGroup_player_sel.childControlWidth = false;
            this.HorizontalLayoutGroup_player_sel.childScaleWidth = false;
            this.HorizontalLayoutGroup_player_sel.childForceExpandWidth = false;
            this.player_design[0].GetComponent<RectTransform>().sizeDelta = new Vector2(350,196);
            this.player_design[1].GetComponent<RectTransform>().sizeDelta = new Vector2(350,196);
        }
        else
        {
            this.HorizontalLayoutGroup_player_sel.childControlWidth = true;
            this.HorizontalLayoutGroup_player_sel.childScaleWidth = true;
            this.HorizontalLayoutGroup_player_sel.childForceExpandWidth = true;
        }
    }

    public void reload_info_player_design()
    {
        this.btn_select_number_player(this.count_number_player);
    }

    public void show_gameover()
    {
        this.carrot.play_vibrate();
        if (this.count_number_player!=0)
        {
            int count_fish_die = 0;
            for(int i = 0; i <= this.count_number_player; i++) if(this.player_ca[i].get_die_status()) count_fish_die++;

            if (count_fish_die == (this.count_number_player+1))
            {
                for (int i = 0; i <this.over_item_fish.Length; i++) this.over_item_fish[i].gameObject.SetActive(false);

                int max_score=0;
                int index_max = -1;
                for (int i = 0; i <= this.count_number_player; i++)
                {
                    if (this.player_ca[i].get_socre() > max_score)
                    {
                        max_score = this.player_ca[i].get_socre();
                        index_max = i;
                    }

                    this.over_item_fish[i].set_data(this.player_design[i].get_skin(), this.player_design[i].get_color(), this.player_ca[i].get_socre().ToString(), this.player_ca[i].get_location_km().ToString());
                }

                if(index_max!=-1) this.over_item_fish[index_max].set_win();

                this.check_hight_score(max_score);
                this.show_info_gameover();
                this.panel_over_player_two.SetActive(true);
                this.quang_canh_view.stop_quan_canh();
                this.HorizontalLayoutGroup_control_two.enabled = true;
            }
            else
            {
                for(int i=0;i<this.player_ca.Length;i++) if (this.player_ca[i].get_die_status()) this.control_ca[i].gameObject.SetActive(false);
            }
        }
        else
        {
            this.check_hight_score(this.player_ca[0].get_socre());
            this.carrot.clear_contain(this.area_body_item_game_over);

            int[] fish_eat = new int[this.skin_fish.Length];

            for (int i = 0; i < this.list_eat_fish.Count; i++)
            {
                for (int y = 0; y < this.skin_fish.Length; y++)
                {
                    if (this.list_eat_fish[i] == y) fish_eat[y]++;
                }
            }

            for (int i = 0; i < fish_eat.Length; i++)
            {
                if (fish_eat[i] != 0)
                {
                    GameObject i_fish_over = Instantiate(this.item_gameover_fish_prefab);
                    i_fish_over.transform.SetParent(this.area_body_item_game_over);
                    i_fish_over.transform.localScale = new Vector3(1f, 1f, 0f);
                    i_fish_over.GetComponent<item_app>().txt_name.text = "x " + fish_eat[i].ToString();
                    i_fish_over.GetComponent<item_app>().icon.sprite = this.skin_fish[i];
                }
            }
            this.show_info_gameover();
            this.txt_game_scores_game_over.text = this.player_ca[0].get_socre().ToString();
            this.panel_over_player_one.SetActive(true);
            this.quang_canh_view.stop_quan_canh();
        }
    }

    private void check_hight_score(int new_score)
    {
        if (new_score > this.game_scores_hight)
        {
            PlayerPrefs.SetInt("scores_hight", new_score);
            this.game_scores_hight = new_score;
        }

        this.carrot.game.update_scores_player(this.game_scores_hight);

        if (this.game_scores_hight > 0)
        {
            this.txt_scores_hight.text = this.game_scores_hight.ToString();
            this.panel_scores_hight.SetActive(true);
        }
        else
        {
            this.panel_scores_hight.SetActive(false);
        }
    }

    private void show_info_gameover()
    {
        this.carrot.game.set_list_button_gamepad_console(this.list_gamepad_gameover);
        this.panel_play.SetActive(false);
        this.panel_gameover.SetActive(true);
        this.panel_play_help.SetActive(false);
        this.panel_over_player_one.SetActive(false);
        this.panel_over_player_two.SetActive(false);
        this.txt_over_location_hight.text = this.quang_canh_view.txt_location_km.text;
        this.play_sound(3);
    }

    public void check_color_where_sel_fish_play_two()
    {
        if (this.count_number_player!=0)
        {
            this.player_design[0].set_hide_fish(this.player_design[1].get_index_color_sel());
            this.player_design[1].set_hide_fish(this.player_design[0].get_index_color_sel());
        }
    }

    public Vector3 get_pos_focus_player_ca()
    {
        if (this.count_number_player != 0)
        {
            int rand_index = Random.Range(0, this.player_ca.Length);
            if (rand_index == 0)
                return player_ca[0].transform.position - transform.position;
            else
                return player_ca[1].transform.position - transform.position;
        }
        else
        {
            return player_ca[0].transform.position - transform.position;
        }
    }

    public void buy_success(Product product)
    {
        this.onBuySuccessCarrotPay(product.definition.id);
    }

    private void onBuySuccessCarrotPay(string id_product)
    {


        if (id_product==this.carrot.shop.get_id_by_index(1))
        {
            this.carrot.show_msg("Purchase", "Purchase successful! Now you can use fish to play", Carrot.Msg_Icon.Success);
            PlayerPrefs.SetInt("id_buy_fish" + this.index_fish_buy, 1);
            this.reload_info_player_design();
        }

        if (id_product==this.carrot.shop.get_id_by_index(2))
        {
            this.carrot.show_msg("Purchase", "Purchase successful! You have bought all kinds of fish and can use them", Carrot.Msg_Icon.Success);
            PlayerPrefs.SetInt("id_buy_all_fish", 1);
            this.buy_all_fish = true;
            this.reload_info_player_design();
        }
    }


    public void buy_fish_product(int index_fish_buy)
    {
        this.index_fish_buy = index_fish_buy;
        this.buy_product(1);
    }

    public void buy_product(int index_product)
    {
        this.carrot.shop.buy_product(index_product);
    }

    public void set_index_buy_fish_product(int index_fish)
    {
        this.index_fish_buy = index_fish;
    }

    public void btn_show_user_login()
    {
        this.carrot.show_login();
    }

    public void btn_show_list_carrot_app()
    {
        this.carrot.show_list_carrot_app();
    }

    public void btn_act_play_all_fish()
    {
        this.carrot.game.set_enable_gamepad_console(false);
        for(int i = 0; i <= this.count_number_player; i++)this.player_ca[i].play_now();
        this.panel_play_help.SetActive(false);
        this.quang_canh_view.play_quan_canh();
        this.play_sound(0);
        this.carrot.delay_function(1f, set_size_all_control_fish);
    }

    private void set_size_all_control_fish()
    {
        this.HorizontalLayoutGroup_control_two.enabled = false;
    }

    #region Gamepad Player
    public void gamepad_press_down()
    {
        if (!this.panel_play.activeInHierarchy) this.carrot.game.gamepad_keydown_down_console();
    }

    public void gamepad_press_up()
    {
        if (!this.panel_play.activeInHierarchy) this.carrot.game.gamepad_keydown_up_console();
    }

    public void gamepad_press_left1()
    {
        if (this.panel_home) this.player_design[0].next_fish();
        else if(this.panel_play) this.control_ca[0].click();
        else this.carrot.game.gamepad_keydown_down_console();
    }

    public void gamepad_press_right1()
    {
        if (this.panel_home) this.player_design[0].prev_fish();
        else if (this.panel_play) this.control_ca[0].click();
        else this.carrot.game.gamepad_keydown_up_console();
    }

    public void gamepad_press_left2()
    {
        if (this.panel_home) this.player_design[1].next_fish();
        else if (this.panel_play) this.control_ca[1].click();
        else this.carrot.game.gamepad_keydown_down_console();
    }

    public void gamepad_press_right2()
    {
        if (this.panel_home) this.player_design[1].prev_fish();
        else if (this.panel_play) this.control_ca[1].click();
        else this.carrot.game.gamepad_keydown_up_console();
    }

    public void gamepad_press_left3()
    {
        if (this.panel_home) this.player_design[2].next_fish();
        else if (this.panel_play) this.control_ca[2].click();
        else this.carrot.game.gamepad_keydown_down_console();
    }

    public void gamepad_press_right3()
    {
        if (this.panel_home) this.player_design[2].prev_fish();
        else if (this.panel_play) this.control_ca[2].click();
        else this.carrot.game.gamepad_keydown_up_console();
    }

    public void gamepad_press_left4()
    {
        if (this.panel_home) this.player_design[3].next_fish();
        else if (this.panel_play) this.control_ca[3].click();
        else this.carrot.game.gamepad_keydown_down_console();
    }

    public void gamepad_press_right4()
    {
        if (this.panel_home) this.player_design[3].prev_fish();
        else if (this.panel_play) this.control_ca[3].click();
        else this.carrot.game.gamepad_keydown_up_console();
    }

    public void gamepad_press_start1()
    {
        if (this.panel_home.activeInHierarchy) this.player_design[0].btn_start_game();
        else if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[0].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_start2()
    {
        if (this.panel_home.activeInHierarchy) this.player_design[1].btn_start_game();
        else if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[1].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_start3()
    {
        if (this.panel_home.activeInHierarchy) this.player_design[2].btn_start_game();
        else if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[2].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_start4()
    {
        if (this.panel_home.activeInHierarchy) this.player_design[3].btn_start_game();
        else if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[3].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_select1()
    {
        if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[0].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_select2()
    {
        if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[1].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_select3()
    {
        if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[2].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }

    public void gamepad_press_select4()
    {
        if (this.panel_play_help.activeInHierarchy) this.carrot.game.gamepad_keydown_enter_console();
        else if (this.panel_play.activeInHierarchy) this.control_ca[3].click();
        else this.carrot.game.gamepad_keydown_enter_console();
    }
    #endregion

}