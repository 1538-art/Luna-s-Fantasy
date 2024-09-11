using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject battleGo;//战斗场景游戏物体
    //luna属性
    public int lunaHP;//最大生命值
    public int lunaCurrentHP;//Luna的当前生命值
    public int lunaMP;//最大蓝量
    public int lunaCurrentMP;//luna的当前蓝量
    //Monster属性
    public int monsterCurrentHP;//怪物当前血量


    private void Awake()
    {
        Instance = this;
        lunaHP = lunaCurrentHP = 100;
        lunaMP = lunaCurrentMP = 100;
        monsterCurrentHP = 50;
    }

    //public void ChangeHeath(int amount)
    //{
    //    lunaCurrentHP = Mathf.Clamp(lunaCurrentHP + amount, 0, lunaHP);
    //    Debug.Log(lunaCurrentHP + "/" + lunaHP);
    //}

    public void EnterOrExitBattle(bool enter=true)
    {
        UIManager.Instance.ShowOrHideBattlePanel(enter);
        battleGo.SetActive(enter);
    }
    /// <summary>
    /// Luna血量改变
    /// </summary>
    /// <param name="value"></param>
    public void AddOrDecreaseHP(int value)
    {
        lunaCurrentHP += value;
        if (lunaCurrentHP>=lunaHP)
        {
            lunaCurrentHP = lunaHP;
        }
        if (lunaCurrentHP<=0)
        {
            lunaCurrentHP = 0;
        }
        UIManager.Instance.SetHPValue((float)lunaCurrentHP/lunaHP);
    }
    /// <summary>
    /// Luna蓝量改变
    /// </summary>
    /// <param name="value"></param>
    public void AddOrDecreaseMP(int value)
    {
        lunaCurrentMP += value;
        if (lunaCurrentMP >= lunaMP)
        {
            lunaCurrentMP = lunaMP;
        }
        if (lunaCurrentMP <= 0)
        {
            lunaCurrentMP = 0;
        }
        UIManager.Instance.SetMPValue((float)lunaCurrentMP / lunaMP);
    }
    /// <summary>
    /// 是否可以使用相关技能
    /// </summary>
    /// <param name="value">技能耗费蓝量</param>
    /// <returns></returns>
    public bool CanUsePlayerMP(int value)
    {
        return lunaCurrentMP >= value;
    }
    /// <summary>
    /// Monster血量改变
    /// </summary>
    /// <param name="value"></param>
    public int AddOrDecreaseMonsterHP(int value)
    {
        monsterCurrentHP += value;
        return monsterCurrentHP;
    }
}
