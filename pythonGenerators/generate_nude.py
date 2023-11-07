from utils import save_as_text_list, save_as_javascript_list
from generate_happy import digits

def generate_nude(max):
	""" Returns an array of nude numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_nude requires a positive integer')

	is_nude = []
	for n in range(max+1):
		if n < 1:
			continue
		success = True
		for d in digits(n):
			if d == 0 or (n%d != 0):
				success = False
				break
		if success:
			is_nude.append(n)
	
	return is_nude

	

def main():
	nude_1000 = generate_nude(1000)
	save_as_text_list(nude_1000, 'nude_1_1000')

	nude_10000 = generate_nude(10000)
	save_as_text_list(nude_10000, 'nude_1_10000')
	save_as_javascript_list(nude_10000, 'integers_nude', 'INTS_NUDE', ['nude numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
