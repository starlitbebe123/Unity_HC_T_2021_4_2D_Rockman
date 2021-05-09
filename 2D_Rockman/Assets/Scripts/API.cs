
using UnityEngine;

public class API : MonoBehaviour
{
    // 靜態 API
    // 非靜態 API

    //1. 非靜態 API 需要"物件"(如下面的tra1就是物件)
    //2. 定義一個欄位 - 物件
    public Transform tra1;
    public Transform tra2;
    public SpriteRenderer spr;

    private void Start()
    {
        //靜態
        //類別名稱.靜態屬性
        float f = Random.value;

        //非靜態
        //取得屬性
        //物件名稱.非靜態屬性
        print("取得物件的座標:" + tra1.position);

        //非靜態存放屬性
        //物件名稱.非靜態屬性 指定 值
        //物件必須要有指定的屬性才能放
        //下列為變更大小
        tra2.localScale = new Vector3(3, 3, 3);

        spr.color = new Color(1, 0, 0);
        spr.flipX = true;
    }

    private void Update()
    {
        //非靜態
        //使用方法
        //物件名稱.非靜態方法(對應參數)
        //下列為自動移動
        tra2.Translate(0.1f, 0, 0); 
    }
}
