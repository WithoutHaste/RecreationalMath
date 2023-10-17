from utils import save_as_text_list, save_as_javascript_list

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
	
def generate_emirp_primes(max):
	""" Returns an array of emirp prime numbers from 1 to max """
	""" Generates primes itself to facilitate testing """
	primes = generate_primes(max)
	return [i for i in primes if reverse(i) in primes and i != reverse(i)]
	
def reverse(number):
	""" returns an integer, the reverse of 'number' """
	return int(str(number)[::-1])
	
def generate_twin_primes(max):
	""" Returns an array of twin prime numbers from 1 to max """
	""" Generates primes itself to facilitate testing """
	primes = generate_primes(max)
	return [i for i in primes if (i-2) in primes or (i+2) in primes]

def main():
	primes_1000 = generate_primes(1000)
	emirps_1000 = generate_emirp_primes(1000)
	twins_1000 = generate_twin_primes(1000)
	save_as_text_list(primes_1000, 'prime_1_1000')
	save_as_text_list(emirps_1000, 'prime_emirp_1_1000')
	save_as_text_list(twins_1000, 'primes_twin_1_1000')

	primes_10000 = generate_primes(10000)
	emirps_10000 = generate_emirp_primes(10000)
	twins_10000 = generate_twin_primes(10000)
	save_as_text_list(primes_10000, 'prime_1_10000')
	save_as_text_list(emirps_10000, 'prime_emirp_1_10000')
	save_as_text_list(twins_10000, 'primes_twin_1_10000')
	save_as_javascript_list(primes_10000, 'integers_primes', 'INTS_PRIMES', ['prime numbers 1-10000'], 'w')
	save_as_javascript_list(emirps_10000, 'integers_primes', 'INTS_PRIMES_EMIRP', ['emirp prime numbers 1-10000'], 'a')
	save_as_javascript_list(twins_10000, 'integers_primes', 'INTS_PRIMES_TWIN', ['twin prime numbers 1-10000'], 'a')

if __name__ == "__main__":
    main()
