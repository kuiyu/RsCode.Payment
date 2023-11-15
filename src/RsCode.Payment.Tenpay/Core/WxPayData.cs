﻿/*
 * 项目:第三方支付工具 RsCode.Payment 
 * 作者:河南软商网络科技有限公司 
 * 协议:MIT License 2.0  
 * 项目己托管于  
 * github https://github.com/kuiyu/RsCode.Payment.git
 */
using AspectCore.Extensions.Reflection;
using Microsoft.AspNetCore.Http;
using RsCode.Payment.Tenpay.V2;
using RsCode.Payment.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using System.Xml;


namespace RsCode.Payment.Tenpay
{
    /// <summary>
    /// 微信支付协议接口数据类，所有的API接口通信都依赖这个数据结构，
    /// 在调用接口之前先填充各个字段的值，然后进行接口通信，
    /// 这样设计的好处是可扩展性强，用户可随意对协议进行更改而不用重新设计数据结构，
    /// 还可以随意组合出不同的协议数据包，不用为每个协议设计一个数据包结构
    /// </summary>
    public  class WxPayData : PaymentResult, IPayData
    {
         
         
        public const string SIGN_TYPE_MD5 = "MD5";
        public const string SIGN_TYPE_HMAC_SHA256 = "HMAC-SHA256";
        public const string SHA256_RSA="SHA256-RSA";


       
        //采用排序的Dictionary的好处是方便对数据包进行签名，不用再签名之前再做一次排序
        protected SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();

        string signType = "HMAC-SHA256";

        /// <summary>
        /// 签名类型，默认值：HMAC-SHA256  
        /// 取值范围：MD5 HMAC-SHA256 SHA256-RSA
        /// </summary>
        /// <returns></returns>
        public virtual string GetSignType()
        {
            return signType;
        }

        /**
        * 设置某个字段的值
        * @param key 字段名
         * @param value 字段值
        */
        public void SetValue(string key, object value)
        {
            m_values[key] = value;
        }

        /**
        * 根据字段名获取某个字段的值
        * @param key 字段名
         * @return key对应的字段值
        */
        public object GetValue(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            return o;
        }

        /**
         * 判断某个字段是否已设置
         * @param key 字段名
         * @return 若字段key已被设置，则返回true，否则返回false
         */
         bool IsSet(string key)
        {
            object o = null;
            m_values.TryGetValue(key, out o);
            if (null != o)
                return true;
            else
                return false;
        }

        /**
        * @将Dictionary转成xml
        * @return 经转换得到的xml串
        * @throws Exception
        **/
        public string ToXml()
        {
            //数据为空时不能转化为xml格式
            if (0 == m_values.Count)
            {
                //Log.Error(this.GetType().ToString(), "WxPayData数据为空!");
                throw new Exception("WxPayData数据为空!");
            }

            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData内部含有值为null的字段!");
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }

                if (pair.Value.GetType() == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                    continue;
                }
                 if (pair.Value.GetType() == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                    continue;
                }

                 string objName= pair.Value.GetType().Name;
                var isDataInfo = pair.Value is TenpayDataInfo;
                 
                 if(objName.StartsWith("List")|| isDataInfo)  
                {
                    var obj = pair.Value;
                    var s = JsonSerializer.Serialize(obj);
                   
                    xml += $"<{pair.Key}>{s}</{pair.Key}>";
                    continue;
                }
                else//除了string和int类型不能含有其他数据类型
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData字段数据类型错误!");
                    throw new Exception("WxPayData字段数据类型错误!");
                }
            }
            xml += "</xml>";
            return xml;
        }
       
        /**
        * @将xml转为WxPayData对象并返回对象内部的数据
        * @param string 待转换的xml串
        * @return 经转换得到的Dictionary
        * @throws Exception
        */
        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                //Log.Error(this.GetType().ToString(), "将空的xml串转换为WxPayData不合法!");
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }


            SafeXmlDocument xmlDoc = new SafeXmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                //获取xml的键值对到WxPayData内部的数据中
                if(xe.InnerXml.StartsWith("<![CDATA["))
                {
                    m_values[xe.Name] = xe.InnerText;
                }
                else
                {
                    if(xe.InnerXml.Contains("."))
                    {
                       m_values[xe.Name] = Convert.ToDecimal( xe.InnerText);
                    }else
                    {
                        m_values[xe.Name] =Convert.ToInt32( xe.InnerText);
                    }  
                }
            }

            try
            {
                //2015-06-29 错误是没有签名
                if (m_values["return_code"] != "SUCCESS")
                {
                    return m_values;
                }
                CheckSign();//验证签名,不通过会抛异常
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return m_values;
        }

        /**
        * @Dictionary格式转化成url参数格式
        * @ return url格式串, 该串不包含sign字段值
        */
        public string ToUrl()
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value == null)
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData内部含有值为null的字段!");
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }

                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }


        /**
        * @Dictionary格式化成Json
         * @return json串数据
        */
        public string ToJson()
        {           
            string jsonStr=System.Text.Json.JsonSerializer.Serialize(m_values);
            return jsonStr;
        }

        /**
        * @values格式化成能在Web页面上显示的结果（因为web页面上不能直接输出xml格式的字符串）
        */
        public string ToPrintStr()
        {
            string str = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value == null)
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData内部含有值为null的字段!");
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }


                str += string.Format("{0}={1}\n", pair.Key, pair.Value.ToString());
            }
            str = HttpUtility.HtmlEncode(str);
            //Log.Debug(this.GetType().ToString(), "Print in Web Page : " + str);
            return str;
        }


        /**
        * @生成签名，详见签名生成算法
        * @return 签名, sign字段不参加签名
        */
        public string MakeSign(string signType, string key)
        {
            //转url格式
            string str = ToUrl();
            //在string后加入API KEY
            str += "&key=" + key;
            if (signType == SIGN_TYPE_MD5)
            {
                var md5 =System.Security.Cryptography.MD5.Create();
                var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                var sb = new StringBuilder();
                foreach (byte b in bs)
                {
                    sb.Append(b.ToString("x2"));
                }
                //所有字符转为大写
                return sb.ToString().ToUpper();
            }
            else if (signType == this.signType)
            {
                return CalcHMACSHA256Hash(str, key).ToUpper();
            }
            else
            {
                throw new Exception("sign_type 不合法");
            }
        }



        /// <summary>
        /// 生成签名，详见签名生成算法  sign字段不参加签名 SHA256 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string MakeSign(string key)
        {
            return MakeSign(SIGN_TYPE_HMAC_SHA256, key);
        }

       

        /// <summary>
        /// 检测签名是否正确
        /// </summary>
        /// <param name="signType"></param>
        /// <returns>正确返回true，错误抛异常</returns>
        public bool CheckSign(string signType)
        {
            //如果没有设置签名，则跳过检测
            if (!IsSet("sign"))
            {
                // Log.Error(this.GetType().ToString(), "WxPayData签名存在但不合法!");
                throw new Exception("WxPayData签名存在但不合法!");
            }
            //如果设置了签名但是签名为空，则抛异常
            else if (GetValue("sign") == null || GetValue("sign").ToString() == "")
            {
                // Log.Error(this.GetType().ToString(), "WxPayData签名存在但不合法!");
                throw new Exception("WxPayData签名存在但不合法!");
            }

            //获取接收到的签名
            string return_sign = GetValue("sign").ToString();

            //在本地计算新的签名
            string cal_sign = MakeSign(signType);

            if (cal_sign == return_sign)
            {
                return true;
            }

            //Log.Error(this.GetType().ToString(), "WxPayData签名验证错误!");
            throw new Exception("WxPayData签名验证错误!");
        }



        /**
        * 
        * 检测签名是否正确
        * 正确返回true，错误抛异常
        */
        public bool CheckSign()
        {
            return CheckSign(SIGN_TYPE_HMAC_SHA256);
        }

        /**
        * @获取Dictionary
        */
        public SortedDictionary<string, object> GetValues()
        {
            return m_values;
        }


        private string CalcHMACSHA256Hash(string plaintext, string salt)
        {
            string result = "";
            var enc = Encoding.Default;
            byte[]
            baText2BeHashed = enc.GetBytes(plaintext),
            baSalt = enc.GetBytes(salt);
            System.Security.Cryptography.HMACSHA256 hasher = new System.Security.Cryptography.HMACSHA256(baSalt);
            byte[] baHashedText = hasher.ComputeHash(baText2BeHashed);
            result = string.Join("", baHashedText.ToList().Select(b => b.ToString("x2")).ToArray());
            return result; 
        }


        public void AutoSetValue()
        { 
            var obj =  MemberwiseClone();
            var type = GetType();
            foreach (var item in type.GetProperties())
            {
                var reflector = item.GetReflector();
                var value = item.GetValue(obj, null);
                if (value != null)
                {
                    var attr = reflector.GetCustomAttribute<JsonPropertyNameAttribute>();
                    if (attr != null)
                    {
                        string key = attr.Name;
                        if (value.GetType().Name.StartsWith("List")||value is TenpayDataInfo)
                        {
                            SetValue(key, JsonSerializer.Serialize(value));
                        }else
                        SetValue(key, value);
                    }
                }

            }
        }

        public void  SetSignType(string _signType= "HMAC-SHA256")
        {
            signType = _signType;
        }


        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetIp(HttpContext context)
        {
            string ip = "0.0.0.0";
            if (context != null)
            {
                ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (string.IsNullOrEmpty(ip))
                {
                    ip = context.Connection.RemoteIpAddress.ToString();
                }
            }

            return ip;
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        public string GetNonceStr()
        {
            var randomGenerator = new RandomGenerator();
            return randomGenerator.GetRandomUInt().ToString();
        }
        



        /// <summary>
        /// 配置支付客户端
        /// </summary>
        /// <param name="_client"></param>
        /// <param name="context"></param>
        public virtual void InitSDK(ClientOptions _client, HttpContext context = null)
        {
          
        }
         
       

        public virtual string GetRequestUrl()
        {
            return "";
        }
        



        /// <summary>
        /// 设置交易类型
        /// </summary>
        /// <param name="app"></param>
        public string SetTradeType(AppOptions app)
        {
            string tradeType = "";
            if (app.PaymentScene== PaymentScene.Native)
            {
                //扫码支付
                tradeType= TradeType.Native.ToDescription();
            }
            if(app.PaymentScene == PaymentScene.APP)
            {
                tradeType = TradeType.App.ToDescription();
            }
            if(app.PaymentScene == PaymentScene.JSAPI)
            {
                tradeType = TradeType.JSAPI.ToDescription();
            }
            return tradeType;
        }
         

         
    }
}
