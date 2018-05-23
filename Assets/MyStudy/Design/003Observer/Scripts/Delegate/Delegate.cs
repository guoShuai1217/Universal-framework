using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 代理模式
/// 调用层
/// 工人完成工作之后,主动报告完成了工作,不用每时每刻都去检测
/// 每时每刻检测的是工人脚本,这个代理脚本就没什么事干
/// </summary>
public class Delegate : MonoBehaviour
{
    // 单个动画
    PlayAnim pa;

    // 多个动画 
    PlayAnim[] paArr = new PlayAnim[100];

    private void Start()
    {
        pa = new PlayAnim(PlayParticle);
        pa.PlayAnimation();

        #region 多个动画
        for (int i = 0; i < paArr.Length; i++)
        {
            paArr[i] = new PlayAnim(PlayParticle);
            paArr[i].PlayAnimation();
        }
        #endregion
    }

    private void PlayParticle()
    {
        Debug.Log("播放粒子特效...");
    }

}

// 代理模式和观察者模式的区别 :
// 代理模式 把调用层和实现层分开;
// 调用者不用每帧都检测,都交给实现层去做,做完告诉调用者做完了就行,实现了调用者的自我管理
// 如果是播放多个动画的话,可以明显看出代理模式的好处 : 多个实现层,在调用层一个for循环搞定,容易管理;