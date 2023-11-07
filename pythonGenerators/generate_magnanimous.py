from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits
from generate_primes import generate_primes

def generate_magnanimous(max):
	""" Returns an array of magnanimous numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_magnanimous requires a positive integer')

	primes = generate_primes(max)
	is_magnanimous = []
	for n in range(max+1):
		if n < 10:
			continue
		d_str = convert_int_list_to_str_list(digits(n))
		success = True
		for i in range(len(d_str)):
			if i == 0:
				continue
			total = int(''.join(d_str[:i])) + int(''.join(d_str[i:]))
			if total not in primes:
				success = False
				break
		if success:
			is_magnanimous.append(n)
	
	return is_magnanimous

def convert_int_list_to_str_list(int_list):
	return [str(x) for x in int_list]

	

def main():
	magnanimous_1000 = generate_magnanimous(1000)
	save_as_text_list(magnanimous_1000, 'magnanimous_1_1000')

	magnanimous_10000 = generate_magnanimous(10000)
	save_as_text_list(magnanimous_10000, 'magnanimous_1_10000')
	save_as_javascript_list(magnanimous_10000, 'integers_magnanimous', 'INTS_MAGNANIMOUS', ['magnanimous numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
