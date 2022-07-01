using Core.Model.Models;

namespace Core.IServices
{
    public interface IScoreServices
    {
        /// <summary>
        /// 获取所有的排序
        /// </summary>
        /// <returns></returns>
        public List<ScoreModel> GetScoreModels();
        /// <summary>
        /// 更新分数
        /// </summary>
        /// <param name="customerid">客户id</param>
        /// <param name="score">分数</param>
        /// <returns></returns>
        public string UpdateScore(long customerid, int score);

        /// <summary>
        /// 根据范围获取客户排序
        /// </summary>
        /// <param name="start">开始排序</param>
        /// <param name="end">结束排序</param>
        /// <returns></returns>
        public string GetCustomersByRank(int start, int end);

        /// <summary>
        /// 根据id获取客户
        /// </summary>
        /// <param name="customerid">当前客户id</param>
        /// <param name="high">高于当前客户的数量</param>
        /// <param name="low">低于当前客户的数量</param>
        /// <returns></returns>
        public string GetCustomersById(long customerid, int high, int low);
    }
}