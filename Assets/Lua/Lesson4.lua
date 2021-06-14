print("--------Lua调用的C#的拓展方法相关知识点----------")

Lessons4=CS.Lessons4

--使用静态方法
Lessons4.Eat()


--成员方法  实例化出来调用
local obj=Lessons4()

obj:Speak("韦勇哈哈")

--使用拓展方法和成员方法一样的

-- //如果想要在Lua中使用拓展方法，一定要在工具类前面加上特性
-- //建议 关于Lua中要使用的类，都加上该特性，可以提升性能
-- //如果不加该特性，除了拓展方法对应的类
-- //其他的类使用 都不会报错
-- //但是lua是通过发射的机制区调用C#的类的  效率低
obj:Move()
