using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class SMS_Tester : MonoBehaviour
{
    public string mobile_num = "0633109993";
    public string message = "This is a test from Unity *^#$#$((*&& Test Symbols";
    public void SendSms()
    {


        //Android SMS URL - doesn't require encoding for sms call to work
        string URL = string.Format("sms:{0}?body={1}",mobile_num,System.Uri.EscapeDataString(message));



        //Execute Text Message
        Application.OpenURL(URL);
    }

    public void ChangePhoneNumber(string nmbr)
    {
        mobile_num = nmbr;
    }
    
    public void ChangeMessage(string msg)
    {
        message = msg;
    }
}
