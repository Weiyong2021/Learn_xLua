using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// C#中获取lua的全局变量
/// </summary>
public class Lesson4 : MonoBehaviour
{
    
    void Start()
    {
        #region 在C#中访问lua中的全局变量
        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");


        //使用lua解析器中的luaenv中的Global属性
        //1.获取lua中的全局变量使用Get<>()函数
        int a = LuaMgr.GetInstance().Global.Get<int>("testNumber");
        print("testNumber:"+a);

        bool b = LuaMgr.GetInstance().Global.Get<bool>("testBool");

        print("testBool:" + b);

        float c = LuaMgr.GetInstance().Global.Get<float>("testFloat");
        print("testFloat:" + c);

        string d= LuaMgr.GetInstance().Global.Get<string>("testString");
        print("testString:" + d);


        //2.修改lua中的全局变量的函数
        //Set();
        LuaMgr.GetInstance().Global.Set("testString", "haha");

        string d2 = LuaMgr.GetInstance().Global.Get<string>("testString");
        print("testString:" + d2);


        #endregion



        #region 访问lua中的本地变量
        //注意：在C#中，是不能通过Global.Get()区获取lua中的本地变量的
        //执行下面这一句的代码会报错。。。

        int a2 = LuaMgr.GetInstance().Global.Get<int>("testLocal");
        print(a2);

        #endregion

    }


}
