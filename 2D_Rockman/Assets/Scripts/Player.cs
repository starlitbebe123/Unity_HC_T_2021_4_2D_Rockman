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
    public bool onGround = false;

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

    AudioSource aud;
    Rigidbody2D rig;
    Animator ani;
    #endregion

    #region 方法

    private void Movement()
    {

    }
    /// <summary>
    /// 跳越
    /// </summary>
    private void Jump()
    {

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
}
#endregion