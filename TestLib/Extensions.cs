using System;

namespace TestLib.Framework {
	/// <summary>
	/// Provides access to extension methods.
	/// </summary>
	public static class Extensions {
		/// <summary>
		/// Determines whether the class represented by the current <see cref="Type" /> equals or derives from the class represented by the specified <see cref="Type" />.
		/// </summary>
		/// <param name="this">The <see cref="Type" />.</param>
		/// <param name="check">The <see cref="Type" /> to compare with the current <see cref="Type" />.</param>
		/// <returns>true if the <see cref="Type" /> represented by <paramref name="check" /> is equivalent to or a more base type of <paramref name="this" />; otherwise, false.</returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="this" /> is null.
		///		<paramref name="check" /> is null.
		/// </exception>
		public static bool EqualsOrInherits(this Type @this, Type check) {
			if (@this == null) throw new ArgumentNullException(nameof(@this));
			if (check == null) throw new ArgumentNullException(nameof(check));
			return @this == check || @this.IsSubclassOf(check);
		}
	}
}
