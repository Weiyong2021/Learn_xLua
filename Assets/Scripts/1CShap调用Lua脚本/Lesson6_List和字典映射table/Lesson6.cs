using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// List和字典映射table
/// </summary>

public class Lesson6 : MonoBehaviour
{
    
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        //
        print("---------------------");
        List<int> list = LuaMgr.GetInstance().Global.Get<List<int>>("testList");
        for(int i=0;i<list.Count;++i)
        {
            print(list[i]);

        }

        //看看是不是引用拷贝
        list[0] = 100;
        List<int> list2 = LuaMgr.GetInstance().Global.Get<List<int>>("testList");
        print(list2[0]);
        //经过验证，发现他是值拷贝


        print("***********************");
        //不指定类型，就可以使用object来存储
        List<object> list3 = LuaMgr.GetInstance().Global.Get<List<object>>("testList2");
        for(int i=0;i<list3.Count;++i)
        {
            print(list3[i]);

        }


        print("--------------字典------------");
        Dictionary<string, int> dic = LuaMgr.GetInstance().Global.Get<Dictionary<string, int>>("testDic");

        foreach(KeyValuePair<string ,int> keyValuePair in dic)
        {
            print(keyValuePair.Key + "------" + keyValuePair.Value);

        }

        print("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

        Dictionary<object, object> dic2 = LuaMgr.GetInstance().Global.Get<Dictionary<object, object>>("testDic2");

        foreach (KeyValuePair<object, object> keyValuePair in dic2)
        {
            print(keyValuePair.Key + "------" + keyValuePair.Value);

        }

    }


    void Update()
    {
        
    }
}
