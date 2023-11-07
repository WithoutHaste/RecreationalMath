from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits

def generate_esthetic(max):
	""" Returns an array of esthetic numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_esthetic requires a positive integer')
		
	is_esthetic = []
	n = 10
	while n <= max:
		d = digits(n)
		success = True
		for i in range(len(d) - 1):
			if d[i] != d[i+1] + 1 and d[i] != d[i+1] - 1:
				success = False
				break
		if success:
			is_esthetic.append(n)
		n = n + 1	
	
	return is_esthetic
	

def main():
	esthetic_1000 = generate_esthetic(1000)
	save_as_text_list(esthetic_1000, 'esthetic_1_1000')

	esthetic_10000 = generate_esthetic(10000)
	save_as_text_list(esthetic_10000, 'esthetic_1_10000')
	save_as_javascript_list(esthetic_10000, 'integers_esthetic', 'INTS_ESTHETIC', ['esthetic numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
