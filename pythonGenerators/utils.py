# I/O operations

def save_as_text(numbers, filename):
	""" numbers: array of integers """
	""" filename: do not include path or extension """
	with open('../text/' + filename + '.txt', 'w') as file:
		for n in numbers:
			file.write(str(n) + '\n')
