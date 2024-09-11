using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject battleGo;//ս��������Ϸ����
    //luna����
    public int lunaHP;//�������ֵ
    public int lunaCurrentHP;//Luna�ĵ�ǰ����ֵ
    public int lunaMP;//�������
    public int lunaCurrentMP;//luna�ĵ�ǰ����
    //Monster����
    public int monsterCurrentHP;//���ﵱǰѪ��


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
    /// LunaѪ���ı�
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
    /// Luna�����ı�
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
    /// �Ƿ����ʹ����ؼ���
    /// </summary>
    /// <param name="value">���ܺķ�����</param>
    /// <returns></returns>
    public bool CanUsePlayerMP(int value)
    {
        return lunaCurrentMP >= value;
    }
    /// <summary>
    /// MonsterѪ���ı�
    /// </summary>
    /// <param name="value"></param>
    public int AddOrDecreaseMonsterHP(int value)
    {
        monsterCurrentHP += value;
        return monsterCurrentHP;
    }
}
