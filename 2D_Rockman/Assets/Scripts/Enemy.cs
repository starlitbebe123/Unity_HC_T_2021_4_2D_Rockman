
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 欄位
    public float speed = 1f;
  
    public float attack = 10f;
   
    public float hp;

    public float radiusTrack = 5;

    public float radiusAttack = 2;

    public float cd = 3;
    protected float cdTimer;

    protected Transform player;
    private Rigidbody2D rig;
    protected Animator ani;

    [Header("偵測地板的位移與半徑")]
    public Vector3 groundOffset;
    public float groundRadius = 0.1f;

    [Header("攻擊區域位移與尺寸")]
    public Vector3 attackOffset;
    public Vector3 attackSize;

    public GameObject Item;
    public float dropRate;

    //原始速度
    private float speedOriginal;
    
    
    #endregion

    #region 事件
    protected virtual void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //玩家 = 遊戲物件.尋找("物件名稱) 搜尋場景內所有物件
        //transform.Find  是搜尋子物件
        player = GameObject.Find("Player").transform;

        //讓敵人一開始就進行攻擊
        cdTimer = cd;

        //原始速度
        speedOriginal = speed;
    }

    private void Update()
    {
        Move();
    }

    private void dropItem()
    {
        float r = Random.value; 

        if (r <= dropRate) 
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }

    }
    private void OnDrawGizmos()
    {
        //追蹤範圍
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusTrack);
        //攻擊範圍
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, radiusAttack);
        //偵測面前是不是地板
        Gizmos.color = new Color(0.6f, 0.9f, 1, 0.7f);
        Gizmos.DrawSphere(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius);

        //攻擊範圍
        Gizmos.color = new Color(0.3f, 0.3f, 1, 0.8f);
        Gizmos.DrawCube(transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y, attackSize); 
    }
    #endregion
    #region 方法
    private void Move()
    {
        //如果 Animator的Death是True的 就跳出
        if (ani.GetBool("Death")) return;

        //距離 = 三圍向量.距離(A點-B點)
        float dis = Vector3.Distance(player.position, transform.position);
        
        //如果 玩家跟敵人 的 距離 小於等於 攻擊範圍 就攻擊
        if (dis <= radiusAttack)
        {
            Attack();
            LookAtPlayer();
        }
        //否則 如果 玩家跟敵人 的 距離 小於等於 追蹤範圍 就往前方移動
        else if (dis <= radiusTrack) 
        {
            rig.velocity = transform.right * speed * Time.deltaTime;
            ani.SetBool("Walk", speed != 0); //速度不等於零 才會播放 走路動畫
            LookAtPlayer();
            CheckGround(); 
        }
        else  
        {
            ani.SetBool("Walk", false); 
        }
    }

    private void Attack()
    {
        ani.SetBool("Walk", false); 
        //如果 計時器 <= 攻擊冷卻 就累加
        if (cdTimer <= cd)
        {
            cdTimer += Time.deltaTime;
        }
        //否則 攻擊 並 將計時器歸零
        else
        {
            AttackState(); 
        }
    }

    protected virtual void AttackState() 
    {
        cdTimer = 0;
        ani.SetTrigger("Attack");
        //碰撞物件 = 2D物理.覆蓋盒形(中心點, 尺寸, 角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * attackOffset.x + transform.up * attackOffset.y, attackSize, 0);
        if (hit && hit.tag == "Player") hit.GetComponent<Player>().Hit(attack);
    }

    private void LookAtPlayer() 
    {
        //如果 敵人x 大於 玩家x 較代表玩家在左邊 角度180
        if(transform.position.x > player.position.x)
        { 
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //否則 敵人x 小於 玩家x 就代at玩家在右邊 角度0
        else 
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    //檢查是否有地板
    private void CheckGround() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.right * groundOffset.x + transform.up * groundOffset.y, groundRadius, 1 << 8);
        
        //判斷式 程式只有一句 (一個分號) 可以省略 大括號
        if(hit && (hit.name == "地板"|| hit.name == "跳台"))
        speed = speedOriginal; 
        else speed = 0;
        
    }

    protected virtual void Dead() 
    {
        ani.SetBool("Death", true);
        //碰撞氣關閉
        GetComponent<CapsuleCollider2D>().enabled = false;
        //鋼體 睡著 避免飄移
        rig.Sleep();
        //鋼體 凍結全部
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
        //兩秒後刪除
        Destroy(gameObject, 2); 
    }
    public virtual void Hit(float damage) //加virtual就可以讓子物件使用
    {
        hp -= damage;
        if (hp <= 0) Dead(); 
    }

    #endregion
}
