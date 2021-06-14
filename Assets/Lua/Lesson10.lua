print("---------Lua和系统类以及委托相互使用--------")
GameObject=CS.UnityEngine.GameObject

UI=CS.UnityEngine.UI

local slider=GameObject.Find("Slider")

print(slider)

local SliderScript=slider:GetComponent(typeof(UI.Slider))

print(SliderScript)

SliderScript.onValueChanged:AddListener(function (f)
	print(f)
	
end)
