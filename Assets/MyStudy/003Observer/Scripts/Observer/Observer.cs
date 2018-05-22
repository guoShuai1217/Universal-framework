using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 观察者模式
/// 观察者每时每刻都在去询问是否完成了工作 [效率比较低...推荐使用代理模式,工作完成后自己主动报告,不浪费CPU]
/// 例 : 释放技能到一半的时候需要放特效
/// </summary>
public class Observer : MonoBehaviour
{
    private  Animation anim;
    private float animCD = 5; // 动画播放时间
    private float timer = 0;

    private void PlayAnimation()
    {
        anim.Play();
    }
	 
    private bool IsFinish()
    {
        return anim.isPlaying;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))     
            PlayAnimation();

        // 每帧都在观察动画是否播放到一半了...
        if (!IsFinish())
        {
            timer += Time.deltaTime;
            if (timer > animCD/2.0)
            {
                 // 到达预定时间了 , 观察者又去做其他的事情(播放离子特效)
                Debug.Log("播放粒子特效...");
            }
        }

    }


}
