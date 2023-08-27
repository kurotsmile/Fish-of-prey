using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_user_info : MonoBehaviour
{
    public Text txt_title;
    public Text txt_value;
    public GameObject icon_field;
    public string s_act = "";
    public void click()
    {
        if (s_act == "2")
        {
            Application.OpenURL(this.txt_value.text);
        }
    }
}
