# I/O operations

def save_as_text_list(numbers, filename):
	""" numbers: array of integers """
	""" filename: do not include path or extension """
	with open('../text/' + filename + '.txt', 'w') as file:
		for n in numbers:
			file.write(str(n) + '\n')


def save_as_text_list_of_lists(numbers, filename):
	""" numbers: array of array of integers """
	""" filename: do not include path or extension """
	with open('../text/' + filename + '.txt', 'w') as file:
		for n in numbers:
			str_numbers = [str(i) for i in n]
			file.write(', '.join(str_numbers) + '\n')


def save_as_text_dict(numbers_dict, filename):
	""" numbers: dict of arrays of integers """
	""" filename: do not include path or extension """
	with open('../text/' + filename + '.txt', 'w') as file:
		for key in numbers_dict:
			str_numbers = [str(i) for i in numbers_dict[key]]
			file.write(str(key) + ': ' + ', '.join(str_numbers) + '\n')


def save_as_javascript_list(numbers, filename, variable_name, comments, write_or_append):
	""" numbers: array of integers """
	""" filename: do not include path or extension """
	""" variable_name: the name for this array in javascript """
	""" comments: arrau of javascript comment line for this variable """
	""" write_or_append: 'w' for overwrite, 'a' for append """
	with open('../javascript/' + filename + '.js', write_or_append) as file:
		for comment in comments:
			file.write('//' + comment + '\n');
		file.write('const ' + variable_name.upper() + ' = [\n');
		str_numbers = [str(i) for i in numbers]
		file.write('\t' + ', '.join(str_numbers) + '\n');
		file.write('];');
		file.write('\n\n') # leave space in case another variable is appended


def save_as_javascript_list_of_lists(numbers, filename, variable_name, comments, write_or_append):
	""" numbers: array of array of integers """
	""" filename: do not include path or extension """
	""" variable_name: the name for this array in javascript """
	""" comments: arrau of javascript comment line for this variable """
	""" write_or_append: 'w' for overwrite, 'a' for append """
	with open('../javascript/' + filename + '.js', write_or_append) as file:
		for comment in comments:
			file.write('//' + comment + '\n');
		file.write('const ' + variable_name.upper() + ' = [\n\t');
		for n in numbers:
			str_numbers = [str(i) for i in n]
			file.write('[' + ', '.join(str_numbers) + '], ');
		file.write('\n];');
		file.write('\n\n') # leave space in case another variable is appended


def save_as_javascript_dict(numbers_dict, filename, variable_name, comments, write_or_append):
	""" numbers_dict: dictionary of arrays of integers """
	""" filename: do not include path or extension """
	""" variable_name: the name for this array in javascript """
	""" comments: arrau of javascript comment line for this variable """
	""" write_or_append: 'w' for overwrite, 'a' for append """
	with open('../javascript/' + filename + '.js', write_or_append) as file:
		for comment in comments:
			file.write('//' + comment + '\n');
		file.write('const ' + variable_name.upper() + ' = {\n');
		for key in numbers_dict:
			str_numbers = [str(i) for i in numbers_dict[key]]
			file.write('\t' + str(key) + ': [' + ', '.join(str_numbers) + '],\n');
		file.write('};');
		file.write('\n\n') # leave space in case another variable is appended
