/**
 * All named functions will have the function keyword and
 * a name followed by parentheses.
 * 
 * @returns {number} 1
 */
function returnOne() {
  return 1;
}

/**
 * Functions can also take parameters. These are just variables that are filled
 * in by whoever is calling the function.
 *
 * Also, we don't *have* to return anything from the actual function.
 *
 * @param {any} value the value to print to the console
 */
function printToConsole(value) {
  console.log(value);
}

/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
function multiplyTogether(firstParameter, secondParameter) {
  return firstParameter * secondParameter;
}

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=0] the second parameter to multiply
 */
function multiplyNoUndefined(firstParameter = 0, secondParameter = 0) {
  return firstParameter * secondParameter;
}

 
/**
 * Functions can return earlier before the end of the function. This could be useful
 * in circumstances where you may not need to perform additional instructions or have to
 * handle a particular situation.
 * In this example, if the firstParameter is equal to 0, we return secondParameter times 2.
 * Observe what's printed to the console in both situations.
 * 
 * @param {number} firstParameter the first parameter
 * @param {number} secondParameter the second parameter
 */
function returnBeforeEnd(firstParameter, secondParameter) {
  console.log("This will always fire.");

  if (firstParameter == 0) {
    console.log("Returning secondParameter times two.");
    return secondParameter * 2;
  }

  //this only runs if firstParameter is NOT 0
  console.log("Returning firstParameter + secondParameter.");
  return firstParameter + secondParameter;
}

/**
 * Scope is defined as where a variable is available to be used.
 *
 * If a variable is declare inside of a block, it will only exist in
 * that block and any block underneath it. Once the block that the
 * variable was defined in ends, the variable disappears.
 */
function scopeTest() {
  // This variable will always be in scope in this function
  let inScopeInScopeTest = true;

  {
    // this variable lives inside this block and doesn't
    // exist outside of the block
    let scopedToBlock = inScopeInScopeTest;
  }

  // scopedToBlock doesn't exist here so an error will be thrown
  if (inScopeInScopeTest && scopedToBlock) {
    console.log("This won't print!");
  }
}


/**
 * Example of using arguments variable
 */
function concatAll() {
  // No parameters defined,but we still might get some
  // can use arguments variables to access params passed in
  let result = '';
  for(let i = 0; i < arguments.length; i++) {
      result += arguments[i];
  }
  return result;
}

function multipleParams(myParam) {
  if (arguments.length > 1) {
    console.log('multiple parameters');
  } else {
    console.log(myParam);
  }
}

/**
 * 
 * Generates string with the user's name, age, and quirks
 * 
 * @param {string} name 
 * @param {integer} age 
 * @param {string[]} listOfQuirks the list of the user's quirks
 * @param {string} separator - defaults to ,
 * @returns {string} returns a string with the user's name, age, and quirks
 */
function createSentenceFromUser(name, age, listOfQuirks = [], separator = ', ') {
  let description = `${name} is currently ${age} years old. Their quirks are: `;
  return description + listOfQuirks.join(separator);
}



/**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {
  // let filterFunc = (num) => { return num % 3 === 0} ;
  // return numbersToFilter.filter(filterFunc);

  // use anonymous method
  // return numbersToFilter.filter( (num) => { return num % 3 === 0 });

  // definte external function to use
  return numbersToFilter.filter( (num) => filterDivisbileByThree(num));
}

function filterDivisbileByThree(num) {
  return num % 3 === 0;
}

/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  return numbersToSum.reduce( (accumulator, curVal) => { return accumulator
    + curVal} );
}

/**
 * Returns the decimal percentage equivalents of numbers in array
 * 
 * @param {integer} numsArray 
 * @returns {number[]} array of values divided by 100
 */
function mapToPercent(numsArray) {
    return numsArray.map( (value) => { return value / 100} );
}

/**
 * 
 * Checks if all elements of an array are even
 * 
 * @param {number[]} numArray 
 * @returns {boolean} true if all elements are even; false otherwise
 */
function areAllEven(numArray) {
  // return numArray.every( (value) => { return (value % 2 === 0)}  );

  // use external function (defined below)
  return numArray.every( (value) =>  isEven(value) );
}

/**
 * 
 * Checks if any elements of an array are even
 * 
 * @param {number[]} numArray 
 * @returns {boolean} true if any elements are even; false otherwise
 */
function areSomeEven(numArray) {
  return numArray.some( (value) => isEven(value) ) ;
}

/**
 * 
 * Check if a value is evem
 * 
 * @param {number} value 
 * @returns true if value is even; false otherwise
 */
function isEven(value) {
  return value % 2 === 0;
}

/**
 * 
 * Outputs all elements of an array
 * 
 * @param {[]} inputArray 
 */
function dumpArray(inputArray) {
  inputArray.forEach(  (inputValue) => { console.log(inputValue)});
}

/**
 * 
 * Sorts number array in ascending order
 * 
 * @param {number[]} numArray 
 * @requires {number[]} sorted array
 */
function sortNumArray(numArray) {
  return numArray.sort( (val1, val2) => {
    if (val1 > val2) {
      return 1;
    } else if (val2 > val1) {
      return -1;
    } else {
      return 0;
    }
  } );
}

/**
 * 
 * Sorts number array in descending order
 * 
 * @param {number[]} numArray 
 * @requires {number[]} sorted array
 */
function sortNumArrayDescending(numArray) {
  return numArray.sort( (val1, val2) => {
    if (val1 > val2) {
      return -1;
    } else if (val2 > val1) {
      return 1;
    } else {
      return 0;
    }
  } );
}

/**
 * 
 *  Sorts string array in ascending order. Ignores case
 * 
 * @param {string[]} stringArray 
 * @returns {string[]} sorted array
 */
function sortStrings(stringArray) {
  return stringArray.sort( (val1, val2) => {
    if (val1.toLowerCase() > val2.toLowerCase()) {
      return 1;
    } else if (val2 > val1) {
      return -1;
    } else {
      return 0;
    }
  })
}

/* 
  Array functions documentation:
  https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array

  Lots of extra info on sorts including alpha sorts:
  https://www.javascripttutorial.net/javascript-array-sort/
*/