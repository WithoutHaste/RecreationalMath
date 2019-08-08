# RecreationalMath

Integer sequence generators and pre-generated values.

## WithoutHaste.Sequences

Targeting .Net 4.0 to use the System.Numerics.BigInteger data type.

**int** upper bound is 2,147,483,647. Array length upper bound is the same. Therefore, pre-generating this number of elements for each sequence.

GitHub has something like a 5mb file size limit, and my projected usage for this data will also have limits to what it can load into memory at one time. Therefore, sequences will be saved in multiple files, named by the range of numbers in the file. Let's start with 500,000 elements per range and see how that does.

Design the pre-generation process so it could be started off fresh, and it would automatically generate everything (eventually). Also to restart in the middle of the process and pick up where it left off.

Using custom extension ".int" for the binary files of integers. No delimiters, just one integer after another.

TODO: rename repository to WithoutHaste.Math  
TODO: rename this solution to WithoutHaste.Math.Sequences  
TODO: will need an object for BigList, that supports BigInteger indexing and handles multiple lists behind the scenes **OR** officially decide and restrict library to only go up to Int32.MaxValue and remove System.Numerics references.
