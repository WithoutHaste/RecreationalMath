from utils import save_as_text_list, save_as_javascript_list

def generate_perfect_powers(max):
	""" Returns an array of perfect power numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_perfect_powers requires a positive integer')
		
	perfect_powers = [1]
	i = 2
	while i < max:
		power = 2
		total = i**power
		while total <= max:
			perfect_powers.append(total)
			power = power + 1
			total = i**power
		i = i + 1
	perfect_powers = list(set(perfect_powers)) # distinct
	perfect_powers.sort() #sorted
	return perfect_powers
	
def main():
	perfect_powers_1000 = generate_perfect_powers(1000)
	save_as_text_list(perfect_powers_1000, 'perfect_powers_1_1000')

	perfect_powers_10000 = generate_perfect_powers(10000)
	save_as_text_list(perfect_powers_10000, 'perfect_powers_1_10000')
	save_as_javascript_list(perfect_powers_10000, 'integers_perfect_powers', 'INTS_PERFECT_POWERS', ['perfect power numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
