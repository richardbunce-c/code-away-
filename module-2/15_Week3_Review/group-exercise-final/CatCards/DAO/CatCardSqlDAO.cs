﻿using CatCards.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CatCards.DAO
{
    /// <summary>
    /// This class takes care of all data access for a CatCard. This includes:
    ///     1. Database access for adding, updating, reading and deleting user-saved cards
    ///     2. Generation of a new CatCard card by assembling random cat facts and random cat pictures retrieved from an api
    /// </summary>
    public class CatCardSqlDAO : ICatCardDao
    {
        private readonly string connectionString;
        private readonly string catFactApiUrl = "https://cat-fact.herokuapp.com/facts/random";
        private readonly string catPicApiUrl = "https://random-cat-image.herokuapp.com/";
        private string apiKey = "ernerio'gjnequio['hn'io";
        /// <summary>
        /// Constructor.  Needs a connection string to connect to a database.
        /// </summary>
        public CatCardSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Saves a new card to the database in the user's collection
        /// </summary>
        /// <param name="addedCard">The new card to add</param>
        /// <returns>The added card</returns>
        public CatCard AddCard(CatCard addedCard)
        {
            string sql = "Insert catcards (img_url, fact, caption) Values (@img_url, @fact, @caption); Select * from catcards where id = @@identity;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@img_url", addedCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", addedCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", addedCard.Caption);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop the rows and create the objects
                    if (rdr.Read())
                    {
                        return RowToObject(rdr);
                    }
                    return null;
                }
            }
            catch (SqlException ex)
            {
                // Typically, we would log this
                throw;
            }

        }

        /// <summary>
        /// List all cards in the DB
        /// </summary>
        /// <returns>A list of all saved CatCards.</returns>
        public List<CatCard> GetAllCards()
        {
            string sql = "Select * from catcards";
            List<CatCard> list = new List<CatCard>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop the rows and create the objects
                    while (rdr.Read())
                    {
                        list.Add( RowToObject(rdr) );
                    }
                    return list;
                }
            }
            catch (SqlException ex)
            {
                // Typically, we would log this
                throw;
            }
        }

        private CatCard RowToObject(SqlDataReader rdr)
        {
            CatCard card = new CatCard();
            card.CatCardId = Convert.ToInt32(rdr["id"]);
            card.ImgUrl =    Convert.ToString(rdr["img_url"]);
            card.CatFact =   Convert.ToString(rdr["fact"]);
            card.Caption =   Convert.ToString(rdr["caption"]);
            return card;
        }

        /// <summary>
        /// Get a single CatCard from the DB based on an id
        /// </summary>
        /// <param name="id">Id of the card to read</param>
        /// <returns>The card with the specified id, NULL if there is no such id</returns>
        public CatCard GetCard(int id)
        {
            string sql = "Select * from catcards where id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Loop the rows and create the objects
                    if (rdr.Read())
                    {
                        return RowToObject(rdr);
                    }
                    return null;
                }
            }
            catch (SqlException ex)
            {
                // Typically, we would log this
                throw;
            }
        }

        /// <summary>
        /// Use two API's to get a Cat Fact and a Cat Card and assemble a new CatCard.  This method does not
        /// read from or write to the database.
        /// </summary>
        /// <returns></returns>
        public CatCard GetRandomCatCard()
        {
            // Create an empty catCard
            CatCard card = new CatCard();

            // Call the cat fact api to fill in fact property 
            card.CatFact = GetRandomCatFact().Text;

            // Call the cat pic api to fill in the pic property
            card.ImgUrl = GetRandomCatPic().File;

            return card;
        }

        private CatFactResponse GetRandomCatFact()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(catFactApiUrl);
            IRestResponse<CatFactResponse> response = client.Get<CatFactResponse>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("The Cat Fact server could not be reached");
            }
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting cat Fact: {response.StatusCode}");
            }
            return response.Data;
        }

        private CatPicResponse GetRandomCatPic()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(catPicApiUrl);
            IRestResponse<CatPicResponse> response = client.Get<CatPicResponse>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("The Cat Pic server could not be reached");
            }
            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting cat Pic: {response.StatusCode}");
            }
            return response.Data;
        }

        /// <summary>
        /// Deletes from the DB the card with the specified id
        /// </summary>
        /// <param name="id">Id of the card to delete</param>
        /// <returns>True if the delete succeeded</returns>
        public bool RemoveCard(int id)
        {
            string sql = "Delete catcards where id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected == 1;
                }
            }
            catch (SqlException ex)
            {
                // Typically, we would log this
                throw;
            }
        }

        /// <summary>
        /// Update the properties of the card in the DB. 
        /// </summary>
        /// <param name="updatedCard">New values to save into the DB</param>
        /// <returns>True if the update succeeded</returns>
        public bool UpdateCard(CatCard updatedCard)
        {
            string sql = "Update catcards Set img_url = @img_url, fact = @fact, caption = @caption where id = @id";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@id", updatedCard.CatCardId);
                    cmd.Parameters.AddWithValue("@img_url", updatedCard.ImgUrl);
                    cmd.Parameters.AddWithValue("@fact", updatedCard.CatFact);
                    cmd.Parameters.AddWithValue("@caption", updatedCard.Caption);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected == 1;
                }
            }
            catch (SqlException ex)
            {
                // Typically, we would log this
                throw;
            }
        }
    }
}