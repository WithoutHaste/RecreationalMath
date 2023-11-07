from utils import save_as_text_list, save_as_javascript_list

def generate_bell(max):
	""" Returns an array of bell numbers from 1 to max """

	if max <= 0:
		raise Exception('generate_bell requires a positive integer')

	is_bell = []
	for n in range(max+1):
		if n < 1:
			continue
		number_of_ways = number_of_ways_n_can_be_partitioned(n)
		if number_of_ways > max:
			break
		is_bell.append(number_of_ways)		
	
	return is_bell
	
def number_of_ways_n_can_be_partitioned(n):
	"""
	can I linearly iterate through all unique possible partitions?
	n = 4, elements = a,b,c,d
	partitions:
	all separate a,b,c,d
	two together (a,b),c,d | a,(b,c),d | a,b,(c,d) | (a,c),b,d | a,c,(b,d) | (a,d),b,c | (a,b),(c,d) | (a,c),(b,d) | (a,d),(b,c)
	three together (a,b,c),d | a,(b,c,d) | (a,c,d),b | (a,b,d),c
	all together (a,b,c,d)
	
	order does matter here, unlike with partitions
	
	can I start with the partitions and then calculate permutations from there?
		like (a,a,a),a => (a,b,c),d | a,(b,c,d) | (a,c,d),b | (a,b,d),c
		1 becomes 4
	
	can I use set-number like this?
	(a,b,c),d => [1,1,1,2]
	with lowest set number always being first, so that there is no double-counting of (a,b) vs (b,a)
	so the rule would be "first instance of each set-number in array is in ascending order"
	then I find all possible set-number arrays?
		for arrays [1,1,1,1]...[1,2,3,4] count all possible arrangements that follow the rule?
		let's try that	
	"""
	permutation = [1] * n
	number_of_permutations = 1 #starting at 1 for the current permutation, which is valid
	while increment_permutation(n, permutation):
		number_of_permutations = number_of_permutations + 1
	return number_of_permutations
	
def increment_permutation(n, permutation):
	increment_permutation_at_i(0, n, permutation)
	while permutation_is_invalid(permutation):
		increment_permutation_at_i(0, n, permutation)
	return sum(permutation) != len(permutation) # all 1s when we loop back around to the beginning	
	
def increment_permutation_at_i(i, n, permutation):
	if i >= len(permutation):
		return
	permutation[i] = permutation[i] + 1
	if permutation[i] > n:
		permutation[i] = 1
		increment_permutation_at_i(i+1, n, permutation)
	
def permutation_is_invalid(permutation):
	""" returns True if the first-instances of each value are not in ascending order """
	""" also, cannot skip any set-indexes, so need numbers 1..x """
	first_instances = []
	for val in permutation:
		if val not in first_instances:
			if len(first_instances) == 0 and val != 1:
				return True
			if len(first_instances) > 0 and val != first_instances[-1] + 1:
				return True
			first_instances.append(val)
	return False
	
		
	

def main():
	bell_1000 = generate_bell(1000)
	save_as_text_list(bell_1000, 'bell_1_1000')

	bell_10000 = generate_bell(10000)
	save_as_text_list(bell_10000, 'bell_1_10000')
	save_as_javascript_list(bell_10000, 'integers_bell', 'INTS_BELL', ['bell numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
