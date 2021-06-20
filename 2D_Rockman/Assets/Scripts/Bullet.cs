using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float attack;

    private void Start()
    {
        //讓這兩個編號的圖層間不會產生碰撞(十號跟十號)
        Physics2D.IgnoreLayerCollision(10, 10, true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果 碰到物件的標籤 等於 敵人
        if (collision.gameObject.tag == "Enemy")
        {
            //取得 敵人腳本 
            collision.gameObject.GetComponent<Enemy>().Hit(attack);
            
        }
        Destroy(gameObject);
       
    }
}
