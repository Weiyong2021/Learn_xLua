using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

/// <summary>
/// 1.注意：接口是不能有成员变量的
/// 所以要映射lua中的自定义的类中的成员变量的话
/// 就要用到属性
/// 
/// 1.要在接口的上面添加特性，然后生成代码
/// 
/// </summary>
/// 

[CSharpCallLua]
public interface ICSharpCallLua
{ 
    int testInt
    {
        get;
        set;

    }

    bool testBool
    {
        get;
        set;

    }

    float testFloat
    {
        get;
        set;

    }


    string testString
    {
        get;
        set;

    }

    UnityAction testFun
    {
        get;set;
    }

}


public class Lesson8 : MonoBehaviour
{
    
    void Start()
    {

        #region lua中定义的类映射到接口

        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");

        ICSharpCallLua cSharp = LuaMgr.GetInstance().Global.Get<ICSharpCallLua>("testInterface");


        print(cSharp.testBool);
        print(cSharp.testFloat);
        print(cSharp.testInt);

        print(cSharp.testString);

        cSharp.testFun();


        //2.对于接口来讲，他是引用了lua中的类的，所以是值引用
        //当我们修改外部的接口的属性的时候，就是直接的修改了lua内部
        //中的类的成员变量

        //假如修改了testInt=2000
        cSharp.testInt = 2000;


        //再一次获取和打印的时候，testInt就是2000了，二不再是原来的值
        ICSharpCallLua cSharp2 = LuaMgr.GetInstance().Global.Get<ICSharpCallLua>("testInterface");

        print("修改之后，再一次获取得到的值"+cSharp2.testInt);


        #endregion

    }

}
