from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits

def generate_niven(max):
	""" Returns an array of niven numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_niven requires a positive integer')
		
	is_niven = []
	for n in range(max+1):
		if n < 1:
			continue
		sum_of_digits = sum(digits(n))
		if n % sum_of_digits == 0:
			is_niven.append(n)
	
	return is_niven

	

def main():
	niven_1000 = generate_niven(1000)
	save_as_text_list(niven_1000, 'niven_1_1000')

	niven_10000 = generate_niven(10000)
	save_as_text_list(niven_10000, 'niven_1_10000')
	save_as_javascript_list(niven_10000, 'integers_niven', 'INTS_NIVEN', ['niven numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
