using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
public class CallInClass
{
    public int testInt2;

}

public class CallLuaClass
{
    //在这个类中区生命成员变量
    //名字要和lua的那边一样
    //而且必须是公共的   私有和保护没有办法赋值

    //这个自定义中的  变量可以比lua中的少
                    //也可以比lua中的多

    //如果变量比lua中的少了，就会忽略他
    //如果变量比lua中的多了，不会赋值，就会忽略他


    public int testInt;

    public bool testBool;

    public float testFloat;

    public string testString;

    public UnityAction testFun;

    public CallInClass testInClass;


    public void Test()
    {
        Debug.Log("----------");

    }

}

public class Lesson7 : MonoBehaviour
{
    
    void Start()
    {
        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");

        CallLuaClass obj = LuaMgr.GetInstance().Global.Get<CallLuaClass>("testClass");

        print(obj.testString);

        print("---------嵌套---------" + obj.testInClass.testInt2);


        obj.testFun();

        //他还是一个值拷贝。。。
        //更改了 obj的内容，也不会更改lua中的自定义的类的内容

    }

}
