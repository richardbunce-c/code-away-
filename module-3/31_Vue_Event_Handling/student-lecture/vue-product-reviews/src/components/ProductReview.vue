<!--
Features to add:
  TODO 01: Allow the user to click on a Well to display only those reviews with a particular rating
  TODO 02: Give a visual indication of which filter is being applied
  TODO 03: Provide a form to allow the user to add a new review
  TODO 04: Show and hide the AddReview form as appropriate
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
      <div class="well">
        <span class="amount">
          {{ averageRating }}
        </span>
        Average Rating
      </div>

      <div class="well" v-for="i in 5" v-bind:key="i">
        <span class="amount">
          {{nStarReviews(i)}}
        </span>
        {{i}}-star reviews
      </div>
    </div>

    <!-- TODO 04C: Add a link to show or hide the form -->

    <!-- TODO 03B: Create the form that allows the user to add a new review -->
    <!-- TODO 04B: Only show the form of the showForm variable is set -->

    <!-- Display each review in a loop -->
    <!-- TODO 01C: Display the filteredReviews array instead of the raw data -->
    <div class="review" v-for="rev in reviews" v-bind:key="rev.id" v-bind:class="{favorite: rev.favorite}">
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

      // TODO 03A: Create a new, empty review object for adding new reviews.

      // TODO 04A: Create a variable to store whether the Add Review form should be visible

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

  },
  methods: {
    nStarReviews(n) {
        return this.reviews.filter( r =>{
            return r.rating === n;
        }).length;
    }
    // TODO 03C: Create methods to add the new review or cancel the add

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
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
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