import unittest
from generate_bell import generate_bell
from generate_catalan import generate_catalan
from generate_divisors import generate_divisors, generate_prime_divisors
from generate_esthetic import generate_esthetic
from generate_figurate import generate_triangular, generate_square, generate_pentagonal
from generate_friendly_clusters import generate_friendly_clusters
from generate_goldbach_conjecture import generate_goldbach_conjecture
from generate_happy import generate_happy
from generate_hogben import generate_hogben
from generate_lucky import generate_lucky, apply_next_lucky
from generate_magic import generate_magic
from generate_magnanimous import generate_magnanimous
from generate_niven import generate_niven, generate_super_niven
from generate_nude import generate_nude
from generate_partitions import generate_partitions
from generate_perfect_powers import generate_perfect_powers
from generate_practical import generate_sums_to_n, contains_set, one_of_these_is_a_subset, generate_practical, generate_permutations, increment_and_return_permutation, n_is_practical_by_permutations
from generate_primes import generate_primes, generate_emirp_primes, generate_twin_primes, generate_balanced_primes
from generate_primeval import generate_primeval
from generate_self import generate_self
from generate_sphenic import generate_sphenic

class unit_tests(unittest.TestCase):
			
	def assert_includes_excludes(self, list, included, excluded):
		for i in included:
			self.assertTrue(i in list)
		for i in excluded:
			self.assertFalse(i in list)

	def test_prime(self):
		known_primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97]
		primes = generate_primes(1000)
		self.assertFalse(1 in primes)
		for i in range(len(known_primes)):
			self.assertEqual(known_primes[i], primes[i])

	def test_prime_emirp(self):
		known_emirps = [13, 17, 31, 37, 71, 73, 79, 97, 107, 113, 149, 157, 167, 179, 199, 311, 337, 347, 359, 389, 701, 709, 733, 739, 743, 751]
		emirps = generate_emirp_primes(1000)
		self.assertFalse(101 in emirps) # palindromes don't count
		for i in range(len(known_emirps)):
			self.assertEqual(known_emirps[i], emirps[i])

	def test_prime_twin(self):
		known_twins = [[3, 5], [5, 7], [11, 13], [17, 19], [29, 31], [41, 43], [59, 61], [71, 73], [101, 103], [107, 109]]
		twins = generate_twin_primes(200)
		for i in range(len(known_twins)):
			self.assertEqual(known_twins[i][0], twins[i][0])
			self.assertEqual(known_twins[i][1], twins[i][1])

	def test_prime_balanced(self):
		known_balanced = [5, 53, 157, 173, 211, 257, 263, 373, 563, 593]
		balanced = generate_balanced_primes(600)
		for i in range(len(known_balanced)):
			self.assertEqual(known_balanced[i], balanced[i])

	def test_divisors(self):
		known_divisors = {
			1: [1],
			2: [1, 2],
			3: [1, 3],
			4: [1, 2, 4],
			5: [1, 5],
			6: [1, 2, 3, 6],
			7: [1, 7],
			8: [1, 2, 4, 8],
			9: [1, 3, 9],
			10: [1, 2, 5, 10],
			11: [1, 11],
			12: [1, 2, 3, 4, 6, 12],
			13: [1, 13],
			14: [1, 2, 7, 14],
			15: [1, 3, 5, 15],
			16: [1, 2, 4, 8, 16],
			17: [1, 17],
			18: [1, 2, 3, 6, 9, 18],
			19: [1, 19],
			20: [1, 2, 4, 5, 10, 20],		
		}
		divisors = generate_divisors(30)
		for key in known_divisors:
			self.assertEqual(len(known_divisors[key]), len(divisors[key]))
			for val in known_divisors[key]:
				self.assertTrue(val in divisors[key])

	def test_prime_divisors(self):
		known_divisors = {
			1: [],
			2: [2],
			3: [3],
			4: [2, 2],
			5: [5],
			6: [2, 3],
			7: [7],
			8: [2, 2, 2],
			9: [3, 3],
			10: [2, 5],
			11: [11],
			12: [2, 2, 3],
			13: [13],
			14: [2, 7],
			15: [3, 5],
			16: [2, 2, 2, 2],
			17: [17],
			18: [2, 3, 3],
			19: [19],
			20: [2, 2, 5],		
		}
		prime_divisors = generate_prime_divisors(30)
		for key in known_divisors:
			self.assertEqual(len(known_divisors[key]), len(prime_divisors[key]))
			for val in known_divisors[key]:
				self.assertTrue(val in prime_divisors[key])

	def test_happy(self):
		known_not = [4, 16, 37, 58, 89, 145, 42, 20]
		known = [1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130]
		result = generate_happy(200)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_apply_next_lucky(self):
		# lucky as 1, 3, 5, 7, 9, 11
		is_lucky = [False, True, False, True, False, True, False, True, False, True, False, True]
		next_lucky = 3
		apply_next_lucky(is_lucky, next_lucky)
		self.assertTrue(is_lucky[3])
		self.assertFalse(is_lucky[5])
		self.assertTrue(is_lucky[7])
		self.assertFalse(is_lucky[11])

	def test_lucky(self):
		known_not = [0, 2, 4, 5, 6, 8, 10, 11, 12, 14, 16, 17, 18, 19, 20, 22, 23, 24]
		known = [1, 3, 7, 9, 13, 15, 21, 25, 31, 33, 37, 43, 49, 51, 63, 67, 69, 73, 75, 79, 87, 93, 99, 105]
		result = generate_lucky(200)
		self.assert_includes_excludes(result, known, known_not)

	def test_perfect_powers(self):
		known_perfect_powers = [1, 4, 8, 9, 16, 25, 27, 32, 36, 49, 64, 81, 100, 121, 125, 128, 144, 169, 196, 216, 225, 243, 256, 289, 324, 343, 361]
		perfect_powers = generate_perfect_powers(370)
		for i in range(len(known_perfect_powers)):
			self.assertEqual(known_perfect_powers[i], perfect_powers[i])
			
	def assert_list_of_list_of_list_matches(self, a, b):
		for n in range(len(a)):
			self.assertEqual(len(a[n]), len(b[n]))
			for set_b in b[n]:
				self.assertTrue(contains_set(set_b, a[n]))
				
	def assert_list_of_list_matches(self, a, b):
		""" input format: [ [1], [1,2,3], [4,5] ] """
		self.assertEqual(len(a), len(b))
		a.sort()
		b.sort()
		for a_prime in a:
			a_prime.sort()
			found_match = False
			for b_prime in b:
				b_prime.sort()
				if a_prime == b_prime:
					found_match = True
					break
			self.assertTrue(found_match)
			
	def test_sums_to_n(self):
		known_sums = [
			[],
			[[1]],
			[[2]],
			[[3], [1,2]],
			[[4], [1,3]],
			[[5], [1,4], [2,3]],
			[[6], [1,5], [2,4], [1,2,3]],
			[[7], [1,6], [2,5], [3,4], [1,2,4]],
			[[8], [1,7], [2,6], [3,5], [1,2,5], [1,3,4]]
		]
		sums = generate_sums_to_n(8)
		self.assert_list_of_list_of_list_matches(known_sums, sums)
			
	def test_one_of_these_is_a_subset(self):
		self.assertFalse(one_of_these_is_a_subset([[1], [4, 7]], [2, 3, 6])) # no match at all
		self.assertFalse(one_of_these_is_a_subset([[1], [3, 7]], [2, 3, 6])) # no full match
		self.assertTrue(one_of_these_is_a_subset([[1], [3, 6]], [2, 3, 6])) # one full match
		
	def test_generate_permutations(self):
		set_a = [1, 2, 3]
		permutations_a = [[], [1], [2], [3], [1,2], [1,3], [2,3], [1,2,3]]		self.assert_list_of_list_matches(permutations_a, generate_permutations([], set_a))
		
	def test_increment_and_return_permutation(self):
		# initial state
		divisors = [1, 2, 4, 5, 7]
		permutation = [0, 0, 0, 0, 0]
		result = increment_and_return_permutation(permutation, divisors)
		self.assertEqual([0, 0, 0, 0, 1], permutation)
		self.assertEqual([7], result)
		# middle state
		permutation = [0, 0, 1, 1, 0]
		result = increment_and_return_permutation(permutation, divisors)
		self.assertEqual([0, 0, 1, 1, 1], permutation)
		self.assertEqual([4, 5, 7], result)
		# flip several 1's to 0's
		permutation = [1, 0, 1, 1, 1]
		result = increment_and_return_permutation(permutation, divisors)
		self.assertEqual([1, 1, 0, 0, 0], permutation)
		self.assertEqual([1, 2], result)
		
	def test_n_is_practical_by_permutations(self):
		# basic cases
		self.assertTrue(n_is_practical_by_permutations(6, [1,2,3,6]))
		self.assertFalse(n_is_practical_by_permutations(7, [1,7]))
		self.assertTrue(n_is_practical_by_permutations(8, [1,2,4,8]))
		self.assertFalse(n_is_practical_by_permutations(9, [1,9]))
		self.assertFalse(n_is_practical_by_permutations(10, [1,2,5,10]))
		self.assertFalse(n_is_practical_by_permutations(11, [1,11]))
		self.assertTrue(n_is_practical_by_permutations(12, [1,2,3,4,6,12]))
		#sum of lower divisors adds up to a divisor
		self.assertTrue(n_is_practical_by_permutations(78, [1,2,3,6,13,26,39,78]))
		# do not add d again to a value just set to True based on d
		self.assertFalse(n_is_practical_by_permutations(102, [1,2,3,6,17,34,51,102]))
		#sum of lower divisors 1+2+4+6=13 is greater than next d=12
		self.assertTrue(n_is_practical_by_permutations(348, [1,2,3,4,6,12,29,58,87,116,174,348]))
	
	def test_generate_practical(self):
		known_not = [0, 3, 5, 7, 9, 10, 11, 13, 14, 15]
		known = [1, 2, 4, 6, 8, 12, 16, 18, 20, 24, 28, 30, 32, 36, 40, 42, 48, 54, 56, 60, 64, 66, 72, 78, 80, 84, 88, 90, 96, 100, 104, 108, 112, 120, 126, 128, 132, 140, 144, 150, 156, 160]
		result = generate_practical(160)
		self.assert_includes_excludes(result, known, known_not)
	
	def test_generate_esthetic(self):
		known_not = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13, 14]
		known = [10, 12, 21, 23, 32, 34, 43, 45, 54, 56, 65, 67, 76, 78, 87, 89, 98, 101, 121]
		result = generate_esthetic(121)
		self.assert_includes_excludes(result, known, known_not)
	
	def test_generate_hogben(self):
		known_not = [0, 2, 4, 5, 6, 8, 9, 10, 11, 12, 14]
		known = [1, 3, 7, 13, 21, 31, 43, 57, 73, 91, 111, 133, 157, 183, 211, 241, 273, 307, 343, 381]
		result = generate_hogben(381)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_self(self):
		known_not = [0, 2, 4, 6, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21]
		known = [1, 3, 5, 7, 9, 20, 31, 42, 53, 64, 75, 86, 97, 108, 110, 121, 132, 143, 154, 165, 176]
		result = generate_self(176)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_magic(self):
		known_not = [0, 2, 3, 4, 6, 7, 13, 14, 16, 17, 32, 33, 35, 36]
		known = [1, 5, 15, 34, 65, 111, 175, 260, 369, 505]
		result = generate_magic(505)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_magnanimous(self):
		known_not = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 15, 17, 18, 19, 22, 24, 26, 27, 28, 31, 33, 35, 36, 37, 122]
		known = [11, 12, 14, 16, 20, 21, 23, 25, 29, 30, 32, 34, 38, 41, 43, 47, 49, 50, 52, 56, 58, 61, 65, 67, 70, 74, 76, 83, 85, 89, 92, 94, 98, 101, 110, 112, 116, 118]
		result = generate_magnanimous(122)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_nude(self):
		known_not = [0, 10, 13, 14, 16, 17, 18, 19, 20, 21]
		known = [1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22, 24, 33, 36, 44, 48, 55, 66, 77, 88, 99, 111, 112, 115, 122, 124, 126, 128]
		result = generate_nude(128)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_partitions(self):
		known_not = [0, 4, 6, 8, 9, 10, 12, 13, 16, 17, 18, 19, 20, 21, 23, 29, 31, 41, 43, 55, 57, 76, 78, 100, 102, 134]
		known = [1, 2, 3, 5, 7, 11, 15, 22, 30, 42, 56, 77, 101, 135]
		result = generate_partitions(135)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_bell(self):
		known_not = [0, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 51, 53, 202]
		known = [1, 2, 5, 15, 52]#, 203]
		result = generate_bell(52)#(203)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_catalan(self):
		known_not = [0, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 15, 41, 43, 131, 133]
		known = [1, 2, 5, 14, 42, 132]
		result = generate_catalan(132)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_primeval(self):
		known_not = [0, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 17, 18, 19, 20, 30, 31, 32, 33, 34, 35, 36, 38, 39, 40, 106, 108]
		known = [1, 2, 13, 37, 107]
		result = generate_primeval(107)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_triangular(self):
		known_not = [0, 2, 4, 5, 7, 8, 9, 11, 12, 13, 14, 16, 17, 18, 19, 20, 22, 23, 24, 25, 26, 27, 29, 30]
		known = [1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210]
		result = generate_triangular(210)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_square(self):
		known_not = [0, 2, 3, 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 26]
		known = [1, 4, 9, 16, 25, 36, 49, 64, 81, 100, 121, 144, 169, 196, 225, 256]
		result = generate_square(256)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_pentagonal(self):
		known_not = [0, 2, 3, 4, 6, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23]
		known = [1, 5, 12, 22, 35, 51, 70, 92, 117, 145, 176, 210, 247, 287]
		result = generate_pentagonal(287)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_sphenic(self):
		known_not = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 29, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 43, 120]
		known = [30, 42, 66, 70, 78, 102, 105, 110, 114, 130, 138, 154, 165, 170]
		result = generate_sphenic(170)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_niven(self):
		known_not = [0, 11, 13, 14, 15, 16, 17, 19, 22, 23, 25, 26, 28, 29, 31, 32]
		known = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 18, 20, 21, 24, 27, 30, 36, 40, 42, 45, 48, 50, 54, 60, 63, 70, 72, 80, 81, 84, 90]
		result = generate_niven(90)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_super_niven(self):
		known_not = [0, 11, 13, 14, 15, 16, 17, 18, 19, 21, 22, 23, 25, 26, 27, 28, 29, 31, 35, 37, 39, 41, 47, 49, 51, 59, 61]
		known = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 20, 24, 30, 36, 40, 48, 50, 60, 70, 80, 90, 100, 102, 110, 120, 140, 150]
		result = generate_super_niven(150)
		self.assert_includes_excludes(result, known, known_not)
			
	def test_generate_goldbach_conjecture(self):
		known = {
			4: [2, 2],
			6: [3, 3],
			8: [3, 5],
			10: [3, 7],
			12: [5, 7],
			14: [3, 11],
			16: [3, 13],
			18: [5, 13],
			20: [3, 17],
		}
		result = generate_goldbach_conjecture(20)
		for key in known:
			if known[key] == None:
				self.assertEqual(None, result[key])
			else:
				self.assertEqual(len(known[key]), len(result[key]))
				for val in known[key]:
					self.assertTrue(val in result[key])

	def test_friendly_clusters(self):
		known_clusters = {
			0: [1],
			#1: [],
			2: [2],
			3: [3],
			4: [4],
			5: [5, 6],
			6: [8, 9],
			7: [7, 10, 12],
			8: [15, 16, 18],
			9: [14, 20, 24, 27],
			10: [21, 25, 30],
			11: [11, 28],
			#12: [],
			13: [13, 22],
			#14: [],
			15: [26],
			#16: [],
			17: [17],
			#18: [],
			19: [19],
			#20: [],
			23: [23],
			29: [29],
		}
		clusters = generate_friendly_clusters(30)
		for key in known_clusters:
			self.assertEqual(len(known_clusters[key]), len(clusters[key]))
			for val in known_clusters[key]:
				self.assertTrue(val in clusters[key])


	
if __name__ == "__main__":
    unittest.main()
		