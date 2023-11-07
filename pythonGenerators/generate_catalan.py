from utils import save_as_text_list, save_as_javascript_list
from math import factorial

def generate_catalan(max):
	""" Returns an array of catalan numbers from 1 to max """

	if max <= 0:
		raise Exception('generate_catalan requires a positive integer')

	is_catalan = []
	n = 1
	while True:
		total = int(factorial(2*n) / (factorial(n) * factorial(n+1)))
		if total > max:
			break
		is_catalan.append(total)
		n = n + 1
	
	return is_catalan
		
	

def main():
	catalan_1000 = generate_catalan(1000)
	save_as_text_list(catalan_1000, 'catalan_1_1000')

	catalan_10000 = generate_catalan(10000)
	save_as_text_list(catalan_10000, 'catalan_1_10000')
	save_as_javascript_list(catalan_10000, 'integers_catalan', 'INTS_CATALAN', ['catalan numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
