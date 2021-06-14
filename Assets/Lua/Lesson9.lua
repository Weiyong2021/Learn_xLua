print("--------Lua使用CSharp的null和nil----------")

--往场景对象上添加一个脚本  如果存在就不加
--如果不存在就添加
--Rigidbody
GameObject=CS.UnityEngine.GameObject

Rigidbody=CS.UnityEngine.Rigidbody

Debug=CS.UnityEngine.Debug


local obj=GameObject("测试脚本")

local rig=obj:GetComponent(typeof(Rigidbody))

print(rig)
Debug.Log(rig)




--判断空
-- if rig==nil then 
-- 	rig=obj:AddComponent(typeof(Rigidbody))
-- else 
-- 	print("rig is not nil")
-- end

-----由于在lua中，nil和C#的null无法比较，所以引入了新的知识点
--引入了Equals()函数，但是如果rig是null的话也不能直接调用Equals来进行比较

-- if rig:Equals(nil) then
-- 	rig=obj:AddComponent(typeof(Rigidbody))
-- end

--在一次引入另外的一种方法，就是在Main.lua写一个全局函数
--用来判断对象是不是nil的

-- if IsNull(rig) then
-- 	rig=obj:AddComponent(typeof(Rigidbody))
-- else
-- 	print("rig is not null")
-- end


-------------这个是通过C#那边的拓展方法来实现的IsNull() 
-------------前提示rig是UnityEngine.Object
if rig:IsNull() then 
	rig=obj:AddComponent(typeof(Rigidbody))
else
	print("rig is not null")
end








