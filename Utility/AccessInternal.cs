
using System;
using System.Reflection;

internal static class InternalAccess
{
	internal static object GetPublicField(this object internalobj, string name)
	{
		return internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj);
	}

	internal static T GetPublicField<T>(this object internalobj, string name)
	{
		return (T)((object)internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj));
	}

	internal static T GetPublicProperty<T>(this object internalobj, string name)
	{
		return (T)((object)internalobj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public).GetValue(internalobj, null));
	}

	internal static T GetPublicProperty<T>(this Type type, string name)
	{
		return (T)((object)type.GetProperty(name, BindingFlags.Static | BindingFlags.Public).GetValue(null, null));
	}

	internal static void SetPublicField(this object internalobj, string name, object value)
	{
		internalobj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public).SetValue(internalobj, value);
	}

	internal static void SetPublicProperty(this object internalobj, string name, object value)
	{
		internalobj.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public).SetValue(internalobj, value, null);
	}

	internal static object CallPublicConstructor(this Type type, int constructorindex, params object[] parameters)
	{
		return type.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[constructorindex].Invoke(parameters);
	}

	internal static object CallPublicConstructor2(this Type type, params object[] parameters)
	{
		ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[]
		{
			typeof(string)
		}, null);
		return constructor.Invoke(parameters);
	}

	internal static object CallPublicConstructor3(this Type type, params object[] parameters)
	{
		return Activator.CreateInstance(type, new object[]
		{
			BindingFlags.Instance | BindingFlags.Public,
			null,
			parameters
		});
	}

	internal static object CallPublicMethod(this object internalobj, string name, params object[] parameters)
	{
		return internalobj.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.Public).Invoke(internalobj, parameters);
	}

	internal static object CallPublicMethod(this Type type, string name, params object[] parameters)
	{
		return type.GetMethod(name, BindingFlags.Static | BindingFlags.Public).Invoke(null, parameters);
	}

	internal static object CallPublicMethod<T>(this Type type, string name, params object[] parameters)
	{
		return (T)((object)type.GetMethod(name, BindingFlags.Static | BindingFlags.Public).Invoke(null, parameters));
	}
}
