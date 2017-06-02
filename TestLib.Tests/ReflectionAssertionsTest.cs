using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Framework;
using Assert = TestLib.Framework.Assert;

namespace TestLib.Tests {
	public partial class AssertTest {
		[TestMethod]
		[TestCategory("TestLib")]
		public void IsType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsType<string>(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType<int>("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType<int?>(1));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsType<int>(1));

			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsType(null, typeof(string)));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsType("hello", null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType("hello", typeof(int)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType(1, typeof(int?)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsType(1L, typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsType(1, typeof(int)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotType<string>(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotType<int>(1));
			Assert.DoesNotThrow(() => Assert.IsNotType<int?>(1));
			Assert.DoesNotThrow(() => Assert.IsNotType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsNotType<int>("hello"));

			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotType(null, typeof(string)));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotType("hello", null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotType(1, typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsNotType(1, typeof(int?)));
			Assert.DoesNotThrow(() => Assert.IsNotType(1L, typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsNotType("hello", typeof(int)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsAssignableFromType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsAssignableFromType<string>(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsAssignableFromType<int>("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsAssignableFromType<int>(1L));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType<int>(new int?(1)));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType<int>(1));

			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsAssignableFromType(null, typeof(string)));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsAssignableFromType("hello", null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsAssignableFromType("hello", typeof(int)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsAssignableFromType(1L, typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType(new int?(1), typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsAssignableFromType(1, typeof(int)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotAssignableFromType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotAssignableFromType<string>(null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotAssignableFromType<int>(1));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType<long>(1));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotAssignableFromType<int>(new int?(1)));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType<int>("hello"));

			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotAssignableFromType(null, typeof(string)));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotAssignableFromType("hello", null));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotAssignableFromType(1, typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType(1, typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotAssignableFromType(new int?(1), typeof(int)));
			Assert.DoesNotThrow(() => Assert.IsNotAssignableFromType("hello", typeof(int)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsArrayType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsArrayType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsArrayType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsArrayType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsArrayType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsArrayType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsArrayType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotArrayType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotArrayType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotArrayType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsNotArrayType("hello"));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(1L));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotArrayType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsNotArrayType<string>());
			Assert.DoesNotThrow(() => Assert.IsNotArrayType<long>());
			Assert.DoesNotThrow(() => Assert.IsNotArrayType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsNotArrayType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotArrayType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsNotArrayType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsNotArrayType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotArrayType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsNotArrayType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsEnumType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsEnumType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsEnumType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(1L));
			Assert.DoesNotThrow(() => Assert.IsEnumType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType<long>());
			Assert.DoesNotThrow(() => Assert.IsEnumType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsEnumType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsEnumType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotEnumType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotEnumType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotEnumType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsNotEnumType("hello"));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotEnumType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsNotEnumType<string>());
			Assert.DoesNotThrow(() => Assert.IsNotEnumType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotEnumType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsNotEnumType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsNotEnumType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsNotEnumType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsNotEnumType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotEnumType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsNotEnumType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsStructType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsStructType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsStructType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType("hello"));
			Assert.DoesNotThrow(() => Assert.IsStructType(1L));
			Assert.DoesNotThrow(() => Assert.IsStructType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType<string>());
			Assert.DoesNotThrow(() => Assert.IsStructType<long>());
			Assert.DoesNotThrow(() => Assert.IsStructType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsStructType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsStructType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsStructType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotStructType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotStructType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotStructType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsNotStructType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsNotStructType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsNotStructType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsNotStructType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsNotStructType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsNotStructType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsNotStructType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsNotStructType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotStructType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsNotStructType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsNotStructType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsNotStructType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsClassType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsClassType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsClassType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsClassType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsClassType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsClassType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsClassType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsClassType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsClassType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsClassType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsClassType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsClassType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsClassType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotClassType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotClassType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotClassType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType("hello"));
			Assert.DoesNotThrow(() => Assert.IsNotClassType(1L));
			Assert.DoesNotThrow(() => Assert.IsNotClassType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType<string>());
			Assert.DoesNotThrow(() => Assert.IsNotClassType<long>());
			Assert.DoesNotThrow(() => Assert.IsNotClassType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsNotClassType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsNotClassType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsNotClassType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotClassType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsNotClassType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsSealedType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsSealedType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsSealedType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsSealedType("hello"));
			Assert.DoesNotThrow(() => Assert.IsSealedType(1L));
			Assert.DoesNotThrow(() => Assert.IsSealedType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSealedType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsSealedType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsSealedType<string>());
			Assert.DoesNotThrow(() => Assert.IsSealedType<long>());
			Assert.DoesNotThrow(() => Assert.IsSealedType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSealedType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsSealedType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSealedType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsSealedType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsSealedType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsSealedType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSealedType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsSealedType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsSealedType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotSealedType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotSealedType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotSealedType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsNotSealedType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsNotSealedType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsNotSealedType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsNotSealedType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotSealedType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsNotSealedType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsGenericType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsGenericType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsGenericType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType("hello"));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(1L));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(AttributeTargets.All));
			Assert.DoesNotThrow(() => Assert.IsGenericType(new List<int>()));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(new int[0]));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsGenericType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsGenericType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsGenericType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsGenericType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsGenericType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotGenericType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotGenericType(null as object));
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotGenericType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsNotGenericType("hello"));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(1L));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(AttributeTargets.All));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotGenericType(new List<int>()));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(new int[0]));

			Assert.DoesNotThrow(() => Assert.IsNotGenericType<string>());
			Assert.DoesNotThrow(() => Assert.IsNotGenericType<long>());
			Assert.DoesNotThrow(() => Assert.IsNotGenericType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotGenericType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsNotGenericType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotGenericType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsNotGenericType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotGenericType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsNotGenericType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotGenericType(typeof(IEnumerable<int>)));
		}


		[TestMethod]
		[TestCategory("TestLib")]
		public void IsInterfaceType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsInterfaceType(null as Type));

			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType<string>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType<long>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType<AttributeTargets>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType<List<int>>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType<int[]>());
			Assert.DoesNotThrow(() => Assert.IsInterfaceType<IEnumerable<int>>());

			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType(typeof(string)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType(typeof(long)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType(typeof(AttributeTargets)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType(typeof(List<int>)));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsInterfaceType(typeof(int[])));
			Assert.DoesNotThrow(() => Assert.IsInterfaceType(typeof(IEnumerable<int>)));
		}

		[TestMethod]
		[TestCategory("TestLib")]
		public void IsNotInterfaceType() {
			Assert.ThrowsExact<ArgumentNullException>(() => Assert.IsNotInterfaceType(null as Type));

			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType<string>());
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType<long>());
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType<AttributeTargets>());
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType<List<int>>());
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType<int[]>());
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInterfaceType<IEnumerable<int>>());

			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType(typeof(string)));
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType(typeof(long)));
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType(typeof(AttributeTargets)));
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType(typeof(List<int>)));
			Assert.DoesNotThrow(() => Assert.IsNotInterfaceType(typeof(int[])));
			Assert.ThrowsExact<AssertionException>(() => Assert.IsNotInterfaceType(typeof(IEnumerable<int>)));
		}
	}
}
