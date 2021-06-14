using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;//1.要使用xlua框架，就先引用命名空间
/// <summary>
/// lua解析器
/// </summary>

public class Lesson1_LuaEnv : MonoBehaviour
{
    
    void Start()
    {
        #region Lua解析器    
        //lua解析器   能够让我们在Unity中执行lua
        //一般情况下，保持他的唯一性
        LuaEnv env = new LuaEnv();

        //执行lua语言
        //一般不会这么区执行lua的语言
        env.DoString("print('Hello World')");
        //通常的我们都是区执行lua脚本
        //lua知识点：多脚本的执行require
        //默认寻找脚本的 路径在 Resources下 而且
        //因为在这里  估计是通过Resources.load去加载
        //脚本的 但是Resources步支持.lua为后缀名
        //所以lua脚本后面要加.txt

        env.DoString("require('Main')");


        //帮助我们清理lua中我们没有手动释放的对象  垃圾回收
        //帧更新中定时执行    或者切换场景时执行
        env.Tick();

        //销毁lua的解析器
        env.Dispose();



        #endregion

    }


}
