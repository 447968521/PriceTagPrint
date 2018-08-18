using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PriceTagPrint.Common
{
    /**
    * 命名空间: WHC.Framework.Starter.Common
    *
    * 功 能： N/A
    * 类 名： HttpHelper
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.1.1 2017.05.28 18:39:51 刘欢 初版
    *
    * Copyright (c) 2017 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　　│
    *└──────────────────────────────────┘
    */
    public class HttpHelper
    {
        public static bool HttpDownload(string url, string path)
        {
            var tempPath = System.IO.Path.GetDirectoryName(path);
            System.IO.Directory.CreateDirectory(tempPath);
            var tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp";
            {
                System.IO.File.Delete(tempFile);
                try
                {
                    var request = WebRequest.Create(url) as HttpWebRequest;
                    var response = request.GetResponse() as HttpWebResponse;
                    var responseStream = response.GetResponseStream();
                    var bArr = new byte[1024];
                    var size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    while (size > 0)
                    {
                        size = responseStream.Read(bArr, 0, (int)bArr.Length);
                    }
                    responseStream.Close();
                    System.IO.File.Move(tempFile, path);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
