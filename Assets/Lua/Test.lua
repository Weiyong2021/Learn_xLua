print("---------Test脚本---------")


------------------全局变量-------------------
testNumber=10
testBool=false
testFloat=12.4
testString="fdafdsa"


local testLocal=100



----------------函数--------------
--无参无返回
testFun=function ()
	print("无参无返回")
end


--有参数有返回
testFun2=function (a)
	print("有参数有返回")
	return a+1
end


--多返回
testFun3=function (a)
	print("多返回")
	return a,1,false,"2132123"

end


--变长参数

testFun4=function (a,... )
	print("变长参数")
	print(a)
	arg={...}
	for k,v in pairs(arg) do
		print(k,v)
	end

end

---------------list

testList={1,2,3,4}

testList2={"123","342",true,1,2}


---------Dictionary
testDic={
	["1"]=1,
	["2"]=2,
	["3"]=3,
	["4"]=4
}


testDic2={
	["1"]=21,
	[true]=true,
	[false]=true,
	["123"]=false
}



-----------lua当中的一个自定义类--------
testClass={
	testInt=2,
	testBool=true,
	testFloat=1.2,
	testString="123",
	testFun=function ()
		print("fdafdsa")
	end,
	testInClass={
		testInt2=5
	}
}


-----------lua中定义的类映射到接口------------------
testInterface={
	testInt=2,
	testBool=true,
	testFloat=1.2,
	testString="123",
	testFun=function ()
		print("fdafdsa")
	end

}










