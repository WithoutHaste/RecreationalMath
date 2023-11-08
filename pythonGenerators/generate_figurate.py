from utils import save_as_text_list, save_as_javascript_list

def generate_triangular(max):
	""" Returns an array of triangular numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_triangular requires a positive integer')

	is_triangular = []
	n = 1
	while True:
		triangular = int(n * (n+1) / 2)
		if triangular > max:
			break
		is_triangular.append(triangular)
		n = n + 1
	
	return is_triangular

def generate_square(max):
	""" Returns an array of square numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_square requires a positive integer')

	is_square = []
	n = 1
	while True:
		square = n * n
		if square > max:
			break
		is_square.append(square)
		n = n + 1
	
	return is_square

def generate_pentagonal(max):
	""" Returns an array of pentagonal numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_pentagonal requires a positive integer')

	is_pentagonal = []
	n = 1
	while True:
		pentagonal = int(n * (3*n - 1) / 2)
		if pentagonal > max:
			break
		is_pentagonal.append(pentagonal)
		n = n + 1
	
	return is_pentagonal

		
	

def main():
	triangular_1000 = generate_triangular(1000)
	save_as_text_list(triangular_1000, 'triangular_1_1000')

	triangular_10000 = generate_triangular(10000)
	save_as_text_list(triangular_10000, 'triangular_1_10000')

	square_1000 = generate_square(1000)
	save_as_text_list(square_1000, 'square_1_1000')

	square_10000 = generate_square(10000)
	save_as_text_list(square_10000, 'square_1_10000')

	pentagonal_1000 = generate_pentagonal(1000)
	save_as_text_list(pentagonal_1000, 'pentagonal_1_1000')

	pentagonal_10000 = generate_pentagonal(10000)
	save_as_text_list(pentagonal_10000, 'pentagonal_1_10000')

	save_as_javascript_list(triangular_10000, 'integers_figurate', 'INTS_TRIANGULAR', ['triangular numbers 1-10000'], 'w')
	save_as_javascript_list(square_10000, 'integers_figurate', 'INTS_SQUARE', ['square numbers 1-10000'], 'a')
	save_as_javascript_list(pentagonal_10000, 'integers_figurate', 'INTS_PENTAGONAL', ['pentagonal numbers 1-10000'], 'a')

if __name__ == "__main__":
    main()
