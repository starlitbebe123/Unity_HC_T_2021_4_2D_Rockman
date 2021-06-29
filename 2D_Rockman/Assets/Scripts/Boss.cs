using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物件導向程式設計原則：繼承與多型
//繼承語法：類別後面加上冒號與藥劑成的類別名稱
//1.擁有類別的成員 - 欄位、事件、方法
//2. 可以複寫繼承類別(父類別)的成員
//複寫條件
//1. 父類別要複寫的成員必須添加關鍵字 virtual
//2. 父類別要複寫的成員修飾詞必須是 public(誰都可以存取)、protected(只允許子類別存取)
//3. 子類別必須使用關鍵字 override 複寫
public class Boss : Enemy
{
    [Header("進入第二階段的血量")]
    public float secondHp = 300;
    [Header("魔王攻擊：第二階段特效")]
    public ParticleSystem psAttackSecond;
    [Header("魔王攻擊：第二階段粒子")]
    public float attackSecond = 10;

    ///<summary>
    ///魔王狀態
    /// </summary>
    public StateBoss stateBoss;


    public override void Hit(float damage)//把Enemy裡的Hit搬過來
    {
        base.Hit(damage); // 指父類別原本的程式區塊

        //判斷血量並切換到第二階段
        if (hp <= secondHp)
        {
            radiusAttack = 7;
            stateBoss = StateBoss.Second;
        }
    }

    protected override void Dead()
    {
        base.Dead();
        StartCoroutine(player.GetComponent<Player>().GameOver("You Win!!")); 
    }
    protected override void Start() 
    {
        base.Start();

        psAttackSecond.GetComponent<ParticleSystemData>().attack = attackSecond; 
    
    
    }
    protected override void AttackState()
    {
        switch (stateBoss)
        {
            case StateBoss.First:
                base.AttackState();
                break;
            case StateBoss.Second:
                cdTimer = 0;
                ani.SetTrigger("Attack");
                psAttackSecond.transform.position = transform.position + transform.right * 3 + transform.up * -1.5f;
                psAttackSecond.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 180, 0); 
                psAttackSecond.Play(); 
                break; 
        }
    }
}

//列舉(下拉選單)
//語法：修飾詞 列舉 列舉名稱{選項1, 選項2......}
///<summary>
///魔王狀態：第一階段、第二階段
///</summary>

public enum StateBoss
{
    First, Second
}
