using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PriceTagPrint.Data
{
    /**
    * 命名空间: PriceTagPrint.Data
    *
    * 功 能： 功能
    * 类 名： GetData
    *
    * Ver 变更日期 负责人 变更内容
    * ───────────────────────────────────
    * V1.0.0 2018/8/17 12:01:16 刘欢 初版
    * CLR版本： 4.0.30319.42000
    *
    * Copyright (c) 2018 Lir Corporation. All rights reserved.
    *┌──────────────────────────────────┐
    *│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
    *│　版权所有：北京华联高级超市 　　　　　　　　　　　　　           　│
    *└──────────────────────────────────┘
    */
    public class GetData
    {
        private string ConnString = "Server=*;Database=*;Uid=root;Pwd=*;CharSet=utf8;port=3306";
        /// <summary>
        /// 获取品类组
        /// </summary> <returns></returns>
        public DataTable GetGroups()
        {
            var sql = string.Format(@"select group_no 品类组号,group_name 品类组名 from groups");
            return DataBase.MySqlHelper.ExecuteDataTable(ConnString, CommandType.Text, sql, null);
        }
        /// <summary>
        /// 获取品类组商品
        /// </summary>
        /// <param name="groupNo"></param>
        /// <returns></returns>
        public DataTable GetGroupItemDetail(string groupNo)
        {
            var sql = string.Format(@"SELECT t1.po_no 提货单号,t2.level1_category_code 品类组号,
	                                date_format( t1.replenishment_date, '%Y%m%d' ) 日期,
	                                date_format( t1.replenishment_date, '%H:%i:%s' ) 时间,
                                    t1.goods_sku 商品编号,
	                                t1.goods_name 商品名称,
	                                t1.goods_ean 条码,
	                                t1.current_stock 库存,
	                                t1.boxgaugel 箱规,
	                                t1.sum 补货数量,
                                CASE
	
	                                WHEN t1.STATUS = 0 THEN
	                                '未打打' 
	                                WHEN t1.STATUS = 1 THEN
	                                '己打印' 
	                                END 是否打印 
                                FROM
	                                replenishment t1,
	                                shopweb.hs_goods t2 
                                WHERE
	                                t1.goods_sku = t2.sku 
                                AND t1.create_date LIKE '%{0}%' 
                                and t2.level1_category_code={1}", DateTime.Now.ToString("yyyy-MM-dd"),groupNo);
            return DataBase.MySqlHelper.ExecuteDataTable(ConnString, CommandType.Text, sql, null);
        }
    }
}
