using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //lua脚本是不能直接启动Unity的，只能从CSharp这边启动
    //然后再反过去执行lua的脚本，然后通过lua的脚本里面的代码来调用CSharp的类
    void Start()
    {
        LuaMgr.GetInstance().Init();

        LuaMgr.GetInstance().DoLuaFile("Main");

    }

    
    void Update()
    {
        
    }
}
