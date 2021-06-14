print("主lua脚本启动")

--Unity中写lua执行
--xlua帮我们处理
--只要是执行lua脚本，都会执行自动的进入我们的重定向函数中找文件

function IsNull(obj)
	if obj==nil or obj:Equals(nil) then
		return true
	else
		return false
	end
end

--现在把require("Test")注释掉，这是在讲解CSarpCallLua的时候使用的
--require("Test")


--这个是讲解LuaCallCSharp使用的脚本

--require("LuaCallCSharpClass")


--require("LuaCallCSharpEnum")

--require("LuaCallCSharpArray")


--require("Lesson4")


--require("Lesson5")


--require("Lesson6")

--require("Lesson7")


--require("Lesson8")


--require("Lesson9")


--require("Lesson10")

require("Lesson12")




















