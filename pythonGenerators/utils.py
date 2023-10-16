# I/O operations

def save_as_text(numbers, filename):
	""" numbers: array of integers """
	""" filename: do not include path or extension """
	with open('../text/' + filename + '.txt', 'w') as file:
		for n in numbers:
			file.write(str(n) + '\n')


def save_as_javascript(numbers, filename, variable_name, comments, write_or_append):
	""" numbers: array of integers """
	""" filename: do not include path or extension """
	""" variable_name: the name for this array in javascript """
	""" comments: javascript comment line for this variable """
	""" write_or_append: 'w' for overwrite, 'a' for append """
	with open('../javascript/' + filename + '.js', write_or_append) as file:
		file.write('//' + comments + '\n');
		file.write('const ' + variable_name.upper() + ' = [\n');
		str_numbers = [str(i) for i in numbers]
		file.write('\t' + ', '.join(str_numbers) + '\n');
		file.write('];');
		file.write('\n\n') # leave space in case another variable is appended
