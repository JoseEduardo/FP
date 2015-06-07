﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_AreaEffector2D : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D o;
			o=new UnityEngine.AreaEffector2D();
			pushValue(l,o);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceAngle(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.forceAngle);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forceAngle(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.forceAngle=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useGlobalAngle(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.useGlobalAngle);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useGlobalAngle(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useGlobalAngle=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceMagnitude(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.forceMagnitude);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forceMagnitude(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.forceMagnitude=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceVariation(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.forceVariation);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forceVariation(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.forceVariation=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_drag(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.drag);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_drag(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.drag=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_angularDrag(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushValue(l,self.angularDrag);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_angularDrag(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.angularDrag=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forceTarget(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			pushEnum(l,(int)self.forceTarget);
			return 1;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forceTarget(IntPtr l) {
		try {
			UnityEngine.AreaEffector2D self=(UnityEngine.AreaEffector2D)checkSelf(l);
			UnityEngine.EffectorSelection2D v;
			checkEnum(l,2,out v);
			self.forceTarget=v;
			return 0;
		}
		catch(Exception e) {
			LuaDLL.luaL_error(l, e.ToString());
			return 0;
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.AreaEffector2D");
		addMember(l,"forceAngle",get_forceAngle,set_forceAngle,true);
		addMember(l,"useGlobalAngle",get_useGlobalAngle,set_useGlobalAngle,true);
		addMember(l,"forceMagnitude",get_forceMagnitude,set_forceMagnitude,true);
		addMember(l,"forceVariation",get_forceVariation,set_forceVariation,true);
		addMember(l,"drag",get_drag,set_drag,true);
		addMember(l,"angularDrag",get_angularDrag,set_angularDrag,true);
		addMember(l,"forceTarget",get_forceTarget,set_forceTarget,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.AreaEffector2D),typeof(UnityEngine.Effector2D));
	}
}
