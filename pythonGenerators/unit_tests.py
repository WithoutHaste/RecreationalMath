import unittest
from generate_divisors import generate_divisors
from generate_happy import generate_happy
from generate_lucky import generate_lucky, apply_next_lucky
from generate_perfect_powers import generate_perfect_powers
from generate_primes import generate_primes, generate_emirp_primes, generate_twin_primes, generate_balanced_primes

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
		# init lucky as 1, 3, 5, 7, 9, 11
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
	
if __name__ == "__main__":
    unittest.main()
		