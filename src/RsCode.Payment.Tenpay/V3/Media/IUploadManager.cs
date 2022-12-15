using System.IO;
using System.Threading.Tasks;

namespace RsCode.Payment.Tenpay.Media
{
    public interface IUploadManager
    {
        void UseMchId(string mchId);
        /// <summary>
        /// 上传图片后可获得图片url地址
        /// 适用对象：直连商户 服务商 渠道商
        /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/open/pay/chapter4_7.shtml"/>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> UploadFileAsync(string filePath);

        /// <summary>
        /// 图片上传,得到图片MediaID
        /// 适用对象：服务商，直连商户,电商平台
        /// <see cref="https://pay.weixin.qq.com/wiki/doc/apiv3/wxpay/tool/chapter3_1.shtml"/>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<string> GetMediaIdAsync(string filePath);


    }
}