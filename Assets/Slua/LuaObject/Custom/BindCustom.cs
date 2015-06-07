using System;
namespace SLua {
	[LuaBinder(3)]
	public class BindCustom {
		public static void Bind(IntPtr l) {
			Lua_Custom.reg(l);
			Lua_Deleg.reg(l);
			Lua_foostruct.reg(l);
			Lua_SLuaTest.reg(l);
			Lua_HelloWorld.reg(l);
		}
	}
}
