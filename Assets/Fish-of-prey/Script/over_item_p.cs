using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class over_item_p : MonoBehaviour
{
    public Image img_icon_fish;
    public Image img_border;
    public Image img_border_bk;
    public Text txt_score;
    public Text txt_km;
    public GameObject icon_win;

    public void set_data(Sprite icon,Color32 color_fish,string score,string s_km)
    {
        this.gameObject.SetActive(true);
        this.icon_win.SetActive(false);
        this.img_icon_fish.sprite = icon;
        this.img_icon_fish.color = color_fish;
        this.txt_score.text = score;
        this.txt_km.text = s_km+" km";
        this.img_border.color = Color.white;
        this.img_border_bk.color = Color.gray;
        this.GetComponent<Animator>().enabled = false;
    }

    public void set_win()
    {
        this.icon_win.SetActive(true);
        this.img_border.color = Color.yellow;
        this.GetComponent<Animator>().enabled = true;
    }
}
