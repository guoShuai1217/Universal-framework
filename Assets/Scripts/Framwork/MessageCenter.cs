using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 006 消息中心
/// </summary>
public class MessageCenter : MonoBehaviour
{
    public static MessageCenter Instance;

    private void Awake()
    {
        Instance = this;
    }

   
    public void SendToMsg(MessageBase tmpMsg)
    {
        AnalysisMsg(tmpMsg);
    }

    private void AnalysisMsg(MessageBase tmpMsg)
    {
        ManagerID tempId = tmpMsg.GetManagerId();

        switch (tempId)
        {
            case ManagerID.GameManager:
                break;
            case ManagerID.UIManager:
                break;
            case ManagerID.AudioManager:
                break;
            case ManagerID.NPCManager:
                break;
            case ManagerID.CharacterManager:
                break;
            case ManagerID.AssetManager:
                break;
            case ManagerID.NetManager:
                break;
            default:
                break;
        }
    }

}
