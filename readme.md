## 简介

RsCode.Payment软商网络开发的第三方支付平台SDK，使用.net技术开发，帮助应用快速接入支付系统

支持多个不同商户号切换支付

[![Gitee Stars](https://gitee.com/kuiyu/RsCode.Payment/badge/star.svg?title=Stars)](https://gitee.com/kuiyu/RsCode.Payment)[![Gitee Forks](https://gitee.com/kuiyu/RsCode.Payment/badge/fork.svg?title=Forks)](https://gitee.com/kuiyu/RsCode.Payment)[![GitHub Stars](https://img.shields.io/github/stars/kuiyu/RsCode.Payment?logo=github&label=Stars)](https://github.com/kuiyu/RsCode.Payment)[![GitHub Forks](https://img.shields.io/github/forks/kuiyu/RsCode.Payment?logo=github&label=Forks)](https://github.com/kuiyu/RsCode.Payment)[![Vistors](https://visitor-badge.laobi.icu/badge?page_id=fudiwei.DotNetCore.SKIT.FlurlHttpClient.ByteDance&title=Visitors)](https://github.com/kuiyu/RsCode.Payment)[![License](https://img.shields.io/github/license/kuiyu/RsCode.Payment?label=License)](https://mit-license.org/)

## 快速入门

引用 `RsCode.Payment.Tenapy.dll` 或 `RsCode.Payment.Alipay.dll`,注入支付客户端，调用支付API。

**示例代码：**

```csharp
public class Service
{ 
  ITenpayClient tenpay; //微信支付客户端
  IAlipayClient alipay; //支付宝客户端  
  public Service(ITenpayClient _tenpay，IAlipayClient _alipay)
  {
     tenpay=_tenpay;
	 //设置支付api版本
	 tenpay = _tenpay.FirstOrDefault(p => p.Ver == "2");
     alipay=_alipay;
  }
  
  public async Task TestPay()
  {
     //使用支付配置
     tenpay.UseMchId(mchId);
	 var redpack = new RedpacketSendRequest(info.OrderNo,
                    options.MchId,
                    "软商网络",
                    appId,
                    info.OpenId,
                   "感谢您参与优惠活动",
                    "优惠活动",
                    "参与越多得越多",
                    0 - info.WidthdrawalAmount,
                    "PRODUCT_2"
                    );

                var ret = await tenpay.SendAsync<RedpacketSendResponse>(redpack);
  }
}
```

**pay.json配置**

```json
 "Default": {
   "TenpayMchId": "1425162102", //默认微信支付商户号
   "AppId": "wx7c829604a62b02e8"//默认应用Id
 },
 "Payment": [
   {
     "PaymentStatus": true,
     "PaymentChannel": 1,   //支付渠道类型 1微信支付 2支付宝
     "Rate": 0.6,
     "MchId": "1425162102",  //商户号
     "APIKey": "",   //微信支付APIkey
     "APIKeyV3": "", //微信支付APIkey v3
     "CertPassword": "1425162102",           //证书密码,默认为商户号
     "PrivateKey": "cert\\1425162102\\apiclient_cert.p12", //私钥p12证书路径
     "NotifyUrl": "https://xxx/tenpay/notify/",               //支付回调地址，必须以/结尾
     "MchType": 0
   },
   {
     "PaymentStatus": true,
     "PaymentChannel": 2, //支付渠道类型 1微信支付 2支付宝
     "Rate": 0.6,
     "MchId": "20210021xxxxxxx",
     "PublicKey": "cert\\alipay\\appCertPublicKey_xxxxxxx.crt",  //应用的公钥
     "PrivateKey":"MIIEpAxxxxxxxxxxxxxxxxxx", //应用私钥,使用支付宝密钥工具将生成的私钥转成PKCS1格式后使用
     "PlatformPublicKey": "cert\\alipay\\alipayCertPublicKey_RSA2.crt",
     "PlatformRootCert": "cert\\alipay\\alipayRootCert.crt",
     "NotifyUrl": "/alipay/notify",
     "MchType": "0"
   } 
 ],
  "App": [
    {
      "AppId": "wx4d99cd",
      "MchId": "1487",
      "Token": "",
      "AppSecret": "ab54daa9",
      "PayChannel": "1",
      "Description": "weihuo mp",
      "AppType": 1
    }
  ],
  "AuthKey": [
    {
      "id": "1-c791674b611e",
      "create_date": "2020年04月02日 22:47:40",
      "authkey": "c9a9e5ccaabfdc"
    }
  ]
}

```

## 实例项目

[交易宝收款软件](https://rscode.cn/jyb/readme.html)是使用这个库进行开发的应用



## 名词解释

#### 支付场景(pay_scene)

app发起支付的场景,取值范围 
1jsapi   2app  3 native

#### 支付渠道(pay_channel)

第三方支付信息 取值范围  1微信 2支付宝

#### 支付客户端

以应用为单位，系统为应用分配唯一的clientId
每个应用只能对应一种支付场景
每个clientId可以分配多个商户号



### Merchant 商户业务

### Partner服务商业务

## 联系方式

微信群

![微信扫码进群](https://u.rscode.cn/kefu-qrcode.png)

