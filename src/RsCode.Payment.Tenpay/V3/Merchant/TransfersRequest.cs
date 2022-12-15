/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using RsCode.Payment.Tenpay.V3.Merchant.Info;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RsCode.Payment.Tenpay.V3.Merchant
{
    /// <summary>
    /// 发起商家转账API
    /// 商户可以通过该接口同时向多个用户微信零钱进行转账操作。
    /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/apis/chapter4_3_1.shtml"/>
    /// </summary>
    public class TransfersRequest:TenpayBaseRequest
    {
        public TransfersRequest()
        {

        }
        public TransfersRequest(string appid,string batchNo,string batchName,string batchRemark,List<TransferItemInfo> item)
        {
            AppId = appid;
            OutBatchNo = batchNo;
            BatchName = batchName;
            BatchRemark = batchRemark;

            TotalAmount = item.Sum(x => x.TransferAmount);
            TotalNum = item.Count;
            TransferDetailList = item.ToArray();
        }
        #region 参数
        /// <summary>
        /// 直连商户的appid
        /// </summary>
        [JsonPropertyName("appid")] public string AppId { get; set; }

        /// <summary>
        /// 商家批次单号
        /// 商户系统内部的商家批次单号，要求此参数只能由数字、大小写字母组成，在商户系统内部唯一
        /// </summary>
        [JsonPropertyName("out_batch_no")] public string OutBatchNo { get; set; }
        /// <summary>
        /// 批次名称
        /// </summary>
        [JsonPropertyName("batch_name")] public string BatchName { get; set; }
        /// <summary>
        /// 批次备注
        /// </summary>
        [JsonPropertyName("batch_remark")]
        public string BatchRemark { get; set; }
        /// <summary>
        /// 转账总金额
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 转账总笔数
        /// 一个转账批次单最多发起三千笔转账。转账总笔数必须与批次内所有明细之和保持一致，否则无法发起转账操作
        /// </summary>
        [JsonPropertyName("total_num")] 
        public int TotalNum { get; set; }
        [JsonPropertyName("transfer_detail_list")]
        public TransferItemInfo[] TransferDetailList { get; set; }

        #endregion

        public  string GetApiUrl()
        {
            string url = "https://api.mch.weixin.qq.com/v3/transfer/batches";
            return url;
        }
 
        public string RequestMethod()
        {
            return "POST";
        }

       
    }
}
