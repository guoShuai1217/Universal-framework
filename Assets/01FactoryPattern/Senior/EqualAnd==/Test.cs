using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 介绍Equal和 == 的区别
/// </summary>
public class Test : MonoBehaviour
{

    //1. == 比较的是内容是否一样 
    //2. Equal 比较的是变量里的地址是否相同
    //3. 除了string类型之外 , string类型是一个特殊的引用类型,它的Equals就是代表内容

    #region 特殊情况
  
    private void Start()
    {
         // 只要是new出来的, 就是堆里面的
         // 只要是声明的 , 就是栈里面的

         // 栈 1001            // 堆 3001
        string tempA = new string(new char[] { 'h', 'l' });
         // 栈 1002            // 堆 3002
        string tempB = new string(new char[] { 'h', 'l' });
        Debug.Log(tempA == tempB); // true    == 比较的是内容是否一样 
        Debug.Log(tempA.Equals(tempB)); // true  Equal 比较的是变量里的地址是否相同,除了string类型外

        // 栈        1001    
        object temC = tempA;
        // 栈          1002
        object temD = tempB;
        Debug.Log(temC == temD); // false
        Debug.Log(temC.Equals(temD)); // true
    }
    #endregion


    #region 一般情况[按引用传递类型]

    public void Awake()
    {
        Vector vertor = new Vector("");
    }


    #endregion


}

public class Vector
{
    string name;
    public Vector(string str)
    {
        this.name = str;
    }
}