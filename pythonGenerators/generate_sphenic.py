from utils import save_as_text_list, save_as_javascript_list
from generate_divisors import generate_divisors
from generate_primes import generate_primes

def generate_sphenic(max):
	""" Returns an array of sphenic numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_sphenic requires a positive integer')

	divisors = generate_divisors(max)
	primes = generate_primes(max)
	is_sphenic = []
	for n in range(max+1):
		if n < 1:
			continue
		prime_divisors = [d for d in divisors[n] if d in primes and d != n]
		if len(prime_divisors) != 3:
			continue
		if n != prime_divisors[0] * prime_divisors[1] * prime_divisors[2]:
			continue
		is_sphenic.append(n)
	
	return is_sphenic

		
	

def main():
	sphenic_1000 = generate_sphenic(1000)
	save_as_text_list(sphenic_1000, 'sphenic_1_1000')

	sphenic_10000 = generate_sphenic(10000)
	save_as_text_list(sphenic_10000, 'sphenic_1_10000')
	save_as_javascript_list(sphenic_10000, 'integers_sphenic', 'INTS_SPHENIC', ['sphenic numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
