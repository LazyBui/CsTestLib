using System;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that the type of a specified object matches the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType() != typeof(TType)) throw exception ?? new AssertionException($"Type '{value.GetType().FullName}' was unexpected, expected type '{typeof(TType).FullName}'");
		}

		/// <summary>
		/// Asserts that the type of a specified object matches the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The expected type of the object.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType() != type) throw exception ?? new AssertionException($"Type '{value.GetType().FullName}' was unexpected, expected type '{type.FullName}'");
		}

		/// <summary>
		/// Asserts that the type of a specified object does not match the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType() == typeof(TType)) throw exception ?? new AssertionException("Type is the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object does not match the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that is not permitted.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType() == type) throw exception ?? new AssertionException("Type is the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is assignable from the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsAssignableFromType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (!value.GetType().IsAssignableFrom(typeof(TType))) throw exception ?? new AssertionException("Type is not assignable from the specificed type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is assignable from the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that should be assignable to <paramref name="value" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsAssignableFromType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!value.GetType().IsAssignableFrom(type)) throw exception ?? new AssertionException("Type is not assignable from the specificed type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not assignable from the specified type.
		/// </summary>
		/// <typeparam name="TType">The type to check.</typeparam>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotAssignableFromType<TType>(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.GetType().IsAssignableFrom(typeof(TType))) throw exception ?? new AssertionException("Type is assignable from the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not assignable from the specified type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="type">The type of the object that should not be assignable to <paramref name="value" />.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotAssignableFromType(object value, Type type, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (value.GetType().IsAssignableFrom(type)) throw exception ?? new AssertionException("Type is assignable from the specified type");
		}

		/// <summary>
		/// Asserts that the type of a specified object is an array type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsArrayType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsArrayType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is an array type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsArrayType<TValue>(AssertionException exception = null) {
			IsArrayType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is an array type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsArrayType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsArray) throw exception ?? new AssertionException($"Expected type to be an array type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not an array type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotArrayType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotArrayType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not an array type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotArrayType<TValue>(AssertionException exception = null) {
			IsNotArrayType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not an array type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotArrayType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsArray) throw exception ?? new AssertionException($"Expected type to be a non-array type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is an enum type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsEnumType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsEnumType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is an enum type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsEnumType<TValue>(AssertionException exception = null) {
			IsEnumType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is an enum type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsEnumType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsEnum) throw exception ?? new AssertionException($"Expected type to be an enum type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not an enum type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotEnumType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotEnumType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not an enum type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotEnumType<TValue>(AssertionException exception = null) {
			IsNotEnumType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not an enum type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotEnumType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsEnum) throw exception ?? new AssertionException($"Expected type to be a non-enum type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is a struct type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsStructType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsStructType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a struct type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsStructType<TValue>(AssertionException exception = null) {
			IsStructType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a struct type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsStructType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsValueType) throw exception ?? new AssertionException($"Expected type to be a struct type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not a struct type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotStructType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotStructType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a struct type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotStructType<TValue>(AssertionException exception = null) {
			IsNotStructType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a struct type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotStructType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsValueType) throw exception ?? new AssertionException($"Expected type to be a non-struct type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is a class type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsClassType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsClassType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a class type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsClassType<TValue>(AssertionException exception = null) {
			IsClassType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a class type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsClassType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsClass) throw exception ?? new AssertionException($"Expected type to be a class type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not a class type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotClassType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotClassType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a class type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotClassType<TValue>(AssertionException exception = null) {
			IsNotClassType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a class type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotClassType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsClass) throw exception ?? new AssertionException($"Expected type to be a non-class type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is a sealed type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsSealedType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsSealedType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a sealed type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsSealedType<TValue>(AssertionException exception = null) {
			IsSealedType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a sealed type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsSealedType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsSealed) throw exception ?? new AssertionException($"Expected type to be a sealed type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not a sealed type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotSealedType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotSealedType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a sealed type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotSealedType<TValue>(AssertionException exception = null) {
			IsNotSealedType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a sealed type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotSealedType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsSealed) throw exception ?? new AssertionException($"Expected type to be a non-sealed type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is a generic type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsGenericType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsGenericType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a generic type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsGenericType<TValue>(AssertionException exception = null) {
			IsGenericType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is a generic type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsGenericType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsGenericType) throw exception ?? new AssertionException($"Expected type to be a generic type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the type of a specified object is not a generic type.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotGenericType(object value, AssertionException exception = null) {
			if (value == null) throw new ArgumentNullException(nameof(value));
			IsNotGenericType(value.GetType(), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a generic type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotGenericType<TValue>(AssertionException exception = null) {
			IsNotGenericType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not a generic type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotGenericType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsGenericType) throw exception ?? new AssertionException($"Expected type to be a non-generic type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the specified type is an interface type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsInterfaceType<TValue>(AssertionException exception = null) {
			IsInterfaceType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is an interface type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsInterfaceType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (!type.IsInterface) throw exception ?? new AssertionException($"Expected type to be an interface type: {type.FullName}");
		}

		/// <summary>
		/// Asserts that the specified type is not an interface type.
		/// </summary>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <typeparam name="TValue">The type to test.</typeparam>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotInterfaceType<TValue>(AssertionException exception = null) {
			IsNotInterfaceType(typeof(TValue), exception: exception);
		}

		/// <summary>
		/// Asserts that the specified type is not an interface type.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotInterfaceType(Type type, AssertionException exception = null) {
			if (type == null) throw new ArgumentNullException(nameof(type));
			if (type.IsInterface) throw exception ?? new AssertionException($"Expected type to be a non-interface type: {type.FullName}");
		}
	}
}
