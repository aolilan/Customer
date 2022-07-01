using Core.IServices;
using Core.Model.Models;
using System.Text.Json;

namespace Core.Services
{
    public class ScoreServices : IScoreServices
    {
        /// <summary>
        /// 获取所有排序
        /// </summary>
        /// <returns></returns>
        public List<ScoreModel> GetScoreModels()
        {
            return Global.ScoreList.OrderByDescending(o => o.Score).ThenBy(o => o.CustomerId).ToList();
        }
        /// <summary>
        /// 更新分数
        /// </summary>
        /// <param name="customerid">客户id</param>
        /// <param name="score">分数</param>
        /// <returns></returns>
        public string UpdateScore(long customerid, int score)
        {
            var customer = Global.ScoreList.FirstOrDefault(o => o.CustomerId.Equals(customerid));
            if (customer == null)
                return "客户id(customerid)不正确";
            //修改分数
            customer.Score += score;

            //重新排序
            if (score > 0)
            {
                var nextRank = Global.ScoreList.FindAll(o => o.Score > customer.Score)
                    .OrderByDescending(o=>o.Rank).FirstOrDefault()?.Rank;
                nextRank = nextRank == null ? 1 : (int)nextRank + 1;
                var list = Global.ScoreList.FindAll(o =>
                o.Score <= customer.Score && o.Rank <= customer.Rank);
                list = list.OrderByDescending(o => o.Score).ThenBy(o => o.CustomerId).ToList();
                list.ForEach(o => {
                    o.Rank = (int)nextRank;
                    nextRank++;
                });
            }
            else if (score < 0)
            {
                var nextRank = Global.ScoreList.Find(o => o.Rank == customer.Rank - 1)?.Rank;
                nextRank = nextRank == null ? 1 : (int)nextRank + 1;
                var list = Global.ScoreList.FindAll(o =>
                o.Score >= customer.Score && o.Rank >= customer.Rank);
                list = list.OrderByDescending(o => o.Score).ThenBy(o => o.CustomerId).ToList();
                list.ForEach(o => {
                    o.Rank = (int)nextRank;
                    nextRank++;
                });
            }
            return JsonSerializer.Serialize(Global.ScoreList.OrderBy(o => o.Rank));
        }

        /// <summary>
        /// 根据范围获取客户排序
        /// </summary>
        ///<param name="customerid">当前客户id</param>
        /// <param name="start">开始排序</param>
        /// <param name="end">结束排序</param>
        /// <returns></returns>
        public string GetCustomersById(long customerid, int high, int low)
        {
            var customer = Global.ScoreList.FirstOrDefault(o => o.CustomerId.Equals(customerid));
            if (customer == null)
                return "客户id(customerid)不正确";
            var list = Global.ScoreList.FindAll(o => 
            o.Rank <= customer.Rank + low
            && o.Rank >= customer.Rank - high);
            return JsonSerializer.Serialize(list.OrderBy(o => o.Rank));
        }

        /// <summary>
        /// 根据排序范围获取客户排序
        /// </summary>
        /// <param name="start">开始排序</param>
        /// <param name="end">结束排序</param>
        /// <returns></returns>
        public string GetCustomersByRank(int start, int end)
        {
            var list = Global.ScoreList.FindAll(o =>
           o.Rank <= end
           && o.Rank >= start);
            return JsonSerializer.Serialize(list.OrderBy(o => o.Rank));
        }
    }
}