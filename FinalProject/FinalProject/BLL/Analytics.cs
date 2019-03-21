﻿using FinalProject.DAL;
using FinalProject.Models.DAL_Objects;
using FinalProject.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.BLL
{
    public class Analytics
    {
        public decimal AverageTimesSelected(MovieVotingHistoryDbContext db)
        {
            string selectedMovie = HttpContext.Current.Session["SelectedMovie"] as string;

            int selectedAmount = db.Movie.Where(d => d.MovieName == selectedMovie).Select(d => d.NumberOfTimesChosen).SingleOrDefault();
            int sumOfAllMovieChosen = db.Movie.Sum(d => d.NumberOfTimesChosen);

            decimal average = Convert.ToDecimal(selectedAmount) / Convert.ToDecimal(sumOfAllMovieChosen);
            average = Math.Round(average, 2) * 100;

            return average;

        }

        public int FrequencySkipped(MovieVotingHistoryDbContext db)
        {
            string selectedMovie = HttpContext.Current.Session["SelectedMovie"] as string;

            int totalSkipped = db.RejectedMovies.Where(d => d.MoviesSkipped == selectedMovie).Count();

            return totalSkipped;

        }

        public decimal[] AttemptsToDecide(MovieVotingHistoryDbContext db)
        {
            string movieID = HttpContext.Current.Session["SessionId"] as string;
            int.TryParse(movieID, out int id);

            decimal numberOfAttempts = db.Attempt.Where(d => d.ID == id).Select(d => d.Attempts).SingleOrDefault();
            decimal sumOfAllUserAttempts = Convert.ToDecimal(db.Attempt.Average(d => d.Attempts));
            sumOfAllUserAttempts = Math.Round(sumOfAllUserAttempts, 2);

            decimal[] statistics = { numberOfAttempts, sumOfAllUserAttempts };
            return statistics;

        }

        public string MovieFoodTracker(MovieVotingHistoryDbContext db)
        {
            string selectedMovie = HttpContext.Current.Session["SelectedMovie"] as string;
            if (selectedMovie == null)
            {
                return null;
            }
            List<MovieFood> hey = db.CompareMovieToFood.Where(x => x.MovieSelection == selectedMovie).ToList<MovieFood>();
            if (hey.Count() == 0)
            {
                return null;
            }
            List<string> food = new List<string>();
            foreach (var item in hey)
            {
               
                    food.Add(item.FoodSelection);
               
            }
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != food[i])
                {
                    food.Remove(food[i]);
                }
            }

            return $"The most popular pairing with this movie is {food.FirstOrDefault()}";
        }
    }
}