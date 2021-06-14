print("--------Lua调用的C#的函数重载相关知识点----------")

local obj =CS.Lessons6()


--虽然Lua自己不支持重载函数
--但是Lua支持调用C#中的重载函数
print(obj:Calc())
print(obj:Calc(10,20))


--lua虽然支持调用C#中的重载函数
--但是因为lua中的数值类型，只有number
--对C#中多精度的重载函数支持不好  傻傻分不清
--在使用时  可能出现意想不到的结果
print(obj:Calc(10))

print(obj:Calc(12.3))


---------------------解决重载函数含糊的问题---------------
--xlua提供了解决的方案  反射机制
--这种方法只是做了解  尽量别用

--Type是反射的关键类
--得到指定函数的相关信息

print("-----------解决重载函数含糊的问题--------------")

local m1=typeof(CS.Lessons6):GetMethod("Calc",{typeof(CS.System.Int32)})
local m2=typeof(CS.Lessons6):GetMethod("Calc",{typeof(CS.System.Single)})

--通过xlua提供的一个方法  把他转为lua函数来使用
--一般我们转一次   然后重复使用

local f1=xlua.tofunction(m1)
local f2=xlua.tofunction(m2)

--成员方法   第一个参数传调用者对象

--静态方法   不用传

--在这里obj是他们的调用者

print("f1(obj,10)-----"..f1(obj,10))
print("f2(obj,10.9)------"..f2(obj,10.9))








