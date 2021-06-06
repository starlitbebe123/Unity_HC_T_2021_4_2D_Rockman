using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度")]
    [Range(0, 1000)]
    public float playerSpeed = 10.5f;

    [Header("跳躍高度")]
    [Range(0, 3000)]
    public int jumpHeight = 100;

    [Header("血量")]
    [Range(0, 200)]
    public float playerHealth = 100f;

    [Header("是否在地板上")]
    [Tooltip("判斷是否在地板上")]
    public bool isGrounded = false;

    [Header("判斷地板碰撞的位移與半徑")]
    [Tooltip("判斷是否在地板上")]
    public Vector3 groundOffset;
    public float groundRadius = 0.2f;

    [Header("子彈(遊戲物件)")]
    [Tooltip("子彈(遊戲物件)")]
    public GameObject bullet;

    [Header("子彈生成點")]
    [Tooltip("子彈生成點")]
    public Transform bulletSpawn;

    [Range(0, 5000)]
    public float bulletSpeed;

    [Header("開槍音效")]
    [Tooltip("開槍的音效")]
    public AudioClip fireSound;

    [Header("跳力道")]
    [Tooltip("跳力道")]
    public float jump;

    AudioSource aud;
    Rigidbody2D rig;
    Animator ani;
    #endregion

    //按右上...的Debug可以看到private的

    #region 事件
    private void Start()
    {
        //利用程式取得元件
        //傳回元件 取得元件() - <泛型>
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
    //一秒約執行60次
    private void Update()
    {
        Movement();
        Jump();
    }

    //繪製圖示 - 輔助編輯時的圖形線條
    private void OnDrawGizmos()
    {
        //繪製地板監控
        //1.指定顏色
        Gizmos.color = new Color(1,0,0,0.5f);
        //2.繪製圖形
        //transform可以抓到此腳本同一層的變形元件
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y ,groundRadius); 
    }

    private void Movement()
    {
        //1.要抓到玩家按下左右鍵的資訊Input
        //2.使用左右鍵的資訊控制腳色移動
        //水平移動，按左鍵會是-1，按右鍵會是1，不按是0
        float h = Input.GetAxis("Horizontal");
        //鋼體.加速度 = 二維向量(水平 * 速度 * 一幀的時間, 0); 
        //一幀的時間 - 解決不同效能的裝置速度差問題, 指定回原本的Y軸加速度)
        rig.velocity = new Vector2(h * playerSpeed * Time.deltaTime, rig.velocity.y);

        //翻面
        //如果 按下 D 面向右邊 0,0,0
        //否則 如果 按下A面向左邊 0,180,0
        //rotation只有0跟1通常不要用, 用eulerAngles
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        //設定動畫
        //水平值 不等於 零 布林值 打勾
        //水平值 等於 零 布林值 取消
        ani.SetBool("Run", h != 0); 
    }
    #endregion
    #region #region 方法
    /// <summary>
    /// 跳越
    /// </summary>
    private void Jump()
    {
        //如果 玩家 按下空白鍵 並且 在地板上 就 往上跳躍
        //判斷式C#
        //if(布林值){當布林值等於true時會執行這個程式}
        //*判斷布林值是否等於true有兩種寫法
        //1. isGrounded == true 一般寫法
        //2. isGrounded 簡略寫法

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                
                //鋼體.添加推力(二維向量);
                rig.AddForce(new Vector2(0, jump));
            }

            //碰到的物件= 2D物理.覆蓋圖形(中心點, 半徑);
            //圖層語法: 1<< 圖層編號(LayerMask int)
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1<<8);
        
        //如果 碰到的物件 存在 並且 碰到的物件名稱 等於等於 地板 就代表在地板上
        //並且 &&
        //等於 ==
        if(hit && (hit.name == "地板" || hit.name == "跳台"))
        {
            isGrounded = true;
        }
        //否則 不再地板上
        //否則 else
        //語法: else{程式區塊} 只能寫在if下方
        else 
        { 
            isGrounded = false;  
        }
    }


  

    /// <summary>
    /// 射擊
    /// </summary>
    private void Shoot()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="dmg">受到的傷害值</param>
    private void Hurt(float dmg)
    {
 
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <returns>是否死亡</returns>
    private bool Death()
    {
        return false;
    }

    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="itemName">道具名稱</param>
    private void ItemGet(string itemName)
    {

    }
    #endregion
}
