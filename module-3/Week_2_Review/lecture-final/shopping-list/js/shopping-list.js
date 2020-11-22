let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

let listItems;
let toggleAllBtn;

const COMPLETED = 'completed';

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById('title');
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ul = document.querySelector('ul');
  groceries.forEach((item) => {
    const li = document.createElement('li');
    li.innerText = item.name;
    const checkCircle = document.createElement('i');
    checkCircle.setAttribute('class', 'far fa-check-circle');
    li.appendChild(checkCircle);
    ul.appendChild(li);
  });
}

document.addEventListener('DOMContentLoaded', () => {
      
  setPageTitle();
  displayGroceries();

  initListItemListeners();

  initToggleAllBtn();

})

function markItemComplete(item) {
  if (!item.classList.contains(COMPLETED)) {
    item.classList.add(COMPLETED);
  }
}

function markItemIncomplete(item) {
  if (item.classList.contains(COMPLETED)) {
    item.classList.remove(COMPLETED);
  }
}

function initListItemListeners() {
  listItems = document.querySelectorAll('li');
  listItems.forEach( (listItem) => {
    listItem.addEventListener('click', (event) => {
      markItemComplete(event.currentTarget);
    });

    listItem.addEventListener('dblclick', (event) => {
      markItemIncomplete(event.currentTarget);
    });
  });
}

function toggleAll() {
  if (allItemsIncomplete) {
    listItems.forEach(markItemComplete);
  } else {
    listItems.forEach(markItemIncomplete);
  }

  toggleAllBtn.innerText = allItemsIncomplete ? 'Mark All Incomplete' : 'Mark All Complete';

  allItemsIncomplete = !allItemsIncomplete;
}

function initToggleAllBtn() {
  toggleAllBtn = document.getElementById('toggleAll');
  toggleAllBtn.addEventListener('click', toggleAll);
}


/********************** FROM REVIEW SECTION **********************/

function testStringInterpolation() {
  const num = 6;
  console.log(`Here is our text ${num}`);
}

function testSubString(myparam = []) {
  const myString = 'The quick brown fox etc.';

  // substring/slice: startb / stop
  console.log(myString.substring(4, 6));
  console.log(myString.slice(4, 6));

  // substr start/number of chars
  console.log(myString.substr(4, 6));

  // look up string.splice (not necessarily start or end)

}