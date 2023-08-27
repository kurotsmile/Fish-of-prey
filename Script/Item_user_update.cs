using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_user_update : MonoBehaviour
{
    public string id_name;
    public InputField inp;
    public Text txt_title;
    public Dropdown dropdow;
    private int type_data = 0;

    public void set_data_type1()
    {
        this.inp.gameObject.SetActive(true);
        this.dropdow.gameObject.SetActive(false);
        this.type_data = 1;
    }

    public void set_data_type2(IList list_data_val,string val_sel)
    {
        int sel_index = 0;
        this.inp.gameObject.SetActive(false);
        this.dropdow.gameObject.SetActive(true);
        this.type_data = 2;
        this.dropdow.ClearOptions();
        for (int i = 0; i < list_data_val.Count; i++) {
            if (val_sel == list_data_val[i].ToString())
            {
                sel_index = i;
            }
            this.dropdow.options.Add(new Dropdown.OptionData() { text = list_data_val[i].ToString() });
        }
        this.dropdow.value = sel_index;
        this.dropdow.RefreshShownValue();
    }

    public void set_data_type3()
    {
        this.inp.gameObject.SetActive(true);
        this.inp.contentType = InputField.ContentType.Password;
        this.dropdow.gameObject.SetActive(false);
        this.type_data = 3;
    }

    public void set_data_type4()
    {
        this.inp.gameObject.SetActive(true);
        this.inp.contentType = InputField.ContentType.DecimalNumber;
        this.dropdow.gameObject.SetActive(false);
        this.type_data = 3;
    }

    public void set_data_type5()
    {
        this.inp.gameObject.SetActive(true);
        this.inp.contentType = InputField.ContentType.EmailAddress;
        this.dropdow.gameObject.SetActive(false);
        this.type_data = 3;
    }

    public string get_val()
    {
        if (this.type_data == 1||this.type_data==3)
        {
            return this.inp.text;
        }
        else
        {
            return this.dropdow.value.ToString();
        }
    }
}
