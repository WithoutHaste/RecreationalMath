from utils import save_as_text_list, save_as_javascript_list
from generate_divisors import generate_divisors

def generate_practical(max):
	""" Returns an array of practical numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_practical requires a positive integer')
	
	divisors = generate_divisors(max)
	is_practical = [1]
	for n in range(max+1):
		if n <= 1 or n in is_practical:
			continue
		# odd numbers (other than 1) are not practical
		if n%2 == 1:
			continue
		# higher practical numbers are all divisible by 4 or 6
		if n > 6 and not (n%4 == 0 or n%6 == 0):
			continue
		# verify all lower numbers can be written as a sum of your divisors
		if not n_is_practical_by_permutations(n, divisors[n]):
			continue
		# record the result
		is_practical.append(n)
		# the product of two practical numbers is also practical, so can get some easy answers from that
		for previous_n in is_practical:
			multiple = n * previous_n
			if multiple <= max and multiple not in is_practical:
				is_practical.append(multiple)

	is_practical.sort()
	return is_practical
	
def n_is_practical_by_permutations(n, divisors):
	""" Brute force check if n is practical - can all lower positive ints be written as the sum of distict divisors? """
	""" 
	Algorithm:
		take each divisor of n from lowest to highest
		the divisor by itself gives an m value, mark that m True
		then add this divisor to each previous "True" m value and mark the result True as well
			this works because each "True" m value indicates a set of smaller distinct divisors, and this adds one larger divisors to that set
	This will result in all the permutations of the divisors, without needing to enumerate them
	
	credit to https://codereview.stackexchange.com/questions/158142/practical-number-algorithm
	"""
	m_values = [False] * n # represents integers smaller than n, can they be written as the sum of distinct divisors of n?
	m_values[0] = True # ignore m=0
	divisors.sort() # must be least to greatest
	for d in divisors:
		if d >= n:
			continue
		for i in reversed(range(n)): # 0 to n-1, because the sum of lower divisors could already be greater than d
			# going backwards so that d is not summed against to a value it was just summed to
			if i == 0:
				continue # skip 0 since d+0 will be handled later
			if m_values[i]:
				sum = d + i
				if sum < n:
					m_values[sum] = True
		m_values[d] = True # added last so that if the sum of lower divisors totaled d, it would allow setting 2d to True
	return False not in m_values

def increment_and_return_permutation(next_permutation, divisors):
	""" Increments next_permutation """
	""" Then returns the resulting permutation of divisors """
	# increment permutation
	i = len(next_permutation) - 1
	if next_permutation[i] == 0:
		next_permutation[i] = 1
	else:
		while i >= 0 and next_permutation[i] == 1:
			next_permutation[i] = 0
			i = i - 1
		if i >= 0:
			next_permutation[i] = 1
	# get resulting permutation
	result = []
	for i in range(len(divisors)):
		if next_permutation[i] == 1:
			result.append(divisors[i])
	return result
	
def generate_permutations(prefix, elements):
	""" Given a list (treated as a set), return a list of all permutations of the elements """
	""" Order does not matter, just inclusion or exclusion """
	# recurse - for each element, return two options - included or excluded
	if len(elements) == 0:
		return prefix
	if len(elements) == 1:
		return [prefix, prefix + elements]
	with_first = generate_permutations(prefix + elements[0:1], elements[1:])
	without_first = generate_permutations(prefix, elements[1:])
	return with_first + without_first	
	
def generate_sums_to_n(max):
	""" Returns array of arrays, format result[n] = array of arrays of numbers that sum to n (distinct positive integers) """
	if max <= 0:
		raise Exception('generate_sums_to_n requires a positive integer')
	sums_to_n = [[], [[1]], [[2]], [[1,2], [3]]]
	for n in range(max+1):
		if n <= 3:
			continue
		sums_to_n.append([[n]]) #init with identity answer
		for i in range(n): #count up to n-1
			if i == 0:
				continue
			j = n - i
			for a in sums_to_n[i]:
				for b in sums_to_n[j]:
					if has_intersection(a, b):
						continue
					new_set = a + b
					if contains_set(new_set, sums_to_n[n]):
						continue
					sums_to_n[n].append(new_set)
	return sums_to_n
	
def has_intersection(a, b):
	""" Returns true if any element in 'a' also appears in 'b' """
	for element in a:
		if element in b:
			return True
	return False
	
def contains_set(set_a, array_of_sets):
	""" Returns true if set_a is already in array_of_sets """
	for set_b in array_of_sets:
		if set(set_a) == set(set_b):
			return True
	return False

def one_of_these_is_a_subset(possible_subsets, superset):
	""" Returns true if one of these is a subset of the superset """
	for possible_subset in possible_subsets:
		is_subset = True
		for possible_value in possible_subset:
			if possible_value not in superset:
				is_subset = False
		if is_subset:
			return True
	return False
	
	

def main():
	practical_1000 = generate_practical(1000)
	save_as_text_list(practical_1000, 'practical_1_1000')

	practical_10000 = generate_practical(10000)
	save_as_text_list(practical_10000, 'practical_1_10000')
	save_as_javascript_list(practical_10000, 'integers_practical', 'INTS_PRACTICAL', ['practical numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
