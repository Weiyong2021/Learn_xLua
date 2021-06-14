using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;
/// <summary>
/// Lua管理器
/// 提供lua解析器
/// 用来保证lua解析器的唯一性
/// 
/// </summary>
public class LuaMgr : BaseManager<LuaMgr>
{
    //执行lua语言的函数
    //释放垃圾
    //销毁
    //重定向文件
    private LuaEnv luaEnv;


    /// <summary>
    /// 得到lua中的_G  lua中所有的 全局变量都在_G中
    /// </summary>
    public LuaTable Global
    {
        get
        {
            if (luaEnv != null)
                return luaEnv.Global;
            else
                return null;

        }
    }

    /// <summary>
    /// 初始化解析器
    /// </summary>
    public void Init()
    {
        if (luaEnv != null) return;
        luaEnv = new LuaEnv();

        //加载lua脚本  文件重定向
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomLoaderAB);


    }




    //重点：lua的脚本，我们最终都会打包到ab包中
    //所以我们最终都会加载ab包，然后再区加载ab包中的lua脚本资源
    //最后再去执行lua脚本

    //ab包中如果要加载文本，后缀还是有一定的
    //的限制的，就是不能够识别.lua
    //所以在打包的时候，还是要把后缀名改为.txt

    private byte[]  MyCustomLoaderAB(ref string filepath)
    {

        #region 普通写法
        //Debug.Log("进入了AB包加载重定向函数");
        //string path = Application.streamingAssetsPath + "/" + "lua";
        ////加载ab包
        //AssetBundle ab = AssetBundle.LoadFromFile(path);

        ////加载lua文件
        //TextAsset tx = ab.LoadAsset<TextAsset>(filepath + ".lua");

        //return tx.bytes;

        #endregion

        #region 使用AB包管理器加载
        TextAsset lua= ABMgr.GetInstance().LoadRes<TextAsset>("lua", filepath + ".lua");
        if(lua==null)
        {
            Debug.Log("文件重定向失败。。。。。。。" + filepath);
            return null;
        }
        else
        {
            return lua.bytes;
        }


        #endregion


    }


    // public delegate byte[] CustomLoader(ref string filepath);
    //这个函数是自动执行的
    private byte[] MyCustomLoader(ref string filepath)
    {
        //filepath是 require执行的lua脚本文件名

        //Debug.Log(filepath);//打印的是文件名（lua的文件名）
        //通过里面的函数逻辑去加载lua文件

        //拼接一个lua文件所在的路径
        //Application.dataPath  是得到Asset文件夹下的文件
        string path = Application.dataPath + "/Lua/" + filepath + ".lua";
        //Debug.Log(path);

        //判断文件是否存在
        if (File.Exists(path))
        {   //存在
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;

        }
        else//不存在
        {
            Debug.Log("文件重定向失败" + filepath);
            return null;

        }

    }


    /// <summary>
    /// 传入lua文件名，执行lua脚本
    /// </summary>
    /// <param name="flieName"></param>
    public void DoLuaFile(string flieName)
    {
        string str = string.Format("require('{0}')", flieName);

        this.DoString(str);
    }

    /// <summary>
    /// 执行lua语言
    /// </summary>
    /// <param name="str"></param>
    public void DoString(string str)
    {
        if(luaEnv==null)
        {
            Debug.Log("解析器为空");
            return;
        }
        luaEnv.DoString(str);

    }

    //释放lua垃圾
    public void Tick()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为空");
            return;
        }
        luaEnv.Tick();
    }

    //销毁解析器
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.Log("解析器为空");
            return;
        }
        luaEnv.Dispose();
        luaEnv = null;
    }

}
