print("-----------在lua中调用C#的类----------------")
----------------1.在lua中调用C#的类非常的简单-----------------
--固定套路

--CS.命名空间.类名

--比如Unity的类       比如GameObject  Transform   等等
--可以这样写    CS.UnityEngine.GameObject  CS.UnityEngine.Transform


---------------------------2.重点：--------------------------
--通过C#中的类 实例化一个对象 lua中没有new 所以我们直接 类名括号就是实例化对象
--默认调用的 相当于就是无参构造 

local obj=CS.UnityEngine.GameObject()

local obj2=CS.UnityEngine.GameObject("韦勇")


--3.
--为了方便使用 并且节约性能 定义全局变量存储 C#中的类
--相当于取了一个别名
--例如下面的

GameObject=CS.UnityEngine.GameObject

local obj3=GameObject("哈哈")


---------------4.类中的静态对象 可以直接使用.来调用-------------
local obj4=CS.UnityEngine.GameObject.Find("哈哈")

-------------5.得到对象中的成员变量  直接对象.即可-----------

print("打印看看是不是找到了场景上的物体的名字为:"..obj4.name)

obj4.transform.position=CS.UnityEngine.Vector3(10,10,10)

print(obj4.transform.position)


--6.-------------如果使用对象中的 成员方法！！！！一定要加:-----------
--因为在lua中，对于函数来说，使用冒号调用的时候，会把自己当做第一个参数转入

obj4.transform:Translate(CS.UnityEngine.Vector3.right)




--------------7.自定义类 使用方法 相同  只是命名空间不同而已-------
local a=CS.TestClass()--这个是TestClass没有命名空间

a:Speak("HelloWorld")

local a2=CS.WeiYong.TestClass2()--这个是TestClass有命名空间，命名空间为WeiYong

a2:Speak("HelloWorld")

------------8.继承了Mono的类---------------------
--在CSharp中我们知道，继承了Mono的类，我们是不能new的
--而在lua中也是没有new出一个类来的的说法
--继承了Mono的类 是不能直接new 

--如果想要实例化一个继承了Mono的类的对象
--我们只能曲线救国

--方法：
--1.先实例化一个空的对象出来
local obj5=CS.UnityEngine.GameObject()
--2.然后给这个对象添加一个具有继承Mono的脚本就可以了
obj5:AddComponent(typeof(CS.Lesson10_LuaCallCSharp))--在这里
--Lesson10_LuaCallCSharp是继承了Mono的脚本


--通过GameObject的 AddComponent添加脚本
--xlua提供了一个重要方法 typeof 可以得到类的Type
--xlua中不支持 无参泛型函数  所以 我们要使用另一个重载



