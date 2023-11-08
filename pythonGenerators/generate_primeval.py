from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits
from generate_primes import generate_primes

def generate_primeval(max):
	""" Returns an array of primeval numbers from 1 to max """

	if max <= 0:
		raise Exception('generate_primeval requires a positive integer')

	primes = generate_primes(max*10) #times 10 because a larger prime could be created from a smaller number's digits
	prime_digit_counts = [get_digit_counts(x) for x in primes]

	is_primeval = [1]
	max_distinct_primes = 0
	for n in range(max+1):
		if n < 2:
			continue
		count_distinct_primes = count_distinct_primes_written_from_n(n, prime_digit_counts)
		if count_distinct_primes <= max_distinct_primes:
			continue
		is_primeval.append(n)
		max_distinct_primes = count_distinct_primes
	
	return is_primeval

def count_distinct_primes_written_from_n(n, prime_digit_counts):
	n_digit_counts = get_digit_counts(n)
	count_distinct_primes = 0
	for p_digit_counts in prime_digit_counts:
		if digit_count_contains(n_digit_counts, p_digit_counts):
			count_distinct_primes = count_distinct_primes + 1
	return count_distinct_primes
	
def digit_count_contains(larger, smaller):
	""" Returns True if the large digit count contains all the values from the smaller digit count """
	for i in range(len(larger)):
		if larger[i] < smaller[i]:
			return False
	return True

def get_digit_counts(n):
	""" Returns array, indexes are the distinct digits in n, values are the number of times that digit appears in n """
	digit_counts = [0] * 10 #digits 0-9
	for d in digits(n):
		digit_counts[d] = digit_counts[d] + 1
	return digit_counts
		
	

def main():
	primeval_1000 = generate_primeval(1000)
	save_as_text_list(primeval_1000, 'primeval_1_1000')

	primeval_10000 = generate_primeval(10000)
	save_as_text_list(primeval_10000, 'primeval_1_10000')
	save_as_javascript_list(primeval_10000, 'integers_primeval', 'INTS_PRIMEVAL', ['primeval numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
