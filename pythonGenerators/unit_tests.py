import unittest
from generate_divisors import generate_divisors
from generate_esthetic import generate_esthetic
from generate_happy import generate_happy
from generate_hogben import generate_hogben
from generate_lucky import generate_lucky, apply_next_lucky
from generate_perfect_powers import generate_perfect_powers
from generate_practical import generate_sums_to_n, contains_set, one_of_these_is_a_subset, generate_practical, generate_permutations, increment_and_return_permutation, n_is_practical_by_permutations
from generate_primes import generate_primes, generate_emirp_primes, generate_twin_primes, generate_balanced_primes
from generate_self import generate_self

class unit_tests(unittest.TestCase):
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

	def test_happy(self):
		known_unhappy = [4, 16, 37, 58, 89, 145, 42, 20]
		known_happy = [1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130]
		happy = generate_happy(200)
		for i in known_unhappy:
			self.assertFalse(i in happy)
		for i in known_happy:
			self.assertTrue(i in happy)
			
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
		known_unlucky = [0, 2, 4, 5, 6, 8, 10, 11, 12, 14, 16, 17, 18, 19, 20, 22, 23, 24]
		known_lucky = [1, 3, 7, 9, 13, 15, 21, 25, 31, 33, 37, 43, 49, 51, 63, 67, 69, 73, 75, 79, 87, 93, 99, 105]
		lucky = generate_lucky(200)
		for i in known_unlucky:
			self.assertFalse(i in lucky)
		for i in known_lucky:
			self.assertTrue(i in lucky)

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
		known_not_practical = [0, 3, 5, 7, 9, 10, 11, 13, 14, 15]
		known_practical = [1, 2, 4, 6, 8, 12, 16, 18, 20, 24, 28, 30, 32, 36, 40, 42, 48, 54, 56, 60, 64, 66, 72, 78, 80, 84, 88, 90, 96, 100, 104, 108, 112, 120, 126, 128, 132, 140, 144, 150, 156, 160]
		practical = generate_practical(160)
		for i in known_not_practical:
			self.assertFalse(i in practical)
		for i in known_practical:
			self.assertTrue(i in practical)
	
	def test_generate_esthetic(self):
		known_not_esthetic = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13, 14]
		known_esthetic = [10, 12, 21, 23, 32, 34, 43, 45, 54, 56, 65, 67, 76, 78, 87, 89, 98, 101, 121]
		esthetic = generate_esthetic(121)
		for i in known_not_esthetic:
			self.assertFalse(i in esthetic)
		for i in known_esthetic:
			self.assertTrue(i in esthetic)
	
	def test_generate_hogben(self):
		known_not_hogben = [0, 2, 4, 5, 6, 8, 9, 10, 11, 12, 14]
		known_hogben = [1, 3, 7, 13, 21, 31, 43, 57, 73, 91, 111, 133, 157, 183, 211, 241, 273, 307, 343, 381]
		hogben = generate_hogben(381)
		for i in known_not_hogben:
			self.assertFalse(i in hogben)
		for i in known_hogben:
			self.assertTrue(i in hogben)
			
	def test_generate_self(self):
		known_not_self = [0, 2, 4, 6, 8, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 21]
		known_self = [1, 3, 5, 7, 9, 20, 31, 42, 53, 64, 75, 86, 97, 108, 110, 121, 132, 143, 154, 165, 176]
		self_result = generate_self(176)
		for i in known_not_self:
			self.assertFalse(i in self_result)
		for i in known_self:
			self.assertTrue(i in self_result)

	
if __name__ == "__main__":
    unittest.main()
		