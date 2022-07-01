using Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreServices _scoreServices;
        public ScoreController(IScoreServices scoreServices)
        {
            _scoreServices = scoreServices;
        }

        /// <summary>
        /// 获取所有用户排序
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetCustomers")]
        public string GetCustomers()
        {
            return JsonSerializer.Serialize(_scoreServices.GetScoreModels());
        }

        /// <summary>
        /// 更新分数
        /// </summary>
        /// <param name="customerid">客户id</param>
        /// <param name="score">分数</param>
        /// <returns></returns>
        [HttpPost(Name = "UpdateScore")]
        public string UpdateScore(long customerid, int score)
        {         
            return _scoreServices.UpdateScore(customerid, score);
        }

        /// <summary>
        /// 根据范围获取客户排序
        /// </summary>
        /// <param name="start">开始排序</param>
        /// <param name="end">结束排序</param>
        /// <returns></returns>
        [HttpGet(Name = "GetCustomersByRank")]
        public string GetCustomersByRank(int start,int end)
        {
            return _scoreServices.GetCustomersByRank(start,end);
        }


        /// <summary>
        /// 根据id获取客户
        /// </summary>
        /// <param name="high">高于当前客户的数量</param>
        /// <param name="low">低于当前客户的数量</param>
        /// <returns></returns>
        [HttpGet(Name = "GetCustomersById")]
        public string GetCustomersById(long customerid,int high, int low)
        {
            return _scoreServices.GetCustomersById(customerid,high, low);
        }
    }
}
