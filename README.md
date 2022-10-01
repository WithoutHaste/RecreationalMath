# RecreationalMath

Integer sequence generators and pre-generated values.

[List of Composite Numbers from 1 to 10000](ListsOfNumbers/Composite_1_10000.txt)  

[List of Prime Numbers from 1 to 10000](ListsOfNumbers/Prime_1_10000.txt)  
[List of Additive Prime Numbers from 1 to 10000](ListsOfNumbers/Prime_Additive_1_10000.txt)  

[List of Happy Numbers from 1 to 10000](ListsOfNumbers/Happy_1_10000.txt)  
[List of Lucky Numbers from 1 to 10000](ListsOfNumbers/Lucky_1_10000.txt)  
[List of Abundant Numbers from 1 to 10000](ListsOfNumbers/Abundant_1_10000.txt)  
[List of Deficient Numbers from 1 to 10000](ListsOfNumbers/Deficient_1_10000.txt)  
[List of Perfect Numbers from 1 to 10000](ListsOfNumbers/Perfect_1_10000.txt)  
[List of Tau Numbers from 1 to 10000](ListsOfNumbers/Tau_1_10000.txt)  

## WithoutHaste.Sequences

Targeting .Net 4.0 to use the System.Numerics.BigInteger data type.

Design the pre-generation process so it could be started off fresh, and it would automatically generate everything (eventually). Also to restart in the middle of the process and pick up where it left off.

Using custom extension ".int" for the binary files of integers. No delimiters, just one integer after another. Requires about 44% of the space of a text file with end-line delimiters. Also saving plain text file, for quick visual validation.

### Upper Limit

**int** upper bound is 2,147,483,647. Array length upper bound is the same. List indexing upper bound is the same.  
Therefore, accepting Int32.MaxValue as the upper limit of all sequences and calculations in this library.

GitHub has something like a 5mb file size limit, and my projected usage for this data will also have limits to what it can load into memory at one time. Therefore, sequences will be saved in multiple files, named by the range of numbers in the file.  
- Testing 5 million range. For primes (roughly 25% of range is primes) file size is 1.3KB. That looks fine for sequences that are more dense.


TODO: rename repository to WithoutHaste.Math  
TODO: rename this solution to WithoutHaste.Math.Sequences  
TODO: how to make use Max+? operations don't overflow Int32? comes up in various sequences that need more primes then they themselves contain
TODO: emirp prime: how to verify big-number primes are emirp or not if the reversed number is beyond the edge of the prime list? beyond int max?
TODO: highly cototient: verify why kxk is the upper limit of the search, and understand why
TODO: rename Prime classes to say Prime first, for file sorting
