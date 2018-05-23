using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBase
{
    public override void ProcessEvent(MessageBase msg)
    {
        
    }

    public void RegistSelf(MonoBase mono, params ushort[] msgs)
    {
        NPCManager.Instance.RegistMsg(mono, msgs);
    }

    public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
    {
        NPCManager.Instance.UnRegistMsg(mono, msgs);
    }

    public void SendMsg(MessageBase msg)
    {
        NPCManager.Instance.SendMessage(msg);
    }

    public ushort[] msgId;


    private void OnDestroy()
    {
        if (msgId != null)
        {
            UnRegistSelf(this, msgId);
        }
    }

}
