using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 中介者模式
/// 中介者模式包装了一系列对象相互作用的方式，使得这些对象不必相互明显作用。从而使它们可以松散耦合。
/// 当某些对象之间的作用发生改变时，不会立即影响其他的一些对象之间的作用。保证这些作用可以彼此独立的变化。
/// 
/// 当对象之间的交互操作很多且每个对象的行为操作都依赖彼此时，为防止在修改一个对象的行为时，同时涉及很多其他对象的行为，可使用中介者模式。
/// 例 : 小怪 和 主角掉血
/// </summary>


public abstract class RoleBase : MonoBehaviour
{
    protected float m_Blood { get; set; }
    public abstract void ReduceBlood();
}

public class Monster : RoleBase
{
    private void Start()
    {
        m_Blood = 500f;
    }
    public override void ReduceBlood()
    {
        m_Blood -= 20;
    }
}

public class Player : RoleBase
{
    private void Start()
    {
        m_Blood = 200f;
    }
    public override void ReduceBlood()
    {
        m_Blood -= 15;
    }
}

/// <summary>
/// 迪米特法则 : 一个类尽可能少的知道另一个类 (不和陌生人说话)
/// </summary>
public class MediatorFactory 
{
    /// <summary>
    /// 当玩家位于 小怪 左右3米,或者前方5米的时候,小怪去攻击玩家
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="attacked"></param>
    public static void Blood(RoleBase player , RoleBase monster)
    {
         // 小怪到玩家的向量
        Vector3 dis = player.transform.position - monster.transform.position;

        // 1. 先判断左右边

         // 求出cosA 的值 (a.b = |a|.|b|.cosA)[令|a|,|b|的模都为0,求出cosA]
        float tempAngleRight = Vector3.Cross(dis.normalized, monster.transform.right).y;
        // 如果 tempAngle > 0 , 则玩家位于第一象限 , 玩家在小怪右边
        if (tempAngleRight >= 0)
        {
            // dis 在小怪右边的投影的模长
           float pro = Vector3.Project(dis, monster.transform.right).magnitude;
            if (pro>3)
            {
                Debug.Log("小怪开始追击玩家...");
            }
        }
        else  // 如果 tempAngle < 0 , 则玩家位于第二象限 , 玩家在小怪左边
        {
            // dis 在小怪右边的投影的模长
            float pro = Vector3.Project(dis, -monster.transform.right).magnitude;
            if (pro > 3)
            {
                Debug.Log("小怪开始追击玩家...");
            }
        }

        //3.判断前面
        // 求夹角
        float tempAngleForward = Mathf.Acos(Vector3.Dot(monster.transform.forward,dis.normalized)) * Mathf.Rad2Deg;
        // 如果 tempAngle > 0 , 则玩家位于小怪前方 ; tempAngle < 0 , 则玩家位于小怪后方
        if (tempAngleForward >=0 && tempAngleForward <= 120)
        {
            // dis 在小怪右边的投影的模长
            float pro = Vector3.Project(dis, monster.transform.forward).magnitude;
            if (pro > 5)
            {
                Debug.Log("小怪开始追击玩家...");
            }
        }

        Attack(dis, monster.transform.right, 3);

    }

    /// <summary>
    /// 封装AI追击方法
    /// </summary>
    /// <param name="dis">玩家位置 - 小怪位置</param>
    /// <param name="nor">小怪的方向(左右前)的模</param>
    /// <param name="distance">玩家在小怪左右前方向上的投影,距离小怪的距离</param>
    private static void Attack(Vector3 dis,Vector3 nor,float distance)
    {
        float tempAngleForward = Vector3.Dot(dis.normalized, nor);
        // 如果 tempAngle > 0 , 则玩家可能位于第二或者第三象限,还需要进一步判断
        if (tempAngleForward >= 0)
        {
            // dis 在小怪右边的投影的模长
            float pro = Vector3.Project(dis, nor).magnitude;
            if (pro > distance)
            {
                Debug.Log("小怪开始追击玩家...");
            }
        }
    }

}

public class Mediator : MonoBehaviour
{
   private Player m_Player; //攻击者
   private Monster m_Monster; // 被攻击者
   
    private void Update()
    {
        MediatorFactory.Blood(m_Player, m_Monster);
    }
}
