<template>
  <div class="main">
    <h1>Product reviews for {{ title }}</h1>
    <p class="description">{{ description }}</p>
    <p>{{ message }}</p>
<!-- A single review -->
    <!-- <div class="review">
      <h4>Mike Morel</h4>
      <div class="rating">
        <img src="../assets/star.png" class="ratingStar" />
        <img src="../assets/star.png" class="ratingStar" />
        <img src="../assets/star.png" class="ratingStar" />
        <img src="../assets/star.png" class="ratingStar" />
      </div>
      <h3>I like the beat; you can dance to it</h3>
      <p>It's easy to dance to. But the words...the words make no sense.</p>
    </div> -->
        <div class="well-display">
      <div class="well">
        <span class="amount">
          {{averageRating}}
          <!-- data binding goes here -->
        </span>
        Average Rating
      </div>
    <div class="review" v-for="rev in reviews" v-bind:key="rev.id" v-bind:class="{favorite: rev.favorite}">
      <h4>{{rev.reviewer}}</h4>
      <div class="rating">
        <img src="../assets/star.png" class="ratingStar" v-for="n in rev.rating" v-bind:key="n" />
     
      </div>
      <h3>{{rev.title}}</h3>
      <p>{{rev.review}}</p>
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
      description: "Host a party for all your squirrelly friends!",
      reviews: [
        {
          id: 1,
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
          rating: 3,
          favorite: false,
        },
        {
          id: 2,
          reviewer: "Craig Castelaz",
          title: "Better than a swift kick in the butt!",
          review: "My bar is low.",
          rating: 4,
          favorite: false,
        },
              {
          id: 3,
          reviewer: "Johnny Knoxville",
          title: "Ouch!",
          review: "waste of my time.",
          rating: 1,
          favorite: false,
        },
           {
          id: 1,
          reviewer: "Pablo Escobar",
          title: "I love cigars!",
          review:
            "I was so enthralled with the book, I forgot to feed my hippos.",
          rating: 10,
          favorite: false,
        },
      ],
    };
  },
  computed:{
  averageRating(){
    //Calculate the average of all review ratings.
 
    let sumRatings=0;
   // loop through reviews and add up all the ratings
    
    this.reviews.forEach( (r) => {
      sumRatings+=r.rating;
    });
    //Calculate average by dividing by number of reviews
    return sumRatings / this.reviews.length;
  },
  },
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

/*Add a style for favorite reviews */
.favorite{
  background-color: lightyellow;
}
</style>