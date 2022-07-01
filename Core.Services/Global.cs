using Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public static class Global
    {
        public static List<int> Score = new List<int>() { 124, 93, 100, 110, 93, 95, 97, 93, 96, 99, 110, 120 };
        public static List<ScoreModel> ScoreList = InitializeScoreList(Score);
        private static List<ScoreModel> InitializeScoreList(List<int> score)
        {
            List<ScoreModel> scoreList = new List<ScoreModel>();
            score.ForEach(o => scoreList.Add(new ScoreModel(o, scoreList.Count() + 1)));
            scoreList = scoreList.OrderByDescending(o => o.Score).ThenBy(o => o.CustomerId).ToList();
            for (int i = 0; i < scoreList.Count(); i++)
                scoreList[i].Rank = i + 1;
            return scoreList;
        }
    }
}
