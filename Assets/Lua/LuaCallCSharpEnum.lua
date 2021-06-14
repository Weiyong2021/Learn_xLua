print("-----------在lua中调用C#的枚举----------------")
--枚举调用

--调用Unity当中的枚举
--枚举的调用规则和调用类的规则是一样的
--CS.命名空间.枚举名.枚举成员
--也一样支持取别名

GameObject=CS.UnityEngine.GameObject

PrimitiveType=CS.UnityEngine.PrimitiveType


-- GameObject.CreatePrimitive(PrimitiveType.Cube);

local a=GameObject.CreatePrimitive(PrimitiveType.Cube)


--自己定义的枚举   使用方法一样  只是要注意命名空间
E_MyEnum=CS.E_MyEnum

local c=E_MyEnum.Idle

print(c)


--通过__CastFrom()函数来转枚举
--枚举转换相关
--数值转枚举

local aa=E_MyEnum.__CastFrom(1)
print(aa)

--字符串转枚举

local bb=E_MyEnum.__CastFrom("Atk")

print(bb)






