from utils import save_as_text_list, save_as_javascript_list

def generate_happy(max):
	""" Returns an array of happy numbers from 1 to max """
	if max <= 0:
		raise Exception('generate_happy requires a positive integer')
		
	# 0=undetermined, 1=happy, -1=unhappy
	is_happy = [0 for i in range(100 * max)] # 100x because this sequence goes up and down
	is_happy[0] = -1
	is_happy[1] = 1
	i = 2
	while i <= max:
		if is_happy[i] != 0:
			i = i + 1
			continue
		# get path to a known number
		path = [i]
		x = i
		while True:
			next_x = next_happy(x)
			if next_x in path:
				apply_path(is_happy, path, -1)
				break
			if is_happy[next_x] != 0:
				apply_path(is_happy, path, is_happy[next_x])
				break
			path.append(next_x)
			x = next_x
		i = i +1
		
	return [i for i in range(max+1) if is_happy[i] == 1]
	
def next_happy(n):
	""" Returns next iteration in happy sequence """
	total = 0
	for digit in digits(n):
		total = total + int(digit * digit)
	return total
	
def digits(n):
	""" Returns array of all digits in number n, including zeros and duplicates, as integers """
	if n == 0:
		return [0]

	result = []
	while n > 0:
		result.append(int(n % 10))
		n = (n - (n % 10)) / 10
	result.reverse()
	return result
	
def apply_path(is_happy, path, val):
	for i in path:
		is_happy[i] = val

def main():
	happy_1000 = generate_happy(1000)
	save_as_text_list(happy_1000, 'happy_1_1000')

	happy_10000 = generate_happy(10000)
	save_as_text_list(happy_10000, 'happy_1_10000')
	save_as_javascript_list(happy_10000, 'integers_happy', 'INTS_HAPPY', ['happy numbers 1-10000'], 'w')

if __name__ == "__main__":
    main()
