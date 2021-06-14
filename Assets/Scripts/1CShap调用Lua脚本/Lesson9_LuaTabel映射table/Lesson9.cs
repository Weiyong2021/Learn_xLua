using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;


public class Lesson9 : MonoBehaviour
{
    
    void Start()
    {
        #region LuaTabel映射table

        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");


        //不建议使用LuaTable和LuaFunction  会产生垃圾  而且效率低
        //而且是引用操作
        LuaTable luaTable = LuaMgr.GetInstance().Global.Get<LuaTable>("testInterface");
        int a=luaTable.Get<int>("testInt");

        print(a);

        string b = luaTable.Get<string>("testString");

        print(b);


        UnityAction action = luaTable.Get<UnityAction>("testFun");

        action();


        //
        print("---------------测试是否是引用拷贝的----------------------");
        luaTable.Set("testInt",2000);
        LuaTable luaTable2 = LuaMgr.GetInstance().Global.Get<LuaTable>("testInterface");
        int a2 = luaTable2.Get<int>("testInt");

        print(a2);



        //要记得销毁
        luaTable.Dispose();
        luaTable2.Dispose();


        #endregion
    }


}
