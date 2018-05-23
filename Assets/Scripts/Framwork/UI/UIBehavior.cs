using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// 007 UI层
/// </summary>
public class UIBehavior : MonoBehaviour
{
    // 把控件的Scripts注册到UIManager
    // 可以直接查找物体 , 把物体本身注册到 UIManager

    private void Awake()
    {
        UIManager.Instance.RegistGameObject(name, gameObject);
    }

    public void AddButtonListener(UnityAction action)
    {
        if (action!=null)
        {
            Button btn = transform.GetComponent<Button>();
            btn.onClick.AddListener(action);
        }
    }
	 
    public void RemoveButtonListener(UnityAction action)
    {
        if (action!=null)
        {
            Button btn = transform.GetComponent<Button>();
            btn.onClick.RemoveListener(action);
        }
    }

    public void AddToggleListener(UnityAction<bool> action)
    {
        if (action != null)
        {
            Toggle tg = transform.GetComponent<Toggle>();
            tg.onValueChanged.AddListener(action);
        }
    }

    public void RemoveToggleListener(UnityAction<bool> action)
    {
        if (action != null)
        {
            Toggle tg = transform.GetComponent<Toggle>();
            tg.onValueChanged.RemoveListener(action);
        }
    }

    public void AddSliderListener(UnityAction<float> action)
    {
        if (action != null)
        {
            Slider tg = transform.GetComponent<Slider>();
            tg.onValueChanged.AddListener(action);
        }
    }


    public void RemoveSliderListener(UnityAction<float> action)
    {
        if (action != null)
        {
            Slider tg = transform.GetComponent<Slider>();
            tg.onValueChanged.RemoveListener(action);
        }
    }

    public void AddInputFieldListener(UnityAction<string> action)
    {
        if (action!=null)
        {
            InputField inputFiled = transform.GetComponent<InputField>();
            inputFiled.onValueChanged.AddListener(action);
        }
    }

}
