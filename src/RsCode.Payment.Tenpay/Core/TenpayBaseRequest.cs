namespace RsCode.Payment.Tenpay
{
    public interface TenpayBaseRequest
    {
        string RequestMethod();
        string GetApiUrl(); 
     
    }
}
