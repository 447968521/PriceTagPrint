using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PriceTagPrint.Common
{
    /**
    * 命名空间: PriceTagPrint.Common
    *
    * 功 能： N/A
    * 类 名： XmlFiles
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.1.1 2018/8/17 19:27:39 刘欢 初版
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public class XmlFiles : XmlDocument
    {
        public string XmlFileName { get; set; }

        public XmlFiles(string xmlFile)
        {
            XmlFileName = xmlFile;

            Load(xmlFile);
        }
        /// <summary>
        /// 给定一个节点的xPath表达式并返回一个节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public XmlNode FindNode(string xPath)
        {
            var xmlNode = SelectSingleNode(xPath);
            return xmlNode;
        }
        /// <summary>
        /// 给定一个节点的xPath表达式返回其值
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public string GetNodeValue(string xPath)
        {
            var xmlNode = SelectSingleNode(xPath);
            return xmlNode.InnerText;
        }
        /// <summary>
        /// 给定一个节点的表达式返回此节点下的孩子节点列表
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xPath)
        {
            var nodeList = SelectSingleNode(xPath).ChildNodes;
            return nodeList;
        }
    }
}
