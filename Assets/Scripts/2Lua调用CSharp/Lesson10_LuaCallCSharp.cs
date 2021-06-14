using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLua;

#region 第一次课 自定义类

public class TestClass
{
    public void Speak(string str)
    {
        Debug.Log("TestClass1:" + str);

    }
}

namespace WeiYong
{
    public class TestClass2
    {
        public void Speak(string str)
        {
            Debug.Log("TestClass2:" + str);

        }
    }
}

#endregion



#region 第二次课 枚举


public enum E_MyEnum
{
    Idle,
    Move,
    Atk

}

#endregion


#region 第三次课 数组  List 字典

public class Lesson3
{
    public int[] array = new int[] { 1, 2, 3, 4, 5 };
    public List<int> list = new List<int>();
    public Dictionary<int, string> dic = new Dictionary<int, string>();

}

#endregion


#region 第四次课  拓展方法
//如果想要在Lua中使用拓展方法，一定要在工具类前面加上特性
//建议 关于Lua中要使用的类，都加上该特性，可以提升性能
//如果不加该特性，除了拓展方法对应的类
//其他的类使用 都不会报错
//但是lua是通过发射的机制区调用C#的类的  效率低


[LuaCallCSharp]
public static class Tools
{
    //Lessons4的拓展方法
    public static void Move(this Lessons4 obj)
    {
        Debug.Log(obj.name + "移动");
    }

}
public class Lessons4
{
    public string name = "韦勇";

    public void Speak(string str)
    {
        Debug.Log(str);

    }


    public static void Eat()
    {
        Debug.Log("吃东西");

    }
}




#endregion


#region 第五次课 ref和out的内容
public class Lessons5
{
    public int RefFun(int a,ref int b,ref int c,int d)
    {
        b = a + d;
        c = a - d;
        return 100;
    }

    public int OutFun(int a, out int b, out int c, int d)
    {
        b = a;
        c = d;
        return 200;


    }

    public int RefOutFun(int a,ref int b,out int c)
    {
        b = a * 10;
        c = a * 20;
        return 300;

    }
}

#endregion


#region 第六次课 函数重载

public class Lessons6
{
    public int Calc()
    {
        return 100;
    }

    public int Calc(int a,int b)
    {
        return a + b;

    }

    public int Calc(int a)
    {
        return a;

    }


    public float Calc(float a)
    {
        return a;

    }


}

#endregion


#region 第七次课 Lua调用C#中的委托和事件
public class Lessons7
{
    public UnityAction action;


    public event UnityAction eventAction;


    public void DoEvnet()
    {
        //eventAction?.Invoke();
        if(eventAction==null)
        {
            Debug.Log("eventAction is null");

        }
        else
        {
            eventAction();
        }

    }

    public void ClaerEvent()
    {
        eventAction = null;

    }

}

#endregion


#region 第八次课  二位数组遍历
public class Lessons8
{
    public int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

    public Lessons8()
    {
        //得到二维数组的长度
        //得到行数
        //array.GetLength(0);

        //得到列数
        //array.GetLength(1);

        //访问其中的元素
        //array[0,0]

    }
}




#endregion


#region 第九次课  判空
//为object拓展一个方法
[LuaCallCSharp]
public static class Lessons9
{ 
    //为object拓展一个方法   主要是lua中没有办法比较nil和null
    public static bool IsNull(this UnityEngine.Object obj)
    {
        return obj == null;
    }

}

#endregion

#region 第十次课 系统类型加特性
public static class Lesson10
{
    [CSharpCallLua]
    public static List<System.Type> csharpCallList = new List<System.Type>()
    {
        typeof(UnityAction<float>)//后面可以一直添加上去
    };


    [LuaCallCSharp]
    public static List<System.Type> luaCallCSharpList = new List<System.Type>()
    { 
        typeof(GameObject),
        typeof(Rigidbody)
    
    };

}


#endregion


#region 第十二次课  调用泛型方法
public class Lessons12
{

    public class TestFather
    {

    }

    public class TestChild:TestFather
    {

    }


    public interface ITest { }




    public void TestFun1<T>(T a,T b) where T:TestFather
    {
        Debug.Log("有参数有约束的泛型方法");

    }


    public void TestFun2<T>(T a )
    {
        Debug.Log("有参数，没有约束的");

    }


    public void TestFun3<T>() where T:TestFather
    {
        Debug.Log("有约束但是没有参数的泛型方法");

    }


    public void TestFun4<T>(T a) where T: ITest
    {
        Debug.Log("有参数有约束的，但是约束是接口");

    }


}


#endregion



public class Lesson10_LuaCallCSharp : MonoBehaviour
{
    void Start()
    {
       
    }
    void Update()
    {
        
    }
}
