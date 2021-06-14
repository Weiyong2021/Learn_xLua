print("--------Lua调用的C#的二位数组相关知识点----------")

local obj=CS.Lessons8()

--获取长度
print("行"..obj.array:GetLength(0))
print("列"..obj.array:GetLength(1))


--获取元素

--print(obj.array[0,0])不能这样访问
--print(obj.array[0][0]) 这样也不可以

--使用数组类里面提供的方法
print(obj.array:GetValue(0,0))


--遍历
print("-------------------------------------")
for i=0,obj.array:GetLength(0)-1 do

	for j=0,obj.array:GetLength(1)-1 do
		print("--------"..obj.array:GetValue(i,j))

	end
end

