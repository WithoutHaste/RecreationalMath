from generate_divisors import generate_prime_divisors
from utils import save_as_text_dict, save_as_javascript_dict
import operator


"""
"Friendly Clusters" is a grouping I came up with for a comic
I don't know if this concept already exists under another name, I haven't come across it

The goal was to segment the integers into finite-sized sets
by something less obvious than "contains the same digits in a different order"
"""


def generate_friendly_clusters(max):
	""" Returns an associative array of key=total, value=array of integers where their non-unique prime divisors sum to the total """
	""" From 1 to max, for the integers being categorized. Therefore the clusters might not be complete. """
	""" fast enough as-is for current use cases """
	if max <= 0:
		raise Exception('generate_friendly_clusters requires a positive integer')
		
	prime_divisors = generate_prime_divisors(max);
		
	result = {}
	for i in range(max):
		n = i + 1
		nTotal = sum(prime_divisors[n])
		if nTotal not in result:
			result[nTotal] = []
		result[nTotal].append(n)
	result = dict(sorted(result.items())) #sort by array's key
	return result	
	
	
def main():
	clusters_1000 = generate_friendly_clusters(1000)
	save_as_text_dict(clusters_1000, 'friendly_clusters_1_1000')

	js_comments = [
		'INTS_FRIENDLY_CLUSTERS[n] = array of integers whose non-unique prime factors sum to n',
		'for integers 1-1000',
		'clusters may not be complete, especially for higher n values'
	]
	save_as_javascript_dict(clusters_1000, 'integers_friendly_clusters', 'INTS_FRIENDLY_CLUSTERS', js_comments, 'w')

	clusters_10000 = generate_friendly_clusters(10000)
	save_as_text_dict(clusters_10000, 'friendly_clusters_1_10000')

if __name__ == "__main__":
    main()
