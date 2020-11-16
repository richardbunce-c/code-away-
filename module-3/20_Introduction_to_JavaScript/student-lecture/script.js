/*
    Example of a multi-line comment just like in C#/Java
*/

// Single line comment

/**
 * Functions start with the word function.
 * They don't have a return type and the naming convention is camel-case.
 */
function variables() {
  
  // Declares a variable those value can be changed
let myText = "Hello World!";

console.log(myText);

myText="Hi world!";
console.log(myText);
  // declare without initializing
let mySecondText;

mySecondText="hi again";
console.log(mySecondText);

  // Declares a variable where the value cannot be changed
const MY_CONST_TEXT='hell const world';
  
  // cannot assign new value to const - will throw Exception
   MY_CONST_TEXT = 'Howdy const world!';

  // cannot declare const without initializing
  const MY_NEW_CONST_TEXT;


  // Declares a variable that will always be an array
  const MY_CONST_ARRAY=[
    'hi',
    'there',
    'folks'
  ];
  console.table(MY_CONST_ARRAY);
}

/**
 * Functions can also accept parameters.
 * Notice the parameters do not have types.
 * @param {Number} param1 The first number to display
 * @param {Number} param2 The second number to display
 */
function printParameters(param1, param2) {
  console.log(`The value of param1 is ${param1}`);
  console.log(`The value of param2 is ${param2}`);
}

/**
 * Compares two values x and y.
 * == is loose equality
 * === is strict equality
 * @param {Object} x
 * @param {Object} y
 */
function equality(x, y) {
  console.log(`x is ${typeof x}`);
  console.log(`y is ${typeof y}`);

  console.log(`x == y : ${x == y}`); // true
  console.log(`x === y : ${x === y}`); // false
}

/**
 * Each value is inherently truthy or falsy.
 * false, 0, '', null, undefined, and NaN are always falsy
 * everything else is always truthy
 * @param {Object} x The object to check for truthy or falsy,
 */
function falsy(x) {
  if (x) {
    console.log(`${x} is truthy`);
  } else {
    console.log(`${x} is falsy`);
  }
}

/**
 * Ecamples of if/else if/else and switch
 * 
 * @param {*} val 
 */
function branchingExample(val)  {
  if (val == 'if') {
    console.log('if');
  } else if (val == 'else if') {
    console.log('else if');
  } else {
    console.log('else');
  }

  switch (val) {
    case 'if':
      console.log('switch => if');
      break;
    case 'else if':
      console.log('switch => else if');
      break;
    default:
      console.log('switch => else');

  }
}

/**
 * outer variable available in inner scope
 * 
 */
function nestedBlockScopeExample() {
  let outer = 'outer';

  if (outer == 'outer') {
    let inner = 'inner';

    // variables defined within a nested block will have
    // access to outer block scope variables

  }

  // outer scope will NOT have access to nested block variables

}



/**
 * shadowing outer scope variable in inner scope
 */
function nestedBlockShadowingScopeExample() {
  let outer = 'outer';

  console.log('outer...');
  console.log('outer: ' + outer);

  if (outer == 'outer') {
    // can declare variable with same name in inner scope
    // but it will "shadow" original variable - this should be avoided

  }
  
}

/**
 * pushing and popping to/from an array
 */
function pushPop() {
  let theArray = ['A', 'B'];

  console.log('Before push:')
  console.table(theArray);

  //  can add an element on to the end of an array using push

  //  can remove ;ast elemnt from array nd return it using pop


}

/**
 * unshifting and shifting to/from array
 */
function unshiftShift() {
  let theArray = ['A', 'B'];

  console.log('Before unshift:')
  console.table(theArray);
  //  can add an element before the beginning of an array using unshift

  //  can remove first element from array nd return it using shift


}


/**
 * array includes a value
 */
function includesExample() {
  let theArray = [1, 2, 3, 4, 5];

  // the array method includes can be used to check if an array contains a value
}


/**
 * indexOf value in array
 */
function indexOfExample() {
  let theArray = ['one', 'two', 'three', 'two', 'six'];

  // the array method indexOf can be used to find first index
  // if of a value ins an array

  // if the item is not found, indexOf returns -1
}

/**
 * lastIndexOf value in array
 */
function lastIndexOfExample() {
  let theArray = ['one', 'two', 'three', 'two', 'six'];

  // the array method lastIndexOf can be used to find last index
  // if of a value ins an array

  // if the item is not found, lastIndexOf returns -1
}


/**
 *  Objects are simple key-value pairs
    - values can be primitive data types
    - values can be arrays
    - or they can be functions
*/
function objects() {
  const person = {
    firstName: "Bill",
    lastName: "Lumbergh",
    age: 42,
    employees: [
      "Peter Gibbons",
      "Milton Waddams",
      "Samir Nagheenanajar",
      "Michael Bolton"
    ]
  };

  // Log the object
console.log(person);
  // Log the first and last name
console.log(`${person.firstName} ${person.lastName}`)
  // Log each employee
  console.table(person.employees);

  //with loop
  for(let i =0; i>person.employees.length; i++){
    console.log(person.employees[i]);
  }
}

/*
########################
Function Overloading
########################

Function Overloading is not available in Javascript. If you declare a
function with the same name, more than one time in a script file, the
earlier ones are overriden and the most recent one will be used.
*/

function Add(num1, num2) {
  return num1 + num2;
}

function Add(num1, num2, num3) {
  return num1 + num2 + num3;
}

/*
########################
Math Library
########################

A built-in `Math` object has properties and methods for mathematical constants and functions.
*/

function mathFunctions() {
  console.log("Math.PI : " + Math.PI);
  console.log("Math.LOG10E : " + Math.LOG10E);
  console.log("Math.abs(-10) : " + Math.abs(-10));
  console.log("Math.floor(1.99) : " + Math.floor(1.99));
  console.log("Math.ceil(1.01) : " + Math.ceil(1.01));
  console.log("Math.random() : " + Math.random());
}

/*
########################
String Methods
########################

The string data type has a lot of properties and methods similar to strings in Java/C#
*/

function stringFunctions(value) {
  console.log(`.length -  ${value.length}`);
  console.log(`.endsWith('World') - ${value.endsWith("World")}`);
  console.log(`.startsWith('Hello') - ${value.startsWith("Hello")}`);
  console.log(`.indexOf('Hello') - ${value.indexOf("Hello")}`);

  /*
    Other Methods
        - split(string)
        - substr(number, number)
        - substring(number, number)
        - toLowerCase()
        - trim()
        - https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String
    */
}
