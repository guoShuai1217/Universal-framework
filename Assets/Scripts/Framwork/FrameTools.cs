using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 002
/// 框架工具
/// </summary>

// 192.168.0
public enum ManagerID
{
    GameManager = 0,
    UIManager = FrameTools. msgSpan, // 3000
    AudioManager = FrameTools.msgSpan * 2, // 6000
    NPCManager = FrameTools.msgSpan * 3, //9000
    CharacterManager = FrameTools.msgSpan * 4,
    AssetManager = FrameTools.msgSpan * 5,
    NetManager = FrameTools.msgSpan * 6,
}

public class FrameTools
{
    public const int msgSpan = 3000; // 每个manager 管理3000条消息

 
}
