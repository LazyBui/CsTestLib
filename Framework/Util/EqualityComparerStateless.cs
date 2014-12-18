using System;
using System.Collections.Generic;

namespace Test {
	/// <summary>
	/// Allows equality comparison based on an arbitrary property of class.
	/// </summary>
	/// <typeparam name="TKey">The type that comparison will be done on.</typeparam>
	/// <typeparam name="TValue">The type of the property that will compared for equality.</typeparam>
	internal sealed class EqualityComparerStateless<TKey, TValue> : IEqualityComparer<TKey> where TValue : IEquatable<TValue> {
		private Func<TKey, TValue> mSelector = null;

		public EqualityComparerStateless(Func<TKey, TValue> pSelector) {
			if (pSelector == null) throw new ArgumentNullException("pSelector");
			mSelector = pSelector;
		}

		public bool Equals(TKey x, TKey y) {
			return mSelector(x).Equals(mSelector(y));
		}

		public int GetHashCode(TKey obj) {
			return mSelector(obj).GetHashCode();
		}
	}
}
