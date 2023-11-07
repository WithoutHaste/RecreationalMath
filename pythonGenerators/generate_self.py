from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits

def generate_self(max):
	""" Returns an array of self numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_self requires a positive integer')
		
	is_self = [True] * (max+1)
	for n in range(max+1):
		d = digits(n)
		total = n + sum(d)
		if total <= max:
			is_self[total] = False
	
	return [ind for ind, x in enumerate(is_self) if x is True]
	

def main():
	self_1000 = generate_self(1000)
	save_as_text_list(self_1000, 'self_1_1000')

	self_10000 = generate_self(10000)
	save_as_text_list(self_10000, 'self_1_10000')
	save_as_javascript_list(self_10000, 'integers_self', 'INTS_SELF', ['self numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
