from utils import save_as_text_list, save_as_javascript_list

def generate_hogben(max):
	""" Returns an array of hogben numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_hogben requires a positive integer')
		
	is_hogben = []
	n = 1
	inc = 2
	while n <= max:
		is_hogben.append(n)
		n = n + inc
		inc = inc + 2
	
	return is_hogben
	

def main():
	hogben_1000 = generate_hogben(1000)
	save_as_text_list(hogben_1000, 'hogben_1_1000')

	hogben_10000 = generate_hogben(10000)
	save_as_text_list(hogben_10000, 'hogben_1_10000')
	save_as_javascript_list(hogben_10000, 'integers_hogben', 'INTS_HOGBEN', ['hogben numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
