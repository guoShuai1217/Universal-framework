using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 建造者模式
/// 自上而下,每一个环节提供不同的功能,分工明确
/// 加载AssetBundle
/// </summary>
 

// 内存层
public class LoadAssetBundle
{
    AssetBundle assetBundle;

    public LoadAssetBundle(AssetBundle ab)
    {
        assetBundle = ab;
    }
    /// <summary>
    /// 加载单个资源
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    public object LoadAsset(string bundleName)
    {
        if (bundleName != null)
        {
          return  assetBundle.LoadAsset(bundleName);
        }   
        return null;
    }

    /// <summary>
    /// 加载子物体
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    public object[] LoadAssetWithSubAssets(string bundleName)
    {
        if (bundleName != null)
        {
            return assetBundle.LoadAssetWithSubAssets(bundleName);
        }
        return null;
    }
}

/// <summary>
/// 从硬盘中Load AssetBundle
/// </summary>
public class Loader
{
    LoadAssetBundle lab;
    string bundleName;

    public Loader(string name)
    {
        bundleName = name;
    }

   public  IEnumerator load(string path)
    {
        WWW www = new WWW(path);
        while (!www.isDone)
        {
            yield return www;
        }

        lab = new LoadAssetBundle(www.assetBundle);      
    }

    public object LoadAsset(LoadAssetBundle lab,string bundleName)
    {
        if (lab!=null)
        {
           return lab.LoadAsset(bundleName);
        }

        return null;
    }

    public object LoadAssetWithSubAssets(LoadAssetBundle lab, string bundleName)
    {
        if (lab != null)
        {
            return lab.LoadAssetWithSubAssets(bundleName);
        }

        return null;
    }

}

public class Builder : MonoBehaviour
{
    private void Start()
    {
        Loader ld = new Loader("test.u3d");
        StartCoroutine(ld.load("path"));
    }

}
