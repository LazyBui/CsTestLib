using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test {
	internal partial class Assert {
		/// <summary>
		/// Asserts that sequence has no elements.
		/// </summary>
		public static void Empty<TValue>(IEnumerable<TValue> pSequence, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pSequence.Any()) throw pException ?? new AssertionException("Expected no elements");
		}

		/// <summary>
		/// Asserts that sequence has one or more elements.
		/// </summary>
		public static void NotEmpty<TValue>(IEnumerable<TValue> pSequence, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw pException ?? new AssertionException("Expected elements");
		}

		/// <summary>
		/// Asserts that an entire sequence with one or more elements matches the predicate.
		/// </summary>
		public static void All<TValue>(IEnumerable<TValue> pSequence, Func<TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (!pSequence.All(pPredicate)) throw pException ?? new AssertionException("Expected all elements to match predicate");
		}

		/// <summary>
		/// Asserts that one or more elements of a sequence with one or more elements matches the predicate.
		/// </summary>
		public static void Any<TValue>(IEnumerable<TValue> pSequence, Func<TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (!pSequence.Any(pPredicate)) throw pException ?? new AssertionException("Expected at least 1 element to match predicate");
		}

		/// <summary>
		/// Asserts that exactly one element of a sequence with one or more elements matches the predicate.
		/// </summary>
		public static void Only<TValue>(IEnumerable<TValue> pSequence, Func<TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count(pPredicate) != 1) throw pException ?? new AssertionException("Expected only 1 element to match predicate");
		}

		/// <summary>
		/// Asserts that exactly a specified number of elements of a sequence with one or more elements matches the predicate.
		/// </summary>
		public static void Exactly<TValue>(IEnumerable<TValue> pSequence, int pCount, Func<TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count(pPredicate) != pCount) throw pException ?? new AssertionException("Expected {0} elements to match predicate", pCount);
		}

		/// <summary>
		/// Asserts that no elements of a sequence with one or more elements matches the predicate.
		/// </summary>
		public static void None<TValue>(IEnumerable<TValue> pSequence, Func<TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Any(pPredicate)) throw pException ?? new AssertionException("Expected no elements to match predicate");
		}

		/// <summary>
		/// Asserts that a sequence has a specified number of elements.
		/// </summary>
		public static void Count<TValue>(IEnumerable<TValue> pSequence, int pCount, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() != pCount) throw pException ?? new AssertionException("Expected {0} elements in sequence", pCount);
		}

		/// <summary>
		/// Asserts that a sequence has a specified number of a specific element.
		/// </summary>
		public static void Count<TValue>(IEnumerable<TValue> pSequence, int pCount, TValue pValue, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count(e => IsEqual(e, pValue)) != pCount) throw pException ?? new AssertionException("Expected {0} elements in sequence", pCount);
		}

		/// <summary>
		/// Asserts that a sequence contains a specific value.
		/// </summary>
		public static void Contains<TValue>(IEnumerable<TValue> pSequence, TValue pValue, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (!pSequence.Contains(pValue)) throw pException ?? new AssertionException("Expected value is missing");
		}

		/// <summary>
		/// Asserts that a sequence does not contain a specific value.
		/// </summary>
		public static void DoesNotContain<TValue>(IEnumerable<TValue> pSequence, TValue pValue, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Contains(pValue)) throw pException ?? new AssertionException("Expected value is present");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has no duplicates that match the predicate.
		/// </summary>
		public static void Unique<TValue>(IEnumerable<TValue> pSequence, Func<TValue, TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct(new EqualityComparerStateful<TValue>(pPredicate)).Count() != pSequence.Count()) throw pException ?? new AssertionException("Expected all elements to be unique based on the predicate");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has no duplicates that match the predicate.
		/// </summary>
		public static void Unique<TValue, TCompare>(IEnumerable<TValue> pSequence, Func<TValue, TCompare> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct(new EqualityComparerStateless<TValue, TCompare>(pPredicate)).Count() != pSequence.Count()) throw pException ?? new AssertionException("Expected all elements to be unique based on the predicate");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has no duplicates.
		/// </summary>
		public static void Unique<TValue>(IEnumerable<TValue> pSequence, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct().Count() != pSequence.Count()) throw pException ?? new AssertionException("Expected all elements to be unique");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has at least one duplicate pair that matches the predicate.
		/// </summary>
		public static void NotUnique<TValue>(IEnumerable<TValue> pSequence, Func<TValue, TValue, bool> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct(new EqualityComparerStateful<TValue>(pPredicate)).Count() == pSequence.Count()) throw pException ?? new AssertionException("Expected at least one duplicate pair of elements based on the predicate");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has at least one duplicate pair that matches the predicate.
		/// </summary>
		public static void NotUnique<TValue, TCompare>(IEnumerable<TValue> pSequence, Func<TValue, TCompare> pPredicate, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (pPredicate == null) throw new ArgumentNullException("pPredicate");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct(new EqualityComparerStateless<TValue, TCompare>(pPredicate)).Count() == pSequence.Count()) throw pException ?? new AssertionException("Expected at least one duplicate pair of elements based on the predicate");
		}

		/// <summary>
		/// Asserts that an entire sequence with two or more elements has at least one duplicate pair.
		/// </summary>
		public static void NotUnique<TValue>(IEnumerable<TValue> pSequence, AssertionException pException = null) {
			if (pSequence == null) throw new ArgumentNullException("pSequence");
			if (!pSequence.Any()) throw new ArgumentException("Expected elements", "pSequence");
			if (pSequence.Count() == 1) throw new ArgumentException("Sequence cannot be assessed for duplicates if there is only a single element");
			if (pSequence.Distinct().Count() == pSequence.Count()) throw pException ?? new AssertionException("Expected at least one duplicate pair of elements");
		}
	}
}
