
using UnityEngine;

public class APIStatic : MonoBehaviour
{
    //認識靜態API
    //包含關鍵字 static 就是靜態

    public Vector3 a = new Vector3(1, 1, 1);
    public Vector3 b = new Vector3(1, 1, 1);


    private void Start()
    {
        #region 認識靜態屬性方法
        //靜態取得是抓出資料，靜態存放是修改資料

        //屬性 欄位 要知道如何存取

        //語法:
        //類別名稱.靜態屬性名稱

        //練習取得靜態屬性 Static Properties
        //語法:
        //類別名稱.靜態屬性名稱
        float r =Random.value;  //隨機.值
        print("隨機值:" + r);

        //練習存放靜態屬性 Static Properties
        //有顯示(Read Only)的屬性不能存放
        //語法:
        //類別名稱.靜態屬性名稱
        Cursor.visible = false;  //指標.可見度

        //練習使用靜態方法 Static Methods
        //語法:
        //類別名稱.靜態屬性名稱
        int attack = Random.Range(100, 300);
        print("隨機攻擊力:" + attack);

        float n = Mathf.Abs(-99.9f);
        print("絕對值內容:" + n);

        //靜態屬性Static Properties:直接跑一個數值
        //靜態方法Static Methods:運算出一個值
        #endregion
        
        //練習靜態屬性
        
        //靜態取得
        print("攝影機數量:" + Camera.allCamerasCount);
       
        //靜態存放
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, -20);
        print("2D重力大小:" + Physics2D.gravity);
        
        //練習靜態方法
        //使用
        Application.OpenURL("https://unity.com/");
        float f = Mathf.Floor(9.9999f);
        print("去掉小數點" + f);

        float dis = Vector3.Distance(a, b);
        print("a與b的距離" + dis);
       
    }

    private void Update()
    {
        //靜態取得
        print("是否輸入任意鍵:" + Input.anyKeyDown); 
        print("經過時間:" + Time.time);
        bool b = Input.GetKeyDown(KeyCode.Space);
        print("是否輸入空白鍵:" + b);
    }
}
