from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits

def generate_magic(max):
	""" Returns an array of magic numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_magic requires a positive integer')
	
	is_magic = []
	n = 1
	while True:
		total = int((pow(n,3) + n)/2)
		if total > max:
			break
		is_magic.append(total)
		n = n + 1
	
	return is_magic
	

def main():
	magic_1000 = generate_magic(1000)
	save_as_text_list(magic_1000, 'magic_1_1000')

	magic_10000 = generate_magic(10000)
	save_as_text_list(magic_10000, 'magic_1_10000')
	save_as_javascript_list(magic_10000, 'integers_magic', 'INTS_magic', ['magic numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
