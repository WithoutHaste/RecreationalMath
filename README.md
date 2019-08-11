# RecreationalMath

Integer sequence generators and pre-generated values.

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
TODO: primes - load pre-generated into list, if it doesn't reach max just discard that and to the whole sieve over again - don't think I'm getting a speed benefit as is - therefore don't allocate memory for sieve until numbers are pre-loaded
TODO: how to make use Max+? operations don't overflow Int32? comes up in various sequences that need more primes then they themselves contain
