using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_fish : MonoBehaviour
{
    public Image img_control;
    public Image img_fish_type;
    public Image img_exp;
    public con_ca ca;

    public void set_play(Color32 color_set,Sprite img_type_fish)
    {
        this.img_control.color = color_set;
        this.img_exp.color = color_set;
        this.img_exp.gameObject.SetActive(false);
        this.img_fish_type.sprite = img_type_fish;
    }

    public void click()
    {
        ca.jump();
    }

    public void press_up()
    {
        this.img_exp.gameObject.SetActive(false);
    }

    public void press_down()
    {
        this.img_exp.gameObject.SetActive(true);
    }
}
