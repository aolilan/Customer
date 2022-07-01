using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Models
{
    /// <summary>
    /// 客户排序
    /// </summary>
    public class ScoreModel
    {
        public ScoreModel(int score, int leaderboard)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            CustomerId = BitConverter.ToInt64(buffer, 0);
            Score = score;
            Rank = leaderboard;
        }
        /// <summary>
        /// 客户id
        /// </summary>
        public long CustomerId { get; }

        /// <summary>
        /// 分数
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Rank { get; set; }
    }
}
