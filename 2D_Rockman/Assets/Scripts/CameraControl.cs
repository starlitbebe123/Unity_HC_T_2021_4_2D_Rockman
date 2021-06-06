using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region 欄位
    public Transform player;
    public float speed = 30;

    //邊界
    public Vector2 limtX = new Vector2(0.9f, 125);
    public Vector2 limtY = new Vector2(0, 0.65f);
    
    #endregion

    #region 方法
    private void Track() 
    {
        Vector3 vCam = transform.position; //攝影機本身座標
        Vector3 vPla = player.position;  //玩家座標

        //利用差值讓攝影機座標朝玩家座標移動
        vCam = Vector3.Lerp(vCam, vPla, 0.5f * speed * Time.deltaTime);
        //將攝影機z軸恢復成預設的-10
        vCam.z = -10; 
        //夾住X與Y軸
        vCam.x = Mathf.Clamp(vCam.x, limtX.x, limtX.y);
        vCam.y = Mathf.Clamp(vCam.y, limtY.x, limtY.y); 
        //更新攝影機座標(這行要放在最後)
        transform.position = vCam;
    }
    #endregion

    #region 事件
    //延遲更新事件
    //在Update之後執行
    //官方建議這樣做
    private void LateUpdate()
    {
        Track(); 
    }
    #endregion
}
