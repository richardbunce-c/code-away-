import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    activeAssets:[],
    token: currentToken || '',
    user: currentUser || {},
    allUsers:[],
    allGames:[],
    userGames:[],
    selectedGame:[],
    allStocks:[],
    currentGameLeaderBoard:[]
  },
  mutations: {
    SET_CURRENT_LEADER_BOARD(state, leaderboard){
      state.currentGameLeaderBoard=leaderboard
    },
    SET_ALL_STOCKS(state, stocks){
      state.allStocks=stocks
    },
    SET_SELECTED_ASSETS(state, assets){
      state.activeAssets = assets
    },
    SET_SELECTED_GAME(state, game){
      state.selectedGame=game
    },
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_ALLUSERS(state, userlist){
      state.allUsers = userlist
    },
    SET_ALLGAMES(state, gamelist){
      state.allGames = gamelist
    },
    SET_USERSGAMES(state, gamelist){
      state.userGames=gamelist
    }
  }
})
