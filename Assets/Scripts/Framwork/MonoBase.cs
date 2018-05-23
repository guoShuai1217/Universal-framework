using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 003
/// 扩展 MonoBehaviour 类
/// </summary>
public abstract class MonoBase : MonoBehaviour
{

    public abstract void ProcessEvent(MessageBase msg);
	 
}
