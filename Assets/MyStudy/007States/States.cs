using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 状态模式
/// </summary>
/// 


public abstract class FSMState
{
    private byte m_StateId;

    public virtual void OnBeforeEnter()
    {

    }

    public virtual void CopyState()
    {

    }

    public abstract void OnEnter();

    public virtual void Update()
    {

    }

    public virtual void OnLeave()
    {

    }

}

public class FSMManager
{
    private FSMState[] fsmArr;
    private byte curAdd;
    public byte curStateId;

    public FSMManager(byte stateNumber)
    {

    }






}

public class States : MonoBehaviour
{

	 
}
