using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_app : MonoBehaviour
{
    public Image icon;
    public Text txt_name;
    public string url;

    public void click()
    {
        Application.OpenURL(this.url);
    }
}
