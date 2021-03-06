﻿using FinalProject.Models.GenreSelection;
using FinalProject.Models.MoviePopularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.SummaryPage
{
    public class SummaryInformation
    {
        public GenreViewModel SelectedMovieGenre { get; set; }
        public MoviePopularityViewModel SelectMoviePopular { get; set; }
        public string MovieTitle { get; set; }
        public int id { get; set; }
        public string PosterPath { get; set; }
        public decimal AverageSelected { get; set; }
        public int SkippedAmount { get; set; }
        public decimal AttemptsToDecide { get; set; }
        public decimal AverageAttemptsToDecide { get; set; }
        public string AttemptsMessage { get; set; }

    }
}