using UnityEngine;

public class Car : MonoBehaviour
{
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
    [Range(1000,5000)]
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
    public Color color3 = new Color(0,12,12, 0.5f);

    //座標 二維 三維 四維 Vector2 Vector3 Vector4


}
