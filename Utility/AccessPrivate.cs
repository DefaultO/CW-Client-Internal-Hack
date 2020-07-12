using System;
using System.Reflection;

internal static class PrivateAccess
{
	internal static T GetPrivateField<T>(this object obj, string name)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
		Type type = obj.GetType();
		FieldInfo field = type.GetField(name, bindingAttr);
		return (T)((object)field.GetValue(obj));
	}

	internal static void SetPrivateField(this object obj, string name, object value)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
		Type type = obj.GetType();
		FieldInfo field = type.GetField(name, bindingAttr);
		field.SetValue(obj, value);
	}

	internal static void CallPrivateMethod(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
		Type type = obj.GetType();
		MethodInfo method = type.GetMethod(name, bindingAttr);
		method.Invoke(obj, param);
	}
}
