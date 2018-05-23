using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : ManagerBase
{
    public static NPCManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SendMessage(MessageBase msg)
    {
        // ManagerBase 本模块自己处理
        if (msg.GetManagerId() == ManagerID.NPCManager)
        {
            ProcessEvent(msg);
        }
        else // 如果不是本模块里的,交给MessageCenter处理
        {
            MessageCenter.Instance.SendToMsg(msg);
        }
    }

    // 规定开发方式, 空间换时间
    private Dictionary<string, GameObject> sonMemberDic = new Dictionary<string, GameObject>();

    public void RegistGameObject(string name, GameObject obj)
    {
        if (!sonMemberDic.ContainsKey(name))
        {
            sonMemberDic.Add(name, obj);
        }

    }

    public void UnRegistGameObject(string name)
    {
        if (sonMemberDic.ContainsKey(name))
        {
            sonMemberDic.Remove(name);
        }
    }

    /// <summary>
    /// 外部接口(外面调用这个API即可)
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string name)
    {
        if (!sonMemberDic.ContainsKey(name))
        {
            return sonMemberDic[name];
        }

        return null;
    }

}
