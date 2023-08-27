using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_score : MonoBehaviour
{
    public Image icon_top;
    public Image img_avatar;
    public Text txt_name_player;
    public Text txt_lang;
    public Text txt_val;
    public string user_id;
    public string user_lang;
    public void click()
    {
        if (user_id != "") GameObject.Find("game").GetComponent<game>().carrot.user.show_user_by_id(user_id,user_lang);
    }
}
