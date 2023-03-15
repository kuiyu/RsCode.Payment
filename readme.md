## 简介

软商网络第三方支付SDK

使用asp.net core技术开发

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
{
  "Default": {
    "TenpayMchId": "1604955852", //默认使用的微信商户号
    "AppId": "wx7c829604a62b02e8" //默认使用的appid
  },
  "Payment": [
     {
      "PaymentChannel": 1,
      "PaymentStatus": true,
      "MchType": 0,
      "MchId": "16042",
      "Rate": 1.0,  //支付费率
      "APIKey": "geyu223j22wqva",
      "APIKeyV3": "ghue28437ncjp2ucndjf7",
	  "PublicKeyCertPath": "cert/160492/apiclient_cert.p12",
       "PrivateKeyCertPath": "cert/162/apiclient_cert.p12",
      "CertPassword": "1604",
      "NotifyUrl": "/tenpay/notify"
    },
    {
      "PaymentChannel": 1,
      "PaymentStatus": true,
      "MchType": 0,
      "MchId": "1425162102",
      "Rate": 1.0,
      "APIKey": "xduiesuwxst3",
      "APIKeyV3": "hnrswlmp389e2",
	  "PublicKeyCertPath": "cert/142512/apiclient_cert.p12",
       "PrivateKeyCertPath": "cert/1425102/apiclient_cert.p12",
      "CertPassword": "142512",
      "pay_platform_cert_path": "/",
      "pay_platform_cert": "",
      "NotifyUrl": "/tenpay/notify/v2"
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

