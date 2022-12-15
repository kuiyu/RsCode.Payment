using RsCode.Config;
using System;

namespace RsCode.Payment.Wxpay.Core
{


    public class DefaultWxPayConfig : IWxPayConfig
    {
        string KeyName;

        public DefaultWxPayConfig()
        {
            KeyName = "DefaultApp";
        }

        public void GetConfig(string sectionName="DefaultApp")
        {
            KeyName = sectionName;
        }

        //=======【基本信息设置】=====================================
        /* 微信公众号信息配置
        * APPID：绑定支付的APPID（必须配置）
        * MCHID：商户号（必须配置）
        * KEY：商户支付密钥，参考开户邮件设置（必须配置），请妥善保管，避免密钥泄露
        * APPSECRET：公众帐号secert（仅JSAPI支付的时候需要配置），请妥善保管，避免密钥泄露
        */

        public string GetAppID()
        {
            string key = "WxPay:" + KeyName + ":AppId";
            string appid = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(appid))
                throw new Exception("节点：" + key + "未配置AppId");
            return appid;
        }
        public string GetMchID()
        {
            string key = "WxPay:" + KeyName + ":MchId";
            string mchid = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(mchid))
                throw new Exception("节点：" + key + "未配置商户号MchId");
            return mchid;
        }
        public string GetKey()
        {
            string key = "WxPay:" + KeyName + ":Key";
            string s = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(s))
                throw new Exception("节点：" + key + "未配置商户支付密钥Key");
            return s;
        }
        public string GetAppSecret()
        {
            string key = "WxPay:" + KeyName + ":AppSecret";
            string s = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(s))
                throw new Exception("节点：" + key + "未配置公众帐号secert");
            return s;
        }



        //=======【证书路径设置】===================================== 
        /* 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
         * 1.证书文件不能放在web服务器虚拟目录，应放在有访问权限控制的目录中，防止被他人下载；
         * 2.建议将证书文件名改为复杂且不容易猜测的文件
         * 3.商户服务器要做好病毒和木马防护工作，不被非法侵入者窃取证书文件。
        */
        public string GetSSlCertPath()
        {
            string key = "WxPay:" + KeyName + ":CertPath";
            string s = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(s))
                throw new Exception("节点：" + key + "未配置证书路径CertPath");
            return s;
        }
        public string GetSSlCertPassword()
        {
            string key = "WxPay:" + KeyName + ":CertPassword";
            string s = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(s))
                throw new Exception("节点：" + key + "未配置证书密码CertPassword");
            return s;
        }



        //=======【支付结果通知url】===================================== 
        /* 支付结果通知回调url，用于商户接收支付结果
        */
        public string GetNotifyUrl()
        {
            string key = "WxPay:" + KeyName + ":NotifyUrl";
            string s = AppSettings.Get(key);
            if (string.IsNullOrWhiteSpace(s))
                throw new Exception("节点：" + key + "未配置回调地址NotifyUrl");
            return s;

        }

        //=======【商户系统后台机器IP】===================================== 
        /* 此参数可手动配置也可在程序中自动获取
        */
        public string GetIp()
        {
            return "0.0.0.0";
        }


        //=======【代理服务器设置】===================================
        /* 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        */
        public string GetProxyUrl()
        {
            return "";
        }


        //=======【上报信息配置】===================================
        /* 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        */
        public int GetReportLevel()
        {
            return 1;
        }


        //=======【日志级别】===================================
        /* 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        */
        public int GetLogLevel()
        {
            return 1;
        }

        /**
      * 生成时间戳，标准北京时间，时区为东八区，自1970年1月1日 0点0分0秒以来的秒数
       * @return 时间戳
      */
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /**
        * 生成随机串，随机串包含字母或数字
        * @return 随机串
        */
        public string GenerateNonceStr()
        {
            RandomGenerator randomGenerator = new RandomGenerator();
            return randomGenerator.GetRandomUInt().ToString();
        }
    }

}
