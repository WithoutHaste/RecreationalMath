from utils import save_as_text

def generate_primes(max):
	""" Returns an array of prime numbers from 1 to max """
	""" Algorithm: Sieve Of Eratosthenes """
	if max <= 0:
		raise Exception('generate_primes requires a positive integer')
		
	is_prime = [True for i in range(max + 1)]
	is_prime[0] = False
	is_prime[1] = False
	i = 2
	while i < len(is_prime):
		j = i + i
		while j < len(is_prime):
			is_prime[j] = False
			j = j + i
		i = i + 1
		
	return [i for i in range(len(is_prime)) if is_prime[i]]
	
result = generate_primes(1000)
save_as_text(result, 'prime_1_1000')

result = generate_primes(10000)
save_as_text(result, 'prime_1_10000')
