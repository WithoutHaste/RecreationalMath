import unittest
from generate_divisors import generate_divisors
from generate_primes import generate_primes, generate_emirp_primes, generate_twin_primes

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
		known_twins = [3, 5, 7, 11, 13, 17, 19, 29, 31, 41, 43, 59, 61, 71, 73, 101, 103, 107, 109]
		twins = generate_twin_primes(1000)
		self.assertEqual(1, twins.count(5)) # don't list duplicates twice (5 twins both 3 and 7)
		for i in range(len(known_twins)):
			self.assertEqual(known_twins[i], twins[i])

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
		divisors = generate_divisors(1000)
		for key in known_divisors:
			self.assertEqual(len(known_divisors[key]), len(divisors[key]))
			for val in known_divisors[key]:
				self.assertTrue(val in divisors[key])

if __name__ == "__main__":
    unittest.main()
		