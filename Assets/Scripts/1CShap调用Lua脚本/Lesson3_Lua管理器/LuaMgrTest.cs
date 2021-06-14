using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 使用来测试lua管理器是否写成功了
/// </summary>
public class LuaMgrTest : MonoBehaviour
{
    
    void Start()
    {
        //初始化lua解析器
        LuaMgr.GetInstance().Init();
        //执行脚本
        // LuaMgr.GetInstance().DoString("require('Main1')");
        // LuaMgr.GetInstance().DoString("require('Main2')");
        LuaMgr.GetInstance().DoLuaFile("Main2");



        //重点：lua的脚本，我们最终都会打包到ab包中
        //所以我们最终都会加载ab包，然后再区加载ab包中的lua脚本资源
        //最后再去执行lua脚本

        //ab包中如果要加载文本，后缀还是有一定的
        //的限制的，就是不能够识别.lua
        //所以在打包的时候，还是要把后缀名改为.txt




    }


    void Update()
    {
        
    }
}
