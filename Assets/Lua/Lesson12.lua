print("---------Lua使用CSharp泛型函数----------")

local obj=CS.Lessons12()

local child=CS.Lessons12.TestFather()

local father=CS.Lessons12.TestChild()

--lua中支持有约束的有参数的泛型方法
obj:TestFun1(father)

obj:TestFun1(child)

--lua不支持没有约束的泛型函数

--obj:TestFun2(100)


--lua不支持有约束  但是没有参数的泛型函数
--obj:TestFun3()


--lua不支持非class的约束的泛型函数

--obj:TestFun4()



---------------------------------------------
--让上面不支持的泛型函数  变得在lua中都能使用
--了解就可以了，使用有一定的限制。。。
--Mono打包  这种方式支持使用
--i12cpp打包  如果泛型参数是引用类型才可以使用
--i12cpp打包  如果泛型参数是值类型  除非c#那边已经调用过了
--同类型的泛型参数 lua中才能被使用


--得到通用的函数
local testFun2=xlua.get_generic_method(CS.Lessons12,"TestFun2")
--设置泛型类型在使用
local testFun_R=testFun2(CS.System.Int32)

--调用
testFun_R(obj,1)








