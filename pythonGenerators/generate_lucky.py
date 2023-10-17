from utils import save_as_text_list, save_as_javascript_list

def generate_lucky(max):
	""" Returns an array of lucky numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_lucky requires a positive integer')
		
	is_lucky = [True for i in range(max+1)]
	is_lucky[0] = False
	is_lucky[1] = True
	# even numbers are all unlucky
	i = 2
	while i < len(is_lucky):
		is_lucky[i] = False
		i = i + 2
	# apply sieve
	next_lucky = 3
	while True:
		apply_next_lucky(is_lucky, next_lucky)
		next_lucky = increment_to_next_lucky(is_lucky, next_lucky)
		if next_lucky == -1 or next_lucky >= len(is_lucky):
			break
			
	return [i for i in range(len(is_lucky)) if is_lucky[i]]

def apply_next_lucky(is_lucky, n):
	i = 0
	while i < len(is_lucky):
		count_lucky = 0
		while count_lucky < n:
			i = i + 1
			if i >= len(is_lucky):
				break
			if is_lucky[i]:
				count_lucky = count_lucky + 1
		if i < len(is_lucky) and i != n:
			is_lucky[i] = False
		
def increment_to_next_lucky(is_lucky, n):
	while True:
		n = n + 1
		if n >= len(is_lucky):
			return -1
		if is_lucky[n]:
			return n
	return -1

def main():
	lucky_1000 = generate_lucky(1000)
	save_as_text_list(lucky_1000, 'lucky_1_1000')

	lucky_10000 = generate_lucky(10000)
	save_as_text_list(lucky_10000, 'lucky_1_10000')
	save_as_javascript_list(lucky_10000, 'integers_lucky', 'INTS_LUCKY', ['lucky numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
