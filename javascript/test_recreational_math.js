QUnit.test("nextHappySequence: known values", function( assert ) {
    assert.equal(nextHappySequence(0), 0, "0 -> 0" );
    assert.equal(nextHappySequence(1), 1, "1 -> 1" );
    assert.equal(nextHappySequence(2), 4, "2 -> 4" );
    assert.equal(nextHappySequence(10), 1, "10 -> 1" );
    assert.equal(nextHappySequence(32), 13, "32 -> 13" );
    assert.equal(nextHappySequence(36), 45, "36 -> 45" );
    assert.equal(nextHappySequence(37), 58, "37 -> 58" ); //from Numbers Aplenty
    assert.equal(nextHappySequence(89), 145, "89 -> 145" ); //from Numbers Aplenty
    assert.equal(nextHappySequence(145), 42, "145 -> 42" ); //from Numbers Aplenty
});

QUnit.test("nextHappySequence: negative", function( assert ) {
    assert.equal(nextHappySequence(-1), 0, "negative value" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("nextHailstoneSequence: known values", function( assert ) {
    assert.equal(nextHailstoneSequence(0), 0, "0 -> 0" );
    assert.equal(nextHailstoneSequence(1), 4, "1 -> 4" );
    assert.equal(nextHailstoneSequence(2), 1, "2 -> 1" );
    assert.equal(nextHailstoneSequence(3), 10, "3 -> 10" );
    assert.equal(nextHailstoneSequence(4), 2, "4 -> 2" );
    assert.equal(nextHailstoneSequence(16), 8, "16 -> 8" );
    assert.equal(nextHailstoneSequence(17), 52, "17 -> 52" );
    assert.equal(nextHailstoneSequence(100), 50, "100 -> 50" );
    assert.equal(nextHailstoneSequence(105), 316, "105 -> 316" );
});

QUnit.test("nextHailstoneSequence: negative", function( assert ) {
    assert.equal(nextHailstoneSequence(-1), -2, "negative value" );
    assert.equal(nextHailstoneSequence(-2), -1, "negative value" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("isPrimeDivisor: true", function( assert ) {
    assert.ok(isPrimeDivisor(2, 4), "2, 4" );
    assert.ok(isPrimeDivisor(2, 100), "2, 100" );
    assert.ok(isPrimeDivisor(3, 9), "3, 9" );
    assert.ok(isPrimeDivisor(3, 18), "3, 18" );
    assert.ok(isPrimeDivisor(11, 121), "11, 121" );
    assert.ok(isPrimeDivisor(5, 15), "not smallest prime divisor" );
    assert.ok(isPrimeDivisor(5, 1000), "works up to 1000" );
});

QUnit.test("isPrimeDivisor: false", function( assert ) {
    assert.notOk(isPrimeDivisor(1, 4), "not prime or composite" );
    assert.notOk(isPrimeDivisor(4, 16), "not prime" );
    assert.notOk(isPrimeDivisor(3, 4), "not a divisor at all" );
    assert.notOk(isPrimeDivisor(11, 11), "not proper divisor" );
    assert.notOk(isPrimeDivisor(100, 99), "too big" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("getNextPrime: known values", function( assert ) {
    assert.equal(getNextPrime(-1000), 2, "very negative -> lowest prime" );
    assert.equal(getNextPrime(-1), 2, "negative -> lowest prime" );
    assert.equal(getNextPrime(0), 2, "0 -> lowest prime" );
    assert.equal(getNextPrime(1), 2, "1 -> lowest prime" );
    assert.equal(getNextPrime(2), 3, "prime -> next prime" );
    assert.equal(getNextPrime(14), 17, "composite -> next prime" );
    assert.equal(getNextPrime(995), 997, "works for primes below 1000" );
    assert.equal(getNextPrime(997), -1, "too big -> error value" );
    assert.equal(getNextPrime(10000), -1, "too big -> error value" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("areCoprime: true", function( assert ) {
    assert.ok(areCoprime([]), "empty" );
    assert.ok(areCoprime([11]), "single value" );
    assert.ok(areCoprime([11,3]), "two values, both prime" );
    assert.ok(areCoprime([12,121]), "two values, both composite" );
    assert.ok(areCoprime([12,121,479,497]), "four values, some prime, some composite" );
    assert.ok(areCoprime([1000,3]), "works up to 1000" );
});

QUnit.test("areCoprime: false", function( assert ) {
    assert.notOk(areCoprime([11,11]), "duplicate number" );
    assert.notOk(areCoprime([3,15]), "prime and its multiple" );
    assert.notOk(areCoprime([12,15]), "two composites" );
    assert.notOk(areCoprime([12,144]), "composite and its multiple" );
    assert.notOk(areCoprime([12,121,479,497,209]), "five values, only one pair isn't coprime" );
    assert.notOk(areCoprime([12,121,144,498,209]), "five values, many aren't coprime" );
    assert.notOk(areCoprime([1001]), "value out of range" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("isEven: true", function( assert ) {
    assert.ok(isEven(-4), "negative" );
    assert.ok(isEven(0), "0" );
    assert.ok(isEven(2), "2" );
    assert.ok(isEven(10), "10" );
    assert.ok(isEven(384284238), "big number" );
});

QUnit.test("isEven: false", function( assert ) {
    assert.notOk(isEven(-5), "negative" );
    assert.notOk(isEven(1), "1" );
    assert.notOk(isEven(3), "3" );
    assert.notOk(isEven(11), "11" );
    assert.notOk(isEven(384284237), "big number" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("getDigits: known values", function( assert ) {
    assert.ok(arraysMatch(getDigits(0), [0]), "0, keep zeros" );
    assert.ok(arraysMatch(getDigits(3), [3]), "3, single digit" );
    assert.ok(arraysMatch(getDigits(11), [1,1]), "11, duplicate digit" );
    assert.ok(arraysMatch(getDigits(20), [2,0]), "20, keep zeros" );
    assert.ok(arraysMatch(getDigits(9876543210), [9,8,7,6,5,4,3,2,1,0]), "9876543210, all digits" );
});

QUnit.test("getDigits: negative", function( assert ) {
    assert.ok(arraysMatch(getDigits(-1), []), "negative value" );
});

/////////////////////////////////////////////////////////////////////////

QUnit.test("containsDuplicate: true", function( assert ) {
    assert.ok(containsDuplicate([1,1]), "already sorted" );
    assert.ok(containsDuplicate([1,5,1]), "not already sorted" );
    assert.ok(containsDuplicate([0,6,234,8,56,322,234,6,6855,0,11,234]), "multiple duplicates" );
});

QUnit.test("containsDuplicate: false", function( assert ) {
    assert.notOk(containsDuplicate([]), "empty" );
    assert.notOk(containsDuplicate([1,5]), "already sorted" );
    assert.notOk(containsDuplicate([245,4,54755,1,5]), "not already sorted" );
    assert.notOk(containsDuplicate([-1,7,3,99,23423,6,-8,2,1,98]), "many values" );
});

/////////////////////////////////////////////////////////////////////////

//returns TRUE if the two arrays contain the same integers in the same order
function arraysMatch(a, b) {
	if(a.length != b.length) return false;
	for(let i in a) {
		if(a[i] != b[i]) return false;
	}
	return true;
}