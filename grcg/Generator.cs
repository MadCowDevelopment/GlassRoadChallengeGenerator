﻿// © 2019 Baker Hughes, a GE company.  All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes, a GE company.
// Do not use, copy or distribute without permission.

using System;
using System.IO;
using System.Text;

namespace grcg
{
    internal class Generator
    {
        private readonly BuildingData _buildingData;
        private readonly ChallengeData _challengeData;

        public Generator(BuildingData buildingData, ChallengeData challengeData)
        {
            _buildingData = buildingData;
            _challengeData = challengeData;
        }

        public string Generate()
        {
            var templateString = File.ReadAllText(@".\ForumPost.template");

            templateString = ReplaceEndDate(templateString);
            templateString = ReplaceChallengeNumber(templateString);
            templateString = ReplacePreviousResults(templateString);
            templateString = ReplaceStartingBuildings(Category.Blue, templateString);
            templateString = ReplaceStartingBuildings(Category.Yellow, templateString);
            templateString = ReplaceStartingBuildings(Category.Orange, templateString);
            templateString = ReplaceOfferBuildings(Category.Blue, templateString);
            templateString = ReplaceOfferBuildings(Category.Yellow, templateString);
            templateString = ReplaceOfferBuildings(Category.Orange, templateString);

            return templateString;
        }

        private string ReplaceEndDate(string templateString)
        {
            var endDate = DateTime.Now.AddMonths(1);
            while (endDate.AddDays(1).Month == endDate.Month)
            {
                endDate = endDate.AddDays(1);
            }

            return templateString.Replace("<<END_DATE>>", endDate.ToShortDateString());
        }

        private string ReplaceChallengeNumber(string templateString)
        {
            return templateString.Replace("<<CHALLENGE_NUMBER>>", (_challengeData.Count + 1).ToString());
        }

        private string ReplacePreviousResults(string templateString)
        {
            var builder = new StringBuilder();
            foreach (var challenge in _challengeData)
            {
                builder.AppendLine($":chalice:[thread={challenge.ThreadId}][/thread] -- high score {challenge.Score} by {challenge.User}:chalice:");
            }

            return templateString.Replace("<<PREVIOUS_RESULTS>>", builder.ToString());
        }

        private string ReplaceStartingBuildings(Category category, string templateString)
        {
            var builder = new StringBuilder();
            foreach (var startingBuilding in _buildingData.GetStartingBuildings(category))
            {
                builder.AppendLine(startingBuilding.ToPostFormat());
            }

            var placeHolder = $"<<STARTING_BUILDINGS_{category.ToString().ToUpper()}>>";
            return templateString.Replace(placeHolder, builder.ToString());
        }

        private string ReplaceOfferBuildings(Category category, string templateString)
        {
            var builder = new StringBuilder();
            foreach (var offerBuilding in _buildingData.GetOfferBuildings(category))
            {
                builder.Append($"[o]{offerBuilding.ToPostFormat()}[/o]");
            }

            var placeHolder = $"<<OFFER_BUILDINGS_{category.ToString().ToUpper()}>>";
            return templateString.Replace(placeHolder, builder.ToString());
        }
    }
}