using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

//无参数无返回的委托
public delegate void CustomCall();


//有参数有返回的委托
//由于有参数有返回的委托在xlua中没有自己实现，xlua就会不知道
//所以要在他的上面加上一特性[CSharpCallLua]     然后再生成代码
[CSharpCallLua]
public delegate int CustomCall2(int a);


[CSharpCallLua]
public delegate int CustomCall3(int a,out int a1,out bool a2,out string a3);

[CSharpCallLua]
public delegate int CustomCall4(int a, ref int a1, ref bool a2, ref string a3);


[CSharpCallLua]                            //变长参数的类型是根据实际情况来定的  最保险的是用object
public delegate void CustomCall5(string a, params object[] args);

public class Lesson5 : MonoBehaviour
{
    
    void Start()
    {
        #region 在C#中调用lua的函数

        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //----------------------无参数无返回------------------------------

        //使用自己定义的委托来接受lua中的无参无返回的函数
        CustomCall callBack = LuaMgr.GetInstance().Global.Get<CustomCall>("testFun");
        callBack();

        //使用Unity自带的委托来接受lua中的无参数无返回的函数
        UnityAction action= LuaMgr.GetInstance().Global.Get<UnityAction>("testFun");
        action();

        //使用C#提供的委托来接受lua中的无参数无返回的函数
        Action action1 = LuaMgr.GetInstance().Global.Get<Action>("testFun");
        action1();

        //使用xlua中的LuaFunction来接受lua中的无参数无返回函数
        //这种不建议使用   
        LuaFunction luaFunction = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun");
        luaFunction.Call();




        //----------------------有参数有返回------------------------------

        //使用自己定义的委托来接受lua中的无参无返回的函数
        CustomCall2 callBack2 = LuaMgr.GetInstance().Global.Get<CustomCall2>("testFun2");
        callBack2(100);

        //使用C#提供的委托来接受lua中的有参数有返回的函数
        Func<int,int> func= LuaMgr.GetInstance().Global.Get<Func<int,int>>("testFun2");
        func(100);


      

        ////使用xlua中的LuaFunction来接受lua中的有参数有返回函数
        ////这种不建议使用       会产生垃圾
        LuaFunction luaFunction2 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun2");
        luaFunction2.Call(100);

        print("使用xlua中的LuaFunction来接受lua中的有参数有返回函数" + luaFunction2.Call(100)[0]);



        //--------------------------多返回值-----------------------------
        CustomCall3 customCall3 = LuaMgr.GetInstance().Global.Get<CustomCall3>("testFun3");
        int a1;
        bool a2;
        string a3;

        customCall3(100,out a1, out a2, out a3);

        print(customCall3(100,out a1, out a2, out a3));
        print(a1);
        print(a2);
        print(a3);


        CustomCall4 customCall4= LuaMgr.GetInstance().Global.Get<CustomCall4>("testFun3");
        int a11=0;
        bool a22=false;
        string a33="";

        customCall4(200, ref a11, ref a22, ref a33);
        int aaa = 100000;


        print("-----------------------------------------------");
        LuaFunction luaFunction1 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun3");
        object[] s= luaFunction1.Call(300);
        foreach (var item in s)
        {
            print(item);

        }



        //------------------------变长参数----------------------------------
        CustomCall5 customCall5 = LuaMgr.GetInstance().Global.Get<CustomCall5>("testFun4");

        customCall5("haha", 232, false, "fdafdsafdsafdsa", 123.3, 343.9, true);




        LuaFunction luaFunction3 = LuaMgr.GetInstance().Global.Get<LuaFunction>("testFun4");
        luaFunction3.Call(12,true,false);





        #endregion


    }


}
