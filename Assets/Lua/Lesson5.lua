print("--------Lua调用的C#的ref和out的相关知识点----------")


Lessons5=CS.Lessons5

local obj=Lessons5()

--ref参数  会以多返回值的形式返回给lua
--如果函数存在返回值，那么第一个值就是该返回值
--之后的返回值就是ref的结果，从做到右一一对应
--ref需要传入一个默认值作为参数  占位置


local a,b,c=obj:RefFun(1,0,0,0)

print(a)
print(b)
print(c)



--out参数  会以多返回值的形式返回给lua
--如果函数存在返回值，那么第一个值就是该返回值
--之后的返回值就是out的结果，从做到右一一对应
--out的参数  不需要传入一个默认值作为参数  不需要占位置

local a,b,c=obj:OutFun(20,30)

print(a)
print(b)
print(c)


--混合使用时，综合上面的规则
--ref需要占位   out不用传
print("----------------------------------")
local a,b,c=obj:RefOutFun(20,300)

print(a)
print(b)
print(c)



