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
	
def generate_super_niven(max):
	""" Returns an array of super niven numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_super_niven requires a positive integer')
		
	is_super_niven = []
	for n in range(max+1):
		if n < 1:
			continue
		subsets_of_digits = get_subsets(digits(n))
		success = True
		for s in subsets_of_digits:
			total = sum(s)
			if total == 0:
				continue
			if n%total != 0:
				success = False
				break
		if success:
			is_super_niven.append(n)
	
	return is_super_niven
	
def get_subsets(list):
	""" Assumes the list is small, uses simple but inefficient method """
	if len(list) == 0:
		return []
	if len(list) == 1:
		return [list, []]
	sub_result_a = get_subsets(list[1:])
	sub_result_b = [[list[0]] + s for s in sub_result_a]
	return sub_result_a + sub_result_b

	

def main():
	niven_1000 = generate_niven(1000)
	save_as_text_list(niven_1000, 'niven_1_1000')

	niven_10000 = generate_niven(10000)
	save_as_text_list(niven_10000, 'niven_1_10000')

	super_niven_1000 = generate_super_niven(1000)
	save_as_text_list(super_niven_1000, 'super_niven_1_1000')

	super_niven_10000 = generate_super_niven(10000)
	save_as_text_list(super_niven_10000, 'super_niven_1_10000')

	save_as_javascript_list(niven_10000, 'integers_niven', 'INTS_NIVEN', ['niven numbers 1-10000'], 'w')
	save_as_javascript_list(super_niven_10000, 'integers_niven', 'INTS_SUPER_NIVEN', ['super niven numbers 1-10000'], 'a')

if __name__ == "__main__":
    main()
