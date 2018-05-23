using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 实现层(这个脚本是干活的)
/// 播放粒子特效委托
/// </summary>
public delegate void PlayParticle();

public class PlayAnim : MonoBehaviour
{
    private Animation m_anim;
    private float m_animCD = 5f;
    private float m_timer = 0;

    PlayParticle playParticle; // 声明一个代理

    /// <summary>
    /// 构造函数,给代理赋值
    /// </summary>
    /// <param name="pp"></param>
    public PlayAnim(PlayParticle pp)
    {
        this.playParticle = pp;
    }

    public void PlayAnimation()
    {
        m_anim.Play();
    }

    private bool IsPlayFinish()
    {
        return m_anim.isPlaying;
    }

    private void Update()
    {
        
        if (!IsPlayFinish())
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_animCD/2.0)
            {
                 // 检测工作完成了,就去调用这个代理
                if (playParticle != null)
                    playParticle();
            }
        }

    }

}
