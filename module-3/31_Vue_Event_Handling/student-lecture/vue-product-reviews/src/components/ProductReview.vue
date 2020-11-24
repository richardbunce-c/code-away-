<!--
Features to add:
  TODO 01: Allow the user to click on a Well to display only those reviews with a particular rating
        *Create some sort of filter variable
        *Create a computed filteredReviews list
        *Change the v-for to loop through the new filteredReviews property
        *Listen for the click event on a well, and change the filter variable

  TODO 02: Give a visual indication of which filter is being applied
      *Create a class to apply a special style to the selected well
      *On the Well element, bind to the class^^ if the filterValue matches this well

  TODO 03: Provide a form to allow the user to add a new review
      *Create an object in data() to hold values for a New review to be added
      *Create a form to display the new review and accept user input values
      *When user presses "Add" button, add the new review to the reviews array
      *When the user presses Cancel, clear the form

  TODO 04: Show and hide the AddReview form as appropriate
      *Create a data() variable to track whether the form should be visible
      *Show the form only when the variable  ^^ is true
      *Add a link to show the form
      *On Add, after the review has been added, hide the form
      *On Cancel, after clearing the form, hide the form
-->
<template>
  <div class="main">
    <h1>Product reviews for {{ title }}</h1>
    <p class="description">{{ description }}</p>
    <p>{{ message }}</p>

    <div>
      <label>Title </label>
      <input type="text" v-model="title" />
    </div>
    <div>
      <label>Description </label>
      <input type="text" v-model.lazy="description" />
    </div>

    <!-- TODO 01D: Set the filter when the user clicks on the display -->
    <!-- TODO 02B: Mark which rating is selected -->
    <div class="well-display">
      <div class="well" v-on:click="changeFilter(0)" v-bind:class="{well: true, selectedFIlter: filterValue === 0}">
        <span class="amount">
          {{ averageRating }}
        </span>
        Average Rating
      </div>

      <div class="well" v-for="i in 5" v-bind:key="i" v-on:click="filterValue = (i)" v-bind:class="{selectedFIlter: filterValue === i}">
        <span class="amount">
          {{nStarReviews(i)}}
        </span>
        {{i}}-star reviews
      </div>
    </div>

    <!-- TODO 04C: Add a link to show or hide the form -->

    <!-- TODO 03B: Create the form that allows the user to add a new review -->
    <a id="showHide" href="#" v-on:click.prevent="showForm =true">Add a new review</a>
<form v-on:submit.prevent="addReview" v-show="showForm">
  <div class="error">{{newReviewError}}</div>
  <!-- Reviewer -->
  <div class= "form-element">
    <label for="reviewer">Reviewer Name:</label>
    <input type="text" id="reviewer" v-model="newReview.reviewer" />
  </div>
    <div class= "form-element">
    <label for="title">Title:</label>
    <input type="text" id="title" v-model="newReview.title" />
  </div>
    <div class= "form-element">
    <label for="number">Rating:</label>
    <input type="text" id="rating" v-model.number="newReview.rating" min="1" max="5" />
  </div>
    <div class= "form-element">
    <label for="review">Review:</label>
    <textarea id="review" v-model="newReview.review" />
  </div>
  <input type="submit" value="Save Review" :disabled="newReviewError.length > 0"/>
  <input type="button" value="Cancel" @click="resetReview" />
</form>

    <!-- TODO 04B: Only show the form of the showForm variable is set -->

    <!-- Display each review in a loop -->
    <!-- TODO 01C: Display the filteredReviews array instead of the raw data -->
    <div class="review" v-for="rev in filteredReviews" v-bind:key="rev.id" v-bind:class="{favorite: rev.favorite}">
      <h4>{{ rev.reviewer }}</h4>
      <div class="rating">
        <img
          src="../assets/star.png"
          class="ratingStar"
          v-for="n in rev.rating"
          v-bind:key="n"
        />
      </div>
      <h3>{{ rev.title }}</h3>
      <p>{{ rev.review }}</p>
      <p>
          Favorite?
          <input type="checkbox" v-model="rev.favorite" />
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: "product-view",
  props: {
    message: String,
  },
  data() {
    return {
      title: "Cigar parties for dummies",
      description: "Host a party for all your really squirrelly friends!",

      // TODO 01A: Create a variable to hold the current ratings Filter value
      filterValue: 0,

      // TODO 03A: Create a new, empty review object for adding new reviews.
      newReview: {},
      // TODO 04A: Create a variable to store whether the Add Review form should be visible
      showForm: false,

      reviews: [
        {
          id: 1,
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
          rating: 3,
          favorite: false
        },
        {
          id: 2,
          reviewer: "Craig Castelaz",
          title: "Better than a swift kick in the butt!",
          review: "My bar is low.",
          rating: 4,
          favorite: false
        },
        {
          id: 3,
          reviewer: "Ed",
          title: "Better than Cats",
          review: "I loved it.  It was great.  It was better than CAts.",
          rating: 2,
          favorite: false
        },
        {
          id: 4,
          reviewer: "Lace",
          title: "It's no FizzBuzz",
          review:
            "Not the most constructive how-to. I think the author may be nuts.",
          rating: 2,
          favorite: false
        },
        {
          id: 5,
          reviewer: "Joe",
          title: "Pick up the pace",
          review: "Like War and Peace, but much slower.",
          rating: 5,
          favorite: false
        },
        {
          id: 6,
          reviewer: "Max",
          title: "Dummy",
          review: "The writer needs to read a 'writing for dummies' book.",
          rating: 1,
          favorite: false
        },
            {
          id: 7,
          reviewer: "Keith",
          title: "Yum!",
          review: "Great recipes in this one.",
          rating: 4,
          favorite: false
        },
               {
          id: 8,
          reviewer: "William",
          title: "Not so much",
          review: "This book could have been better.",
          rating: 1,
          favorite: false
        },
                     {
          id: 9,
          reviewer: "Ricky Bobby",
          title: "If you're not first your last",
          review: "This book pissed excellence.",
          rating: 5,
          favorite: true
        }
      ],



    };
  },
  computed: {
    averageRating() {
      // Calculate the average of all review ratings.
      let sumRatings = 0;

      // loop thru reviews and add up all the ratings
      this.reviews.forEach((r) => {
        sumRatings += r.rating;
      });

      // Calculate average by dividing by number of reviews
      return (sumRatings / this.reviews.length).toFixed(2);
    },
    // TODO 01B: Add a computed property filteredReviews to return the reviews to be displayed
    filteredReviews(){
      //This function filters the "raw" array and returns the subset/filtered array
      return this.reviews.filter( (r) => {
        return this. filtervalue === 0 || r.rating === this.filterValue;
      });
    },
    newReviewError(){
      if ( this.newReview.reviewer && this.reviews.review && this.reviews.rating && this.reviews.rating && this.review.title){
        return '';
      } else {
        return 'Please make sure all fields are filled in';
      }
    }
  },
  methods: {
    nStarReviews(n) {
        return this.reviews.filter( r =>{
            return r.rating === n;
        }).length;
    },
    changeFilter(newFilterValue){
      this.filterValue = newFilterValue;
    },
    // TODO 03C: Create methods to add the new review or cancel the add
addReview(){
    //Validate the newReview has good data
    if (!this.newReviewError{

    
    //Add newReview to the array of reviews
    this.reviews.unshift(this.newReview);
    this.resetReview();
    }
      //Tell the user there's a problem
    
},
resetReview(){
  this.newReview={}
  this.showForm
}
  }
};
</script>

<style>
div.main {
  margin: 1rem 0;
}

div.main div.well-display {
  display: flex;
  justify-content: space-around;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  cursor: pointer;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

.selectedFilter {
  border:3px solid Green;
}

div.main div.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

div.main div.review div.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

div.main div.review div.rating img {
  height: 100%;
}

div.main div.review p {
  margin: 20px;
}

div.main div.review h3 {
  display: inline-block;
}

div.main div.review h4 {
  font-size: 1rem;
}

input[type="text"] {
  padding: 5px 10px;
  margin: 5px 10px;
  background-color: beige;
  border: 1px solid lightblue;
  border-radius: 5px;
  box-shadow: 2px 2px 2px 2px lightblue;
  width: 300px;
}

/* Add a style for favorite reviews */
.favorite{
    background-color: lightyellow;
}
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input, div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type=button] {
  width: 100px;
}
form > input[type=submit] {
  width: 100px;
  margin-right: 10px;
}

/* TODO 04A: Add a style to Mark which rating is selected */

</style>