using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 策略模式[基础]
/// 传入一个参数 -> 策略模式 -> 得到不同的答案的同一个API
/// </summary>

public class StrategyBase
{
    float fa;
    public StrategyBase (float tempTex)
    {
        this.fa = tempTex;
    }
    public virtual void Caculate()
    {
        fa *= 0.12f;
        Debug.Log(fa);
    }
}

public class PersonalStrategy : StrategyBase
{
    float fa;
    public PersonalStrategy(float tempTex)
    {
        fa = tempTex;
    }
    public override void Caculate()
    {
        fa *= 0.18f;
        Debug.Log("PersonalStrategy" + fa);
    }
}

public class CompanyStrategy : StrategyBase
{
    float myTex;
    public CompanyStrategy(float fa)
    {
        myTex = fa;
    }
    public override void Caculate()
    {
        myTex *= 0.2f;
        Debug.Log("CompanyStrategy" + myTex);
    }
}


public class CaculateStrategy
{

    public void Caculate()
    {
        stra.Caculate();
    }

}

public class TestStrategyPattern : MonoBehaviour {

	// Use this for initialization
	void Start () {

        CaculateStrategy caculateStrategy = new CaculateStrategy();
        PersonalStrategy personalStrategy = new PersonalStrategy(20000);
        caculateStrategy.Caculate();
        CompanyStrategy companyStrategy = new CompanyStrategy(1000000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
