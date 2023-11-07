from utils import save_as_text_list, save_as_javascript_list

def generate_partitions(max):
	""" Returns an array of partition numbers from 1 to max """

	if max <= 0:
		raise Exception('generate_partitions requires a positive integer')

	is_partition = []
	for n in range(max+1):
		if n < 1:
			continue
		number_of_ways = number_of_ways_n_can_be_partitioned(n)
		if number_of_ways > max:
			break
		is_partition.append(number_of_ways)		
	
	return is_partition
	
def number_of_ways_n_can_be_partitioned(n):
	"""
	can I linearly iterate through all unique possible partitions?
	n = 4, elements = a,a,a,a
	partitions:
	all separate a,a,a,a
	two together (a,a),a,a | (a,a),(a,a)
	three together (a,a,a),a
	all together (a,a,a,a)
	
	since all elements are identical, i don't need to worry about reordering them
	and the sets cannot be nested
	so i just need to place a series of delimiters into the array
	
	could think of this as n = 4
	how many ways can integers sum to 4?
	1+1+1+1 = 4
	1+3 = 3+1 = 4
	2+2 = 4
	1+1+2  = 1+2+1 = 2+1+1 = 4
	4 = 4
	YES!
	how many sets of non-distinct integers (1 to N) sum to N?
	"""
	# one_to_n=[1,2,3] and factors=[0,2,1] means 1*0 + 2*2 + 3*1
	one_to_n = [x+1 for x in range(n)]
	factors = [0] * len(one_to_n)
	number_of_partitions = 0
	while increment_factors(n, factors, one_to_n):
		total = apply_factors_to_ints(factors, one_to_n)
		if total == n:
			number_of_partitions = number_of_partitions + 1
	return number_of_partitions
	
def apply_factors_to_ints(factors, ints):
	total = 0
	for i in range(len(factors)):
		total = total + (factors[i] * ints[i])
	return total
	
def increment_factors(n, factors, ints):
	""" Assumes largest int corresponds to last factor in list """
	""" Therefore, will return False when last factor becomes too large for n, to indicate we can't increment further """
	increment_factor_at_i(0, n, factors, ints)
	total = apply_factors_to_ints(factors, ints)
	return total != 0 # equals 0 when we loop back around to the beginning
	
def increment_factor_at_i(i, n, factors, ints):
	""" Algorithm: operates left to right, incrementing one factor until the resulting total is greater than n """
	if i >= len(factors):
		return
	factors[i] = factors[i] + 1
	total = apply_factors_to_ints(factors, ints)
	if total > n:
		factors[i] = 0
		increment_factor_at_i(i+1, n, factors, ints)
		
	

def main():
	partitions_1000 = generate_partitions(1000)
	save_as_text_list(partitions_1000, 'partition_1_1000')

	partitions_10000 = generate_partitions(10000)
	save_as_text_list(partitions_10000, 'partition_1_10000')
	save_as_javascript_list(partitions_10000, 'integers_partition', 'INTS_PARTITION', ['partition numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
