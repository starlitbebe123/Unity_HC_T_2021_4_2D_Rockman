using UnityEngine;

public class Car : MonoBehaviour
{
    #region 欄位
    //單行註解
    /*
     * 多行註解
     * 
     */


    //物件資料-欄位 Field: 儲存物件資料
    //欄位語法
    //修飾詞 類型 名稱 結尾

    //修飾詞
    //私人private: 不顯示(預設值)
    //公開public: 顯示

    //類型四大類型
    //整數 int 任何沒有小數點的正負數值
    //浮點數 float 任何有小數點的正負數值, 有小數點時後面要加f(大小寫皆可)
    //字串 string 任何文字,必須使用雙引號""
    //布林值 bool 正反 true或false

    //關鍵字顏色: 藍色
    //自訂名稱顏色: 白色
    //結尾: 分號;

    //以汽車為範例

    //欄位屬性語法(用來補充資料, 給美術或企劃看, 會影響下一個分號前的內容)
    //[屬性明稱(屬性內容)]
    //標題 Header(字串)
    //提示 ToolTip(字串) 滑鼠放到上面會顯示的文字框
    //範圍 Range(限制最小值最大值的拉條) 只能用數值類型(整數或浮點數)
    [Header("汽車CC數")]
    [Tooltip("這是汽車的CC數")]
    [Range(1000, 5000)]
    public int cc = 2000;
    //省空間可以用逗號
    [Header("汽車重量"), Tooltip("這是汽車的重量"), Range(0.5f, 10)]
    public float weight = 1.5f;
    //下面這行不是數值,不能用Range
    [Header("汽車品牌"), Tooltip("這是汽車的品牌")]
    public string brand = "BMW";
    public bool hasWindow = true;

    //(限定Unity)常見類型
    //顏色 Color
    public Color color;
    public Color color2 = Color.red;
    //自訂顏色(R,G,B,Alpha)
    public Color color3 = new Color(0, 12, 12, 0.5f);

    //座標 二維 三維 四維 Vector2 Vector3 Vector4
    public Vector2 v2;
    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2my = new Vector2(7, 9);

    public Vector3 v3 = new Vector3(1, 2, 3);
    public Vector3 v4 = new Vector4(1, 2, 3, 4);

    // 按鍵 KeyCode
    public KeyCode key1; //無指定為None
    public KeyCode key2 = KeyCode.A;
    public KeyCode key3 = KeyCode.Mouse0;//滑鼠左鍵 0, 右1, 滾輪2
    public KeyCode key4 = KeyCode.Joystick1Button0;

    // 遊戲物件 與 元件
    // 遊戲物件 GameObject
    public GameObject obj1;
    // 元件 Component - 屬性面板上可摺疊的
    //名稱去掉空格 
    public Transform tra; //可儲存任何包含Transform元件的物件
    public SpriteRenderer sprite;//可儲存任何包含Sprite Renderer元件的物件
    #endregion

    #region 事件
    public int number = 1;
    public bool test = false;
    public string prop = "紅色藥水";
    int space = 0;
    //事件:在特定時間點會被執行的方法
    // Unity 提供的事件: 開始、更新

    //開始事件: 播放遊戲後執行一次
    //應用:數值初始化，例如:遊戲一開始多少金幣或生命值等等
    private void Start()
    {
        // print(任何資料) - 輸出資料到Console儀表板上
        print("我是開始事件唷~");

        //欄位存取
        // 取得
        //語法:欄位名稱
        //字串串接: 字串 + 其他欄位
        print("取得欄位" + number);

        //存放
        //語法: 欄位名稱 指定 值
        //值必須與此欄位類型相同
        test = true;
        print("存放欄位後的結果:" + test);
        prop = "藍色藥水";
        print("存放到具名稱:" + prop);

        //呼叫方法
        //方法名稱();
        Test();
        space = Ten();

        //傳回方法:
        //傳回類型 名稱 = 傳回方法();
        int t = Ten();
        print("傳回方法的結果:" + t);
        //呼叫方法要有相同數量的參數
        //有預設值的參數為【選填式參數】，沒另外寫就會出現預設值，就像"灰塵特效"
        //【選填式參數】只能寫在最右邊
        //有填的話會以後加的為主;
        Drive(200, "咻");
        //冒號:指定參數
        //有多個選填式參數
        //以下舉例為"音效為【選填式參數】"
        Drive(70, "閃電特效"); //錯誤-會把特效放在音效上
        Drive(70, effect: "閃電音效"); //正確-指定特效參數
    }
    //更新事件執行時間點與次數: 開始事件後以每秒六十次執行 60FPS
    //應用:監控玩家輸入與物件的持續行為，例如:玩家有沒有按按鈕或讓物件持續移動
    private void Update()
    {
        print("我是更新");
    }
    #endregion

    #region 方法 Unity Method
    //方法:保存較複雜或演算法的程式區塊
    //語法:
    //修飾詞 傳回類型 名稱() {較複雜或演算法的程式區塊}
    // void 無傳回:使用這個方法不會有傳回
    //方法是需要被 【呼叫】 才會執行
    /// <summary>
    /// 我是一個測試方法
    /// </summary>
    ///<returns>整數十</returns>
    private void Test()
    {
        print("我是測試方法。");
    }
    //如果不是無傳回void就要return

    private int Ten()
    {
        return 10;
    }

    //一般的的方法
    private void Drive50()
    {
        print("開車時數:" + 50);
        print("開車音效");
    }
    private void Drive100()
    {
        print("開車時數:" + 100);
        print("開車音效");
    }
    private void Drive300()
    {
        print("開車時數:" + 300);
        print("開車音效");
    }
    //進階的:用參數解決 Parameter
    //參數語法:類型 參數名稱
    /// <summary>
    /// 開車
    /// </summary>
    /// <param name="speed">開車的時速</param>
    /// <param name="sound">開車的音效</param>
    /// <param name="effect">開車的特效</param>
    //有預設值的參數為【選填式參數】，沒另外寫就會出現預設值，就像"灰塵特效"
    //【選填式參數】只能寫在最右邊
    private void Drive(int speed, string sound = "咻~", string effect = "灰塵效果")
    {
        print("開車時數:" + speed);
        print("開車音效:" + sound);
        print("特效:" + effect);
    }



    #endregion
}
