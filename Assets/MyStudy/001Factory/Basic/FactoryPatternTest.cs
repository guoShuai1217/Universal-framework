using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 工厂模式[简单]
/// 主要是用来创造对象
/// </summary>
 
public class Food
{
    public virtual void ShowMe()
    {
        Debug.Log("我吃饭!");
    }
}

public class TomatoFood : Food
{
    public override void ShowMe()
    {
        base.ShowMe();
        Debug.Log("我吃西红柿饭!");
    }
}

public class EggFood : Food
{
    public override void ShowMe()
    {
        base.ShowMe();
        Debug.Log("我吃蛋炒饭!");
    }
}


public class FactoryPatternTest  
{
     public Food ShowFactory(string name)
    {
        switch (name)
        {
            case "Egg":
                return new EggFood();
            case "Tomato":
                return new TomatoFood();           
        }
        return null;
    }
	 
}

public class Main
{
    public void MainShow()
    {
        FactoryPatternTest factoryPatternTest = new FactoryPatternTest();
        EggFood eggFood =  factoryPatternTest.ShowFactory("Egg") as EggFood;
        eggFood.ShowMe();
    }
}







