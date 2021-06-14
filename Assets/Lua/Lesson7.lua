print("--------Lua调用的C#的委托和事件相关知识点----------")

local obj=CS.Lessons7()
--委托是用来装函数的
--使用C#中的委托 就是用来装lua函数的
print("---------------在lua中调用C#的委托--------------------")
testFun=function ()
	print("无参数无返回的函数")
end


--Lua中没有复合运算符 不能+=
--如果第一次往委托中加函数 因为是nil 不能直接+
--所以第一次 要先等=   
obj.action=testFun


--或者判断空
if obj.action==nil then
	obj.action=testFun
else
	obj.action=obj.action+testFun
end

--执行委托
obj.action()


print("*********开始减函数***********")
obj.action= obj.action - testFun
obj.action= obj.action- testFun

if obj.action==nil then
	print("已经为nil了")
else
	obj.action()
end



print("*********清空***********")
--清空所有存储的函数
obj.action= nil
--清空过后得先等
obj.action= testFun
--调用
obj.action()


-----------------Lua调用C# 事件相关知识点----------------------
print("*********Lua调用C# 事件相关知识点***********")
local fun2 = function()
	print("事件加的函数")
end
print("*********事件加函数***********")
--事件加减函数  和 委托非常不一样
--lua中使用C#事件 加函数 
--有点类似使用成员方法 冒号事件名("+", 函数变量)
obj:eventAction("+",fun2)

--最好最好不要这样写     这样写在减事件的时候不知得到怎么减
obj:eventAction("+", function()
	print("事件加的匿名函数")
end)


------------执行事件
obj:DoEvnet()



print("*********事件减函数***********")
obj:eventAction("-", fun2)
obj:DoEvnet()


print("*********事件清空***********")
--清事件 不能直接设空
obj:ClaerEvent()--通过在C#那边包裹一层函数来实现清空
obj:DoEvnet()


