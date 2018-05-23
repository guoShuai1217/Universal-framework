using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : UIBase
{

    private void Start()
    {
        msgId = new ushort[] { };

        RegistSelf(this, msgId);

        // 用空间换取时间 ,不用去Find
        UIManager.Instance.GetGameObject("Button").GetComponent<UIBehavior>().AddButtonListener(OnButtonClick);
        Image ima =  UIManager.Instance.GetGameObject("Image").GetComponent<Image>();
    }

    public void OnButtonClick()
    {

    }


}
