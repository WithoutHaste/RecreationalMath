from utils import save_as_text_dict, save_as_javascript_dict
from generate_primes import generate_primes

def generate_goldbach_conjecture(max):
	""" Returns an dict of equations for goldbach's conjecture for even numbers from 4 to max """
	""" The key of the dict is the number N, and the value is a list of 2 primes that sum to N """
	if max <= 0:
		raise Exception('generate_goldbach_conjecture requires a positive integer')

	primes = generate_primes(max)
	equations = {}
	for n in range(max+1):
		result = find_primes(n, primes)
		if result == None:
			continue
		equations[n] = result
	
	return equations
	
def find_primes(n, primes):
	""" Returns list of 2 primes that sum to n """
	if n < 4 or n%2 == 1:
		return None
	for p in primes:
		if n-p in primes:
			return [p, n-p]
	return None #should not reach this		

	

def main():
	goldbach_conjecture_1000 = generate_goldbach_conjecture(1000)
	save_as_text_dict(goldbach_conjecture_1000, 'goldbach_conjecture_1_1000')
	js_comments = [
		'INTS_GOLDBACH_CONJECTURE[n] = array of two primes that sum to n',
		'for integers 1-1000',
		'these are not the only possible solutions',
	]
	save_as_javascript_dict(goldbach_conjecture_1000, 'integers_goldbach_conjecture', 'INTS_GOLDBACH_CONJECTURE', js_comments, 'w')

	goldbach_conjecture_10000 = generate_goldbach_conjecture(10000)
	save_as_text_dict(goldbach_conjecture_10000, 'goldbach_conjecture_1_10000')
	

if __name__ == "__main__":
    main()
