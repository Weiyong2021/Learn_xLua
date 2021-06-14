using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class Lesson2_Loader : MonoBehaviour
{

    void Start()
    {
        LuaEnv env = new LuaEnv();
        //xlua提供一个路径重定向的方法
        //允许我们自己定义  加载lua文件的规则
        //当我们执行lua语言的 require时
        //相当于执行一个lua脚本
        //他就会执行我们自己定义传入的这个函数
        env.AddLoader(MyCustomLoader);
        env.DoString("require('Main1')");

        //env.DoString("require('a')");

    }


    // public delegate byte[] CustomLoader(ref string filepath);
    //这个函数是自动执行的
    private  byte[] MyCustomLoader(ref string filepath)
    {
        //filepath是 require执行的lua脚本文件名

        //Debug.Log(filepath);//打印的是文件名（lua的文件名）
        //通过里面的函数逻辑去加载lua文件

        //拼接一个lua文件所在的路径
        //Application.dataPath  是得到Asset文件夹下的文件
        string path = Application.dataPath + "/Lua/" + filepath+".lua";
        Debug.Log(path);

        //判断文件是否存在
        if(File.Exists(path))
        {   //存在
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;

        }
        else//不存在
        {
            Debug.Log("文件重定向失败" + filepath);
            return null;

        }


        //--------------遗留问题，我们最终是去ab包中加载lua的文件的-----------
        //下一节讲解




    }



    void Update()
    {
        
    }
}
