print("--------------lua访问C#中的数组------------------------")

local obj=CS.Lesson3()

--lua使用C#的数组相关知识点
--长度  
--C#怎么使用，lua就怎么使用  不能通过lua的语法#去获取长度
print(obj.array.Length)

--访问元素
print(obj.array[0])

--遍历   虽然lua的索引是从1开始的
--但是  数组是C#那边的规则，所以还得按C#的来
for i=0,obj.array.Length-1 do
	print(obj.array[i])
end

--如何在Lua中创建一个数组   在lua中表示数组和List的可以使用表
--  （方法，要理解，在C#中，数组本质是一个类）

--创建C#中的数组，使用静态方法即可
--public static Array CreateInstance(Type elementType, int length);

local array2=CS.System.Array.CreateInstance(typeof(CS.System.Int32),10)
print(array2.Length)

print(array2[0])

print(array2[1])


Debug=CS.UnityEngine.Debug

print("--------------lua调用C#中的List------------------------")

local obj2=CS.Lesson3()

obj2.list:Add(12)

obj2.list:Add(13)

--妈的，在这里有一个坑，就是使用print来打印List的内容打印不出来
--必须对使用Unityengine的Debug.Log()来打印，而且前面必须加
--必要的字符串拼接起来打印才会出来。。。

Debug.Log("第一个数:"..obj2.list[0])


Debug.Log(obj2.list.Count)

--在lua中创建一个List对象
--老版本中的


--新版本  xLua大于2.2.12的话
print("-----------------------------------")
--得到List的类型
local List_Int=CS.System.Collections.Generic.List(CS.System.Int32)

--new一个List
local list3=List_Int()

list3:Add(100)
list3:Add(200)



print("------前面对拼接数据才可以打印出来------"..list3.Count)

Debug.Log("------------------"..list3.Count)

Debug.Log(list3[0])




print("---------Lua调用C#的字典----------")
obj.dic:Add(1,"fdafds")

obj.dic:Add(2,"aaa")

--遍历

for k,v in pairs(obj.dic) do
	print(k,v)
end


--在Lua中创建一个字典对象

local Dic_int_String=CS.System.Collections.Generic.Dictionary(CS.System.Int32,CS.System.String)
local dic2=Dic_int_String()

dic2:Add(1,"haha")
dic2:Add(2,"hhhh")
dic2:Add(5,"weiyong")


--遍历自己创创建的字典
for k,v in pairs(dic2) do
	print(k,v)
end

------------对于键值为整形的，可以这样来获取值-----------
print(dic2[5])



-- ----------------------很坑的一个东西-----------------------------------
local Dic_String_String=CS.System.Collections.Generic.Dictionary(CS.System.String,CS.System.String)
local dic3=Dic_String_String()

dic3:Add("12","fdafdafdsafdasfdsafdsa")
dic3:Add("13","weiyong")

--------------------备注：注意了，这个很坑啊-------------------------
-- --对于字符型串为键值的，在lua中创建的字典  直接通过键中 括号得   得不到，是nil
--print(dic3["12"])


--必须使用固定的写法来获取
print(dic3:get_Item("12"))


















