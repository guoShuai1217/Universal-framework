using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/// <summary>
/// 004
/// 管理基类
/// </summary>


/// <summary>
/// 链表类 
/// </summary>
public class EventNode
{
    // 当前数据
    public MonoBase data;

    // 指向下一个节点
    public EventNode next;

    public EventNode(MonoBase data)
    {
        this.data = data;
        this.next = null;
    }
}


public class ManagerBase : MonoBase
{
     // 存储注册的消息 (key 是 msgId, value是 EventNode)
    public Dictionary<ushort, EventNode> eventTreeDic = new Dictionary<ushort, EventNode>();

 

    /// <summary>
    /// 注册脚本
    /// </summary>
    /// <param name="mono">要注册的脚本</param>
    /// <param name="msgs">每个脚本可以注册多个message</param>
    public void RegistMsg(MonoBase mono,params ushort[] msgs)
    {
        for (int i = 0; i < msgs.Length; i++)
        {
            EventNode tempNode = new EventNode(mono);
            RegistMsg(msgs[i], tempNode);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">msgId</param>
    /// <param name="eventNode">节点链表</param>
    public void RegistMsg(ushort id ,EventNode eventNode)
    {
        // 链表里面没有这个消息ID
        if (!eventTreeDic.ContainsKey(id))
        {
            eventTreeDic.Add(id, eventNode);
        }else
        {
            EventNode en = eventTreeDic[id];
            while(en.next != null) // 一直找到最后一个节点
            {
                en = en.next;
            }
            en.next = eventNode; // 找到最后一节,挂上新加的这个 eventNode
        }
    }

    #region 注销

    /// <summary>
    /// 注销一个脚本的若干个消息
    /// </summary>
    /// <param name="mono"></param>
    /// <param name="msgs"></param>
    public void UnRegistMsg(MonoBase mono, params ushort[] msgs)
    {
        for (int i = 0; i < msgs.Length; i++)
        {
            UnRegistMsg(msgs[i], mono);
        }
    }





    // 注销 :
    // 1. 在最后面 : 直接释放
    // 2. 在中间 : 进一步判断后释放
    // 3. 在头部 :
    /// <summary>
    /// 注销一个消息链表
    /// </summary>
    /// <param name="id"></param>
    /// <param name="node"></param>
    public void  UnRegistMsg(ushort id,MonoBase node)
    {
        if (!eventTreeDic.ContainsKey(id))
        {
            Debug.LogError("字典里不包含此Id"+id);
            return;
        }
        else
        {
            EventNode tempNode = eventTreeDic[id];
             // 去掉头部,包含两种情况
            if (tempNode.data.Equals(node))
            {
                EventNode head = tempNode;
                // 已经存在这个消息
                if (head.next != null) //后面多几个点
                {
                    head.data = tempNode.next.data;
                    head.next = tempNode.next.next;
                }
                else //只有一个节点的情况
                {
                    eventTreeDic.Remove(id);
                }
            }
            else // 去掉尾部和中间的节点
            {
                while (tempNode.next != null && tempNode.next.data !=null)
                {
                    tempNode = tempNode.next;
                }
                //跳出循环表示 已经找到了该节点
                // 没有引用,会自动释放
                if (tempNode.next.next !=null) //去掉中间的
                {
                    tempNode.next = tempNode.next.next;
                }
                else // 去掉尾部的
                {
                    tempNode.next = null;
                }
            }
        }


    }


    public override void ProcessEvent(MessageBase msg)
    {
        if (!eventTreeDic.ContainsKey(msg.msgId))
        {
            Debug.LogError("字典里没有该信息" + msg);
            Debug.LogError("Msg Manager ==" + msg.GetManagerId());
            return;
        }
        else
        {
            EventNode tempNode = eventTreeDic[msg.msgId];

            do
            {
                 // 策略模式
                tempNode.data.ProcessEvent(msg);
            }
            while (tempNode!=null);


        }
    }

    #endregion







}
