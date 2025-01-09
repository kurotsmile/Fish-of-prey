using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class con_muc : MonoBehaviour
{
    private float speed = 1f;
    public void khoi_tao()
    {
        Vector3 diff = GameObject.Find("game").GetComponent<game>().get_pos_focus_player_ca();
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        this.speed = Random.Range(1f, 1.6f);
    }


    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * this.speed);
    }
}
