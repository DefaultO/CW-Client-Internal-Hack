using System;
using System.Reflection;

// Token: 0x02000002 RID: 2
internal static class PublicAccess
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	internal static T PAGetPublicField<T>(this object obj, string name)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		Type type = obj.GetType();
		FieldInfo field = type.GetField(name, bindingAttr);
		return (T)((object)field.GetValue(obj));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
	internal static void PASetPublicField(this object obj, string name, object value)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		Type type = obj.GetType();
		FieldInfo field = type.GetField(name, bindingAttr);
		field.SetValue(obj, value);
	}

	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	internal static T PAGetPublicProperty<T>(this object obj, string name)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		Type type = obj.GetType();
		PropertyInfo property = type.GetProperty(name, bindingAttr);
		return (T)((object)property.GetValue(obj));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
	internal static void PASetPublicProperty(this object obj, string name, object value)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		Type type = obj.GetType();
		PropertyInfo property = type.GetProperty(name, bindingAttr);
		property.SetValue(obj, value);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020B0 File Offset: 0x000002B0
	internal static void PACallPublicMethod(this object obj, string name, params object[] param)
	{
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		Type type = obj.GetType();
		MethodInfo method = type.GetMethod(name, bindingAttr);
		method.Invoke(obj, param);
	}
}