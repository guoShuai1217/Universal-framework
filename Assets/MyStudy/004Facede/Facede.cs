using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 门面模式
/// 把若干个没有任何逻辑关系的东西,放到一起,组成一个功能
/// </summary>
public class Facede : MonoBehaviour
{
    public Button m_OpenBtn;
    public Button m_CloseBtn;
    public Image m_Img;

    private void Start()
    {
        m_OpenBtn.onClick.AddListener(OnClickOpen);
        m_CloseBtn.onClick.AddListener(OnClickClose);
    }

    private void OnClickOpen()
    {
        m_Img.gameObject.SetActive(true);
    }

    private void OnClickClose()
    {
        m_Img.gameObject.SetActive(false);
    }
}
