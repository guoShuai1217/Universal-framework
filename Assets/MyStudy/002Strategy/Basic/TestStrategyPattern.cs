using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 策略模式[基础]
/// 传入一个参数 -> 策略模式 -> 得到不同的答案的同一个API
/// </summary>

public class StrategyBase
{   
    public virtual double Caculate()
    {
        Debug.Log("计算工资!");
        return -1;
    }
}

/// <summary>
/// 个人缴税
/// </summary>
public class PersonalStrategy : StrategyBase
{
    double fa;
    public PersonalStrategy(double tempTex)
    {
        fa = tempTex;
    }
    public override double Caculate()
    {
        double temp = fa;
        fa *= 0.18f;
        Debug.Log("月薪" + temp + "个人交税为:" + fa);
        return fa;
    }
}

/// <summary>
/// 公司交税
/// </summary>
public class CompanyStrategy : StrategyBase
{
    double myTex;
    public CompanyStrategy(double fa)
    {
        myTex = fa;
    }
    public override double Caculate()
    {
        double tm = myTex;
        myTex *= 0.2f;
        Debug.Log("月入"+ tm + "公司交税为:" + myTex);
        return myTex;
    }
}

/// <summary>
/// 策略工厂
/// </summary>
public  class CaculateStrategy
{

    public static double Caculate(StrategyBase stra)
    {
        double tm = stra.Caculate();
        return tm;
    }

}

/// <summary>
/// 测试
/// </summary>
public class TestStrategyPattern : MonoBehaviour {

    public InputField input;
    public Text showTxt;
    public Button sureBtn;
    public Toggle personToggle;
	 
	void Start () {

        personToggle.isOn = true;
        sureBtn.onClick.AddListener(OnClickSureBtn);


        PersonalStrategy personalStrategy = new PersonalStrategy(8000);
        CaculateStrategy.Caculate(personalStrategy);

       
    }
	
    void OnClickSureBtn()
    {
        if (input.text == null || input.text == "")
        {
            showTxt.text = "您没有输入工资,请重新输入!";
            return;
        }
            
        double money = double.Parse(input.text);       
        if (money <= 6000)
        {
            if (personToggle.isOn)
                showTxt.text = "月薪" + money + ", 穷逼,不用缴税";
            else
                showTxt.text = "月入" + money + ", 开JB公司";

        }
        else
        {
            if (personToggle.isOn)
            {
                PersonalStrategy personalStrategy = new PersonalStrategy(money);
                double tempMon = CaculateStrategy.Caculate(personalStrategy);
                showTxt.text = "月薪" + money + ", 个人需要缴税为:" + tempMon;
            }
            else
            {
                CompanyStrategy companyStrategy = new CompanyStrategy(money);
                double tem = CaculateStrategy.Caculate(companyStrategy);
                showTxt.text = "月入" + money + ", 公司需要缴税为:" + tem;
            }
            
        }
    }


}
