//returns the next number in the happy sequence
function nextHappySequence(n) {
	const digits = getDigits(n);
	let total = 0;
	for(let d of digits) {
		total = total + (d * d);
	}
	return total;
}

//returns the next number in the Hailstone sequence
function nextHailstoneSequence(n) {
	if(isEven(n)) 
		return n/2;
	return (3 * n) + 1;
}

//returns TRUE if n is a prime divisor of m
//does not count proper divisors
//EXPECTS https://withouthaste.com/javascript/integers_divisors.js
//EXPECTS https://withouthaste.com/javascript/integers_primes.js
function isPrimeDivisor(n, m) {
	if(n >= m)
		return false;
	if(!(m in INTS_DIVISORS))
		return false;
	const properDivisors = INTS_DIVISORS[m];
	if(!properDivisors.includes(n))
		return false;
	if(!INTS_PRIMES.includes(n))
		return false;
	return true;
}

//returns the first prime number greater than n
//EXPECTS https://withouthaste.com/javascript/integers_primes.js
function getNextPrime(n) {
	for(let m of INTS_PRIMES) {
		if(m > n)
			return m;
	}
	return -1;
}

//expects an array of integers
//returns TRUE if all numbers passed in are coprime to all the others
//coprime: the only positive integer that is a divisor of both is 1
//EXPECTS https://withouthaste.com/javascript/integers_divisors.js
function areCoprime(array) {
	let allDivisors = [];
	for(let n of array) {
		if(!(n in INTS_DIVISORS))
			return false;
		allDivisors = allDivisors.concat(INTS_DIVISORS[n]);
	}
	allDivisors = allDivisors.filter((divisor) => { return divisor != 1; });
	return !containsDuplicate(allDivisors);
}

//returns TRUE if n is an even integer
function isEven(n) {
	return (n % 2 == 0);
}

//returns an array of the digits (as integers) in a number
//includes zeros, includes repeats
function getDigits(n) {
	if(n < 0) return [];
	
	let result = [];
	do {
		result.unshift(n % 10);
		n = (n - (n % 10)) / 10;
	} while(n > 0);
	return result;
}

//returns TRUE is there is a duplicate value in array
function containsDuplicate(array) {
	let sorted = array.sort();
	let previous = null;
	for(let value of array) {
		if(value == previous)
			return true;
		previous = value;
	}
	return false;
}
