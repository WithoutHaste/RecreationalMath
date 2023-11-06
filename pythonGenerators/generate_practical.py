from utils import save_as_text_list, save_as_javascript_list
from generate_divisors import generate_divisors

def generate_practical(max):
	""" Returns an array of practical numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_practical requires a positive integer')
	
	divisors = generate_divisors(max)
	sums_to_n = []
	for n in range(max+1):
		sums_to_n.append([])
	is_practical = [1]
	for n in range(max+1):
		print("n = " + str(n))
		if n <= 1 or n in is_practical:
			continue
		# odd numbers (other than 1) are not practical
		if n%2 == 1:
			continue
		# higher practical numbers are all divisible by 4 or 6
		if n > 6 and not (n%4 == 0 or n%6 == 0):
			continue
		n_is_practical = True
		next_permutation = [0] * len(divisors[n]) # index corresponds to i-th divisor, value 1 means include it in the sum
		# verify all lower numbers can be written as a sum of your divisors
		for m in range(n):
			if m <= 1:
				continue
			# already know how to use n's divisors to sum to m	
			if one_of_these_is_a_subset(sums_to_n[m], divisors[n]):
				continue
			# check the permutations of divisors for new sums
			permutation_loop_succeeded = False
			while 0 in next_permutation:
				permutation = increment_and_return_permutation(next_permutation, divisors[n])
				total = sum(permutation)
				if total <= max and not contains_set(permutation, sums_to_n[total]):
					sums_to_n[total].append(permutation)
				if total == m:
					permutation_loop_succeeded = True
					break
			if permutation_loop_succeeded:
				continue
			n_is_practical = False
			break # one failure is enough to exit the loop
		# record the result
		if n_is_practical:
			is_practical.append(n)
			# the product of two practical numbers is also practical, so can get some easy answers from that
			for previous_n in is_practical:
				multiple = n * previous_n
				if multiple <= max and multiple not in is_practical:
					is_practical.append(multiple)

	is_practical.sort()
	return is_practical
			
def generate_practical_slow(max):
	""" Returns an array of practical numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_practical requires a positive integer')
	
	sums_to_n = generate_sums_to_n(max)
	divisors = generate_divisors(max)
	is_practical = [1]
	for n in range(max+1):
		if n <= 1 or n in is_practical:
			continue
		n_is_practical = True
		for m in range(n): #check all smaller numbers
			if m <= 1:
				continue
			if not one_of_these_is_a_subset(sums_to_n[m], divisors[n]):
				n_is_practical = False
		if n_is_practical:
			is_practical.append(n)
			# the product of two practical numbers is also practical, so can get some easy answers from that
			for previous_n in is_practical:
				multiple = n * previous_n
				if multiple <= max and multiple not in is_practical:
					is_practical.append(multiple)					

	is_practical.sort()
	return is_practical

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
