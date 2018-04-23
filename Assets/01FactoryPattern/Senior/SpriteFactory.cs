using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 工厂模式[进阶]
/// 用工厂模式来创建需要的图片
/// </summary>
public class SpriteFactory : MonoBehaviour
{
    public Sprite[] AllSprite;

    private void Start()
    {
        AllSprite = Resources.LoadAll<Sprite>("Number");
    }

    #region 封装
    //public void LoadSprite(string name)
    //{
    //    AllSprite = Resources.LoadAll<Sprite>(name);
    //}

    //public GameObject LoadSprite(int index)
    //{
    //    GameObject obj = new GameObject("tempName");
    //    Image ima = obj.AddComponent<Image>();
    //    ima.sprite = AllSprite[index] as Sprite;
    //    return obj;
    //}

    #endregion


    /// <summary>
    /// 工厂方法
    /// </summary>
    /// <param name="index">AllSprite下标</param>
    /// <returns></returns>
    public GameObject GetImage(int index)
    {
        GameObject obj = new GameObject("tempName");
        Image ima = obj.AddComponent<Image>();
        ima.sprite = AllSprite[index];
        return obj;
    }

    int allIndex = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            GameObject tempObj = GetImage(allIndex);
            tempObj.transform.SetParent(transform);
            tempObj.transform.position = new Vector3(allIndex * 90,220, 0);
            allIndex++;
            if (allIndex == AllSprite.Length)
                allIndex = 0;
        }
    }

}
