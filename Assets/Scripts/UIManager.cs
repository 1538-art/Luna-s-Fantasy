using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Image hpMaskImage;
    public Image mpMaskImage;
    private float originalSize;//Ѫ��ԭʼ���
    public GameObject battlePanelGo;

    void Awake()
    {
        Instance = this;
        originalSize = hpMaskImage.rectTransform.rect.width;
        SetHPValue(1); 
    }
    /// <summary>
    /// Ѫ��UI�����ʾ
    /// </summary>
    /// <param name="fillPercent">���ٷֱ�</param>
    public void SetHPValue(float fillPercent)
    {
        hpMaskImage.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,fillPercent*originalSize);
    }
    /// <summary>
    /// ����UI�����ʾ
    /// </summary>
    /// <param name="fillPercent">���ٷֱ�</param>
    public void SetMPValue(float fillPercent)
    {
        mpMaskImage.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal, fillPercent * originalSize);
    }

    public void ShowOrHideBattlePanel(bool show)
    {
        battlePanelGo.SetActive(show);
    }
}
