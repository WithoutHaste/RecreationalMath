from generate_primes import generate_primes
from utils import save_as_text_dict, save_as_javascript_dict


def generate_prime_divisors(max):
	""" Returns an associative array of key=integer, value=array of non-unique prime divisors """
	""" From 1 to max """
	""" fast enough as-is for current use cases """
	if max <= 0:
		raise Exception('generate_prime_divisors requires a positive integer')
		
	primes = generate_primes(max);
		
	result = {}
	for i in range(max+1):
		n = i + 1
		result[n] = []
		nDecreasing = n + 0
		pIndex = 0
		while nDecreasing > 1 and pIndex < len(primes):
			if nDecreasing % primes[pIndex] == 0:
				result[n].append(primes[pIndex])
				nDecreasing = nDecreasing / primes[pIndex]
			else:
				pIndex = pIndex + 1
	return result	
	

def generate_divisors(max):
	""" Returns an associative array of key=integer, value=array of proper divisors """
	""" From 1 to max """
	""" fast enough as-is for current use cases """
	if max <= 0:
		raise Exception('generate_divisors requires a positive integer')
		
	result = {}
	for i in range(max+1):
		n = i + 1
		result[n] = []
		for j in range(n):
			divisor = j + 1
			if (n % divisor) != 0:
				continue
			result[n].append(divisor)
	return result	
	
def main():
	divisors_1000 = generate_divisors(1000)
	save_as_text_dict(divisors_1000, 'divisors_1_1000')

	js_comments = [
		'INTS_DIVISORS[n] = array of proper divisors',
		'for integers 1-1000',
		'proper divisor: the number itself is included, and the values are distinct'
	]
	save_as_javascript_dict(divisors_1000, 'integers_divisors', 'INTS_DIVISORS', js_comments, 'w')

	divisors_10000 = generate_divisors(10000)
	save_as_text_dict(divisors_10000, 'divisors_1_10000')
	
	##########################

	prime_divisors_1000 = generate_prime_divisors(1000)
	save_as_text_dict(prime_divisors_1000, 'divisors_prime_1_1000')

	js_comments = [
		'INTS_DIVISORS_PRIME[n] = array of non-unique prime divisors',
		'for integers 1-1000'
	]
	save_as_javascript_dict(prime_divisors_1000, 'integers_divisors_prime', 'INTS_DIVISORS_PRIME', js_comments, 'w')

	prime_divisors_10000 = generate_prime_divisors(10000)
	save_as_text_dict(prime_divisors_10000, 'divisors_prime_1_10000')

if __name__ == "__main__":
    main()
