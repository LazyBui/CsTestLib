﻿using System;
using System.Text.RegularExpressions;

namespace TestLib.Framework {
	public partial class Assert {
		/// <summary>
		/// Asserts that <paramref name="input" /> matches the regex pattern.
		/// </summary>
		/// <param name="regex">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="regex" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsMatch(Regex regex, string input, AssertionException exception = null) {
			if (regex == null) throw new ArgumentNullException(nameof(regex));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (!regex.IsMatch(input)) throw exception ?? new AssertionException("Regex pattern was not matched");
		}

		/// <summary>
		/// Asserts that <paramref name="input" /> matches the regex pattern.
		/// </summary>
		/// <param name="regexPattern">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="regexPattern" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsMatch(string regexPattern, string input, AssertionException exception = null) {
			if (regexPattern == null) throw new ArgumentNullException(nameof(regexPattern));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (!Regex.IsMatch(input, regexPattern)) throw exception ?? new AssertionException("Regex pattern was not matched");
		}

		/// <summary>
		/// Asserts that <paramref name="input" /> produces the specified count of matches to the regex pattern.
		/// </summary>
		/// <param name="regex">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="count">The specific quantity of matches expected.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="count" /> is negative.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="regex" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void MatchCount(Regex regex, string input, int count, AssertionException exception = null) {
			if (regex == null) throw new ArgumentNullException(nameof(regex));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (count < 0) throw new ArgumentException("Must be non-negative", nameof(count));
			if (regex.Matches(input).Count != count) throw exception ?? new AssertionException("Regex pattern was not matched the specified number of times: {0}", count);
		}

		/// <summary>
		/// Asserts that <paramref name="input" /> produces the specified count of matches to the regex pattern.
		/// </summary>
		/// <param name="regexPattern">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="count">The specific quantity of matches expected.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentException"><paramref name="count" /> is negative.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="regexPattern" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void MatchCount(string regexPattern, string input, int count, AssertionException exception = null) {
			if (regexPattern == null) throw new ArgumentNullException(nameof(regexPattern));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (count < 0) throw new ArgumentException("Must be non-negative", nameof(count));
			if (Regex.Matches(input, regexPattern).Count != count) throw exception ?? new AssertionException("Regex pattern was not matched the specified number of times: {0}", count);
		}

		/// <summary>
		/// Asserts that <paramref name="input" /> does not match the regex pattern.
		/// </summary>
		/// <param name="regex">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="regex" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotMatch(Regex regex, string input, AssertionException exception = null) {
			if (regex == null) throw new ArgumentNullException(nameof(regex));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (regex.IsMatch(input)) throw exception ?? new AssertionException("Regex pattern matched");
		}

		/// <summary>
		/// Asserts that <paramref name="input" /> does not match the regex pattern.
		/// </summary>
		/// <param name="regexPattern">The pattern to use.</param>
		/// <param name="input">The input to check.</param>
		/// <param name="exception">Optional exception to throw instead of the default.</param>
		/// <exception cref="ArgumentNullException"><paramref name="regexPattern" /> is null.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="input" /> is null.</exception>
		/// <exception cref="AssertionException">The condition implied by the function is not satisfied.</exception>
		public static void IsNotMatch(string regexPattern, string input, AssertionException exception = null) {
			if (regexPattern == null) throw new ArgumentNullException(nameof(regexPattern));
			if (input == null) throw new ArgumentNullException(nameof(input));
			if (Regex.IsMatch(input, regexPattern)) throw exception ?? new AssertionException("Regex pattern matched");
		}
	}
}
