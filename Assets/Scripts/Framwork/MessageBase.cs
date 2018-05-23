using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 001
/// 消息基类
/// </summary>
public class MessageBase
{

    //功能:
    // 1. 存储对应的注册进来的msg
    // 2. msg来了以后,找到对应的脚本()
    // Dictionary 只能满足一个脚本 对应一个msg , 如果存在多个脚本都对应一个 msg ????
    // 使用链表




    // ushort 65535个消息,占两个字节
    // int -2,147,483,648 到 2,147,483,647 占4个字节, 比较浪费
    // 开发的时候注意节省性能
    public ushort msgId;

    /// <summary>
    /// 获取对应的 ManagerID
    /// </summary>
    /// <returns></returns>
    public ManagerID GetManagerId()
    {
         // 3003/3000 =1
        int tempId = msgId / FrameTools.msgSpan;
        return (ManagerID)(tempId * FrameTools.msgSpan);
    }
	 

    public MessageBase(ushort msgId)
    {
       this.msgId = msgId;
    }






}
