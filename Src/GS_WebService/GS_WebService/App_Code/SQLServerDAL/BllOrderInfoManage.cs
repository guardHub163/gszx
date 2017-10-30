using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using CZZD.GSZX.DBUtility;
using CZZD.GSZX.Common;
using System.Collections.Generic;
using CZZD.GSZX.Model;//Please add references
namespace CZZD.GSZX.DAL
{
    /// <summary>
    /// ���ݷ�����:ecs_order_info
    /// </summary>
    public class BllOrderInfoManage
    {
        public BllOrderInfoManage()
        { }

        #region ����
        /// <summary>
        /// ������Ϣ��ȡ�á�--�����ݲ�ѯ�������ز�ѯ���Ķ������/������ŵ�ͳ������
        /// </summary>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sendStatus"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetOrderIds(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("where 1=1");
            if (!string.IsNullOrEmpty(startTime))
            {
                strSql.AppendFormat(" and add_time>={0} ", CCommon.DateTimeToUnixTime(CConvert.ToDateTime(startTime)));
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" and add_time<{0} ", CCommon.DateTimeToUnixTime(CConvert.ToDateTime(endTime)));
            }

            if (!string.IsNullOrEmpty(sendStatus))
            {
                strSql.AppendFormat(" and send_status = {0} ", sendStatus);
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" and {0} ", strWhere);
            }

            DataSet ds = new DataSet();
            if (CConstant.TYPE_COUNT.Equals(type))
            {
                ds = MySqlDBHelper.Query(" select count(1) as count from ecs_order_info " + strSql.ToString());
            }
            else if (CConstant.TYPE_LIST.Equals(type))
            {
                ds = MySqlDBHelper.Query(" select order_id from ecs_order_info " + strSql.ToString());
            }
            return ds;
        }

        /// <summary>
        ///  ������Ϣ��ȡ�á�--�����ݶ�����ŷ���һ��/���������������Ϣ
        /// </summary>
        /// <param name="type"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public DataSet GetOrders(string type, string orderIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select oi.* ,");
            strSql.Append("og.rec_id,og.order_id as og_order_id,og.goods_id,og.goods_name,og.goods_sn, ");
            strSql.Append("og.goods_number,og.market_price,og.goods_price,og.goods_attr,og.send_number, ");
            strSql.Append("og.is_real,og.extension_code as og_extension_code,og.parent_id as og_parent_id,og.is_gift,og.actual_number,og.actual_amount ");
            strSql.Append("from ecs_order_info as oi ");
            strSql.Append("left join ecs_order_goods as og on oi.order_id = og.order_id ");
            strSql.Append("where 1=1 ");

            if (!string.IsNullOrEmpty(orderIds))
            {
                strSql.AppendFormat("and  oi.order_id in({0}) ", orderIds);
            }
            strSql.Append("order by oi.order_id ");
            return MySqlDBHelper.Query(strSql.ToString());

        }

        /// <summary>
        /// ������Ϣ��ȡ�á�--�����ݲ�ѯ�������ز�ѯ���Ķ�������
        /// </summary>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="sendStatus"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet SelectOrders(string type, string startTime, string endTime, string sendStatus, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select oi.* ,");
            strSql.Append("og.rec_id,og.order_id as og_order_id,og.goods_id,og.goods_name,og.goods_sn, ");
            strSql.Append("og.goods_number,og.market_price,og.goods_price,og.goods_attr,og.send_number, ");
            strSql.Append("og.is_real,og.extension_code as og_extension_code,og.parent_id as og_parent_id,og.is_gift ");
            strSql.Append("from ecs_order_info as oi ");
            strSql.Append("left join ecs_order_goods as og on oi.order_id = og.order_id ");
            strSql.Append("where 1=1");

            if (!string.IsNullOrEmpty(startTime))
            {
                strSql.AppendFormat(" and last_update_time>='{0}' ", startTime);
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" and last_update_time<='{0}' ", endTime);
            }

            if (!string.IsNullOrEmpty(sendStatus))
            {
                strSql.AppendFormat(" and send_status = {0} ", sendStatus);
            }

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" and {0} ", strWhere);
            }

            return MySqlDBHelper.Query(strSql.ToString());
        }
        #endregion


        #region  ����
        /// <summary>
        /// ��������״̬[����ȷ��]/����[��������]�Ļ�д
        /// </summary>
        /// <param name="type"></param>
        /// <param name="orderIDs"></param>
        /// <returns></returns>
        public DataSet ReceiveOrderStatus(string type, string orderIDs)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("orderId", Type.GetType("System.String"));
            dt.Columns.Add("status", Type.GetType("System.String"));
            List<MySqlCommandInfo> sqlList = new List<MySqlCommandInfo>();
            StringBuilder strSql = null;
            int logTime = CCommon.DateTimeToUnixTime(DateTime.Now);

            foreach (string orderId in orderIDs.Split('|'))
            {
                DataRow dr = dt.NewRow();
                dr["orderId"] = orderId;
                try
                {
                    //�鿴����״̬����񼺸���Ƿ�δ����
                    BllOrderInfoTable model = GetModel(CConvert.ToInt32(orderId));
                    if (true)
                    {

                    }

                    strSql = new StringBuilder();
                    strSql.Append(" update ecs_order_info set ");
                    if (CConstant.TYPE_ORDER_SEND_STATUS.Equals(type)) //��������״̬[������������]
                    {
                        strSql.AppendFormat(" shipping_status={0},", CConstant.ORDER_STOCKING); //�ͻ�״̬--'������'
                        strSql.AppendFormat(" send_status={0}", CConstant.ORDER_SEND); //����״̬
                        strSql.AppendFormat(" where pay_status={0}", CConstant.ORDER_PAID);         //������
                        strSql.AppendFormat(" and order_status={0}", CConstant.ORDER_NORMAL);��     //��ȷ��
                        strSql.AppendFormat(" and shipping_status={0}", CConstant.ORDER_UNSHIPPED); //δ����
                    }
                    else if (CConstant.TYPE_ORDER_RECEIPT.Equals(type)) //�����ͻ�ȷ��[������������]
                    {
                        strSql.AppendFormat(" shipping_status={0}", CConstant.ORDER_DELIVERY);       //��������
                        strSql.AppendFormat(" where pay_status={0}", CConstant.ORDER_PAID);����������//������
                        strSql.AppendFormat(" and order_status={0}", CConstant.ORDER_NORMAL);        //��ȷ��
                        strSql.AppendFormat(" and shipping_status={0}", CConstant.ORDER_STOCKING);   //������
                    }
                    else if (CConstant.TYPE_ORDER_RECEIPT.Equals(type)) //�����ջ�ȷ��[���������ջ�]
                    {
                        strSql.AppendFormat(" shipping_status={0}", CConstant.ORDER_RECEIPT);��������//�����ջ�
                        strSql.AppendFormat(" where pay_status={0}", CConstant.ORDER_PAID);          //������
                        strSql.AppendFormat(" and order_status={0}", CConstant.ORDER_NORMAL);        //��ȷ��
                        strSql.AppendFormat(" and shipping_status={0}", CConstant.ORDER_DELIVERY);   //��������
                    }
                    else
                    {
                        dr["status"] = CConstant.ERROR;
                        dt.Rows.Add(dr);
                        continue;
                    }

                    strSql.Append(" and order_id=@order_id");
                    MySqlParameter[] infoParams = { 
                                        new MySqlParameter("@order_id",MySqlDbType.Int32)
                                        };
                    infoParams[0].Value = orderId;
                    sqlList.Add(new MySqlCommandInfo(strSql.ToString(), infoParams));
                    if (CConstant.ORDER_SEND.Equals(type))
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into ecs_order_action(");
                        strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
                        strSql.Append(" values (");
                        strSql.Append("@order_id,@action_user,@order_status,@shipping_status,@pay_status,@action_note,@log_time)");
                        MySqlParameter[] actionParams = {
					        new MySqlParameter("@order_id", MySqlDbType.Int32),
					        new MySqlParameter("@action_user", MySqlDbType.VarChar,30),
					        new MySqlParameter("@order_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@shipping_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@pay_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@action_note", MySqlDbType.VarChar,255),
					        new MySqlParameter("@log_time", MySqlDbType.Int32,11)};
                        actionParams[0].Value = model.order_id;
                        actionParams[1].Value = CConstant.DEFAULT_USER_CODE;
                        actionParams[2].Value = CConstant.ORDER_NORMAL;
                        actionParams[3].Value = CConstant.ORDER_STOCKING;
                        actionParams[4].Value = model.pay_status;
                        actionParams[5].Value = "���Ķ����Ѿ���ӡ��ϡ�";
                        actionParams[6].Value = logTime;
                        sqlList.Add(new MySqlCommandInfo(strSql.ToString(), actionParams));
                    }
                    else if (CConstant.TYPE_ORDER_DELIVERY.Equals(type)) //�����ͻ�ȷ��
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into ecs_order_action(");
                        strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
                        strSql.Append(" values (");
                        strSql.Append("@order_id,@action_user,@order_status,@shipping_status,@pay_status,@action_note,@log_time)");
                        MySqlParameter[] actionParams = {
					        new MySqlParameter("@order_id", MySqlDbType.Int32),
					        new MySqlParameter("@action_user", MySqlDbType.VarChar,30),
					        new MySqlParameter("@order_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@shipping_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@pay_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@action_note", MySqlDbType.VarChar,255),
					        new MySqlParameter("@log_time", MySqlDbType.Int32,11)};
                        actionParams[0].Value = model.order_id;
                        actionParams[1].Value = CConstant.DEFAULT_USER_CODE;
                        actionParams[2].Value = CConstant.ORDER_NORMAL;
                        actionParams[3].Value = CConstant.ORDER_DELIVERY;
                        actionParams[4].Value = model.pay_status;
                        actionParams[5].Value = "���Ķ���������ʼ���ͣ���ȴ��ջ���";
                        actionParams[6].Value = logTime;
                        sqlList.Add(new MySqlCommandInfo(strSql.ToString(), actionParams));
                    }
                    else if (CConstant.TYPE_ORDER_RECEIPT.Equals(type)) //�����ջ�ȷ��
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into ecs_order_action(");
                        strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
                        strSql.Append(" values (");
                        strSql.Append("@order_id,@action_user,@order_status,@shipping_status,@pay_status,@action_note,@log_time)");
                        MySqlParameter[] actionParams = {
					        new MySqlParameter("@order_id", MySqlDbType.Int32),
					        new MySqlParameter("@action_user", MySqlDbType.VarChar,30),
					        new MySqlParameter("@order_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@shipping_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@pay_status", MySqlDbType.Int32,1),
					        new MySqlParameter("@action_note", MySqlDbType.VarChar,255),
					        new MySqlParameter("@log_time", MySqlDbType.Int32,11)};
                        actionParams[0].Value = model.order_id;
                        actionParams[1].Value = CConstant.DEFAULT_USER_CODE;
                        actionParams[2].Value = CConstant.ORDER_NORMAL;
                        actionParams[3].Value = CConstant.ORDER_RECEIPT;
                        actionParams[4].Value = model.pay_status;
                        actionParams[5].Value = "���Ķ�����������ͣ���л���ڹ������߹����ӭ���ٴι��٣�";
                        actionParams[6].Value = logTime;
                        sqlList.Add(new MySqlCommandInfo(strSql.ToString(), actionParams));
                    }
                    if (MySqlDBHelper.ExecuteCommandTrans(sqlList) > 0)
                    {
                        dr["status"] = CConstant.SUCCESS;
                    }
                    else
                    {
                        dr["status"] = CConstant.ERROR;
                    }
                }
                catch (Exception ex)
                {
                    dr["status"] = CConstant.ERROR;
                }
                dt.Rows.Add(dr);
                sqlList = new List<MySqlCommandInfo>();
            }
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>
        /// ���Ŷ���ʵ�ʽ�ʵ���������˻����ĸ���
        /// </summary>
        public string ReceiveOrderInfo(BllSendOrderTable sendOrderTable)
        {
            string ret = CConstant.SUCCESS;
            List<MySqlCommandInfo> sqlList = new List<MySqlCommandInfo>();
            StringBuilder strSql = null;
            int logTime = CCommon.DateTimeToUnixTime(DateTime.Now);
            MySqlParameter[] emptyParams = { };
            int orderId = CConvert.ToInt32(sendOrderTable.ORDER_ID);
            decimal diffAmount = Convert.ToDecimal(sendOrderTable.GOODS_AMOUNT) - Convert.ToDecimal(sendOrderTable.ACTUAL_GOODS_AMOUNT);

            //�鿴����״̬����񼺸���Ƿ�δ�������Ƿ�ȷ�ϣ�����״̬
            BllOrderInfoTable model = GetModel(orderId);
            if (true)
            {

            }

            // ������Ϣ����
            strSql = new StringBuilder();
            strSql.Append(" update ecs_order_info set ");
            strSql.Append(" actual_goods_amount=@actual_goods_amount");
            strSql.AppendFormat(" where order_id=@order_id");
            MySqlParameter[] infoParams = { 
                                        new MySqlParameter("@actual_goods_amount",MySqlDbType.Decimal),
                                        new MySqlParameter("@order_id",MySqlDbType.Int32)
                                        };
            infoParams[0].Value = sendOrderTable.ACTUAL_GOODS_AMOUNT;
            infoParams[1].Value = sendOrderTable.ORDER_ID;
            sqlList.Add(new MySqlCommandInfo(strSql.ToString(), infoParams));

            //������ϸ����
            foreach (BllSendOrderLineTable line in sendOrderTable.LINES)
            {
                int recId = CConvert.ToInt32(line.REC_ID);
                decimal actualNumber = CConvert.ToDecimal(line.ACTUAL_NUMBER);
                decimal actualAmount = CConvert.ToDecimal(line.ACTUAL_AMOUNT);

                strSql = new StringBuilder();
                strSql.Append("update ecs_order_goods set ");
                strSql.AppendFormat("actual_number= {0},", actualNumber);
                strSql.AppendFormat("actual_amount= {0} ", actualAmount);
                strSql.AppendFormat(" where rec_id= {0} ", recId);

                sqlList.Add(new MySqlCommandInfo(strSql.ToString(), emptyParams));
            }

            strSql = new StringBuilder();
            strSql.Append("insert into ecs_order_action(");
            strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
            strSql.AppendFormat("values ({0},'{1}',{2},{3},{4},'���Ķ����Ѿ������ɡ�',{5})", orderId, CConstant.DEFAULT_USER_CODE, model.order_status, model.shipping_status, model.pay_status, logTime);
            sqlList.Add(new MySqlCommandInfo(strSql.ToString(), emptyParams));


            //
            strSql = new StringBuilder();
            strSql.Append("insert into ecs_order_action(");
            strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
            strSql.AppendFormat("values ({0},'{1}',{2},{3},{4},'���Ķ����Ѵ����ϣ���װ���Ϊ[{5}]',{6})", orderId, CConstant.DEFAULT_USER_CODE, model.order_status, model.shipping_status, model.pay_status, CConvert.ToString(sendOrderTable.COMMUNITY_CODE).PadLeft(3, '0'), logTime);
            sqlList.Add(new MySqlCommandInfo(strSql.ToString(), emptyParams));

            //ʵ�ʽ��Ͷ�����һ���������ٲ�����
            if (diffAmount != 0)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into ecs_order_action(");
                strSql.Append("order_id,action_user,order_status,shipping_status,pay_status,action_note,log_time)");
                strSql.AppendFormat("values ({0},'{1}',{2},{3},{4},'���������ƷΪ��������Ʒ,�������[{5}]Ԫ�����������˻��С�,',{6})", orderId, CConstant.DEFAULT_USER_CODE, model.order_status, model.shipping_status, model.pay_status, diffAmount, logTime);
                sqlList.Add(new MySqlCommandInfo(strSql.ToString(), emptyParams));

                //�ʻ�������
                strSql = new StringBuilder();
                strSql.Append("update ecs_users set ");
                strSql.Append("user_money=user_money+@user_money");
                strSql.Append(" where user_id=@user_id");
                MySqlParameter[] userParams = {
					new MySqlParameter("@user_id", MySqlDbType.Int32),
					new MySqlParameter("@user_money", MySqlDbType.Decimal,10)
					};
                userParams[0].Value = model.user_id;
                userParams[1].Value = diffAmount;
                sqlList.Add(new MySqlCommandInfo(strSql.ToString(), userParams));

                //�˻����䶯��¼
                strSql = new StringBuilder();
                strSql.Append("insert into ecs_account_log(");
                strSql.Append("user_id,user_money,frozen_money,rank_points,pay_points,change_time,change_desc,change_type)");
                strSql.Append(" values (");
                strSql.Append("@user_id_log,@user_money_log,@frozen_money,@rank_points,@pay_points,@change_time,@change_desc,@change_type)");
                MySqlParameter[] accountlogParams = {
					new MySqlParameter("@user_id_log", MySqlDbType.Int32),
					new MySqlParameter("@user_money_log", MySqlDbType.Decimal,10),
					new MySqlParameter("@frozen_money", MySqlDbType.Decimal,10),
					new MySqlParameter("@rank_points", MySqlDbType.Int32),
					new MySqlParameter("@pay_points", MySqlDbType.Int32),
					new MySqlParameter("@change_time", MySqlDbType.Int32),
					new MySqlParameter("@change_desc", MySqlDbType.VarChar,255),
					new MySqlParameter("@change_type", MySqlDbType.Int32)};
                accountlogParams[0].Value = model.user_id;
                accountlogParams[1].Value = diffAmount;
                accountlogParams[2].Value = 0;
                accountlogParams[3].Value = 0;
                accountlogParams[4].Value = 0;
                accountlogParams[5].Value = logTime;
                accountlogParams[6].Value = "������Ʒ�������[" + sendOrderTable.ORDER_SN + "]";
                accountlogParams[7].Value = 99;
                sqlList.Add(new MySqlCommandInfo(strSql.ToString(), accountlogParams));
            }

            //ִ��
            if (MySqlDBHelper.ExecuteCommandTrans(sqlList) > 0)
            {
                ret = CConstant.SUCCESS;
            }
            else
            {
                ret = CConstant.ERROR;
            }
            return ret;
        }
        #endregion


        #region   �õ�һ������ʵ��
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public BllOrderInfoTable GetModel(int orderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ecs_order_info ");
            strSql.Append(" where order_id=@order_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@order_id", MySqlDbType.Int32)
            };
            parameters[0].Value = orderId;

            BllOrderInfoTable model = new BllOrderInfoTable();
            DataSet ds = MySqlDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //model.order_id=ds.Tables[0].Rows[0]["order_id"].ToString();
                model.order_sn = ds.Tables[0].Rows[0]["order_sn"].ToString();
                //model.user_id=ds.Tables[0].Rows[0]["user_id"].ToString();
                if (ds.Tables[0].Rows[0]["order_status"].ToString() != "")
                {
                    model.order_status = int.Parse(ds.Tables[0].Rows[0]["order_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shipping_status"].ToString() != "")
                {
                    model.shipping_status = int.Parse(ds.Tables[0].Rows[0]["shipping_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pay_status"].ToString() != "")
                {
                    model.pay_status = int.Parse(ds.Tables[0].Rows[0]["pay_status"].ToString());
                }
                model.consignee = ds.Tables[0].Rows[0]["consignee"].ToString();
                if (ds.Tables[0].Rows[0]["country"].ToString() != "")
                {
                    model.country = int.Parse(ds.Tables[0].Rows[0]["country"].ToString());
                }
                if (ds.Tables[0].Rows[0]["province"].ToString() != "")
                {
                    model.province = int.Parse(ds.Tables[0].Rows[0]["province"].ToString());
                }
                if (ds.Tables[0].Rows[0]["city"].ToString() != "")
                {
                    model.city = int.Parse(ds.Tables[0].Rows[0]["city"].ToString());
                }
                if (ds.Tables[0].Rows[0]["district"].ToString() != "")
                {
                    model.district = int.Parse(ds.Tables[0].Rows[0]["district"].ToString());
                }
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.zipcode = ds.Tables[0].Rows[0]["zipcode"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.best_time = ds.Tables[0].Rows[0]["best_time"].ToString();
                model.sign_building = ds.Tables[0].Rows[0]["sign_building"].ToString();
                model.postscript = ds.Tables[0].Rows[0]["postscript"].ToString();
                if (ds.Tables[0].Rows[0]["shipping_id"].ToString() != "")
                {
                    model.shipping_id = int.Parse(ds.Tables[0].Rows[0]["shipping_id"].ToString());
                }
                model.shipping_name = ds.Tables[0].Rows[0]["shipping_name"].ToString();
                if (ds.Tables[0].Rows[0]["pay_id"].ToString() != "")
                {
                    model.pay_id = int.Parse(ds.Tables[0].Rows[0]["pay_id"].ToString());
                }
                model.pay_name = ds.Tables[0].Rows[0]["pay_name"].ToString();
                model.how_oos = ds.Tables[0].Rows[0]["how_oos"].ToString();
                model.how_surplus = ds.Tables[0].Rows[0]["how_surplus"].ToString();
                model.pack_name = ds.Tables[0].Rows[0]["pack_name"].ToString();
                model.card_name = ds.Tables[0].Rows[0]["card_name"].ToString();
                model.card_message = ds.Tables[0].Rows[0]["card_message"].ToString();
                model.inv_payee = ds.Tables[0].Rows[0]["inv_payee"].ToString();
                model.inv_content = ds.Tables[0].Rows[0]["inv_content"].ToString();
                if (ds.Tables[0].Rows[0]["goods_amount"].ToString() != "")
                {
                    model.goods_amount = decimal.Parse(ds.Tables[0].Rows[0]["goods_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shipping_fee"].ToString() != "")
                {
                    model.shipping_fee = decimal.Parse(ds.Tables[0].Rows[0]["shipping_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["insure_fee"].ToString() != "")
                {
                    model.insure_fee = decimal.Parse(ds.Tables[0].Rows[0]["insure_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pay_fee"].ToString() != "")
                {
                    model.pay_fee = decimal.Parse(ds.Tables[0].Rows[0]["pay_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pack_fee"].ToString() != "")
                {
                    model.pack_fee = decimal.Parse(ds.Tables[0].Rows[0]["pack_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["card_fee"].ToString() != "")
                {
                    model.card_fee = decimal.Parse(ds.Tables[0].Rows[0]["card_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["money_paid"].ToString() != "")
                {
                    model.money_paid = decimal.Parse(ds.Tables[0].Rows[0]["money_paid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["surplus"].ToString() != "")
                {
                    model.surplus = decimal.Parse(ds.Tables[0].Rows[0]["surplus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["integral"].ToString() != "")
                {
                    model.integral = int.Parse(ds.Tables[0].Rows[0]["integral"].ToString());
                }
                if (ds.Tables[0].Rows[0]["integral_money"].ToString() != "")
                {
                    model.integral_money = decimal.Parse(ds.Tables[0].Rows[0]["integral_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bonus"].ToString() != "")
                {
                    model.bonus = decimal.Parse(ds.Tables[0].Rows[0]["bonus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
                {
                    model.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["from_ad"].ToString() != "")
                {
                    model.from_ad = int.Parse(ds.Tables[0].Rows[0]["from_ad"].ToString());
                }
                model.referer = ds.Tables[0].Rows[0]["referer"].ToString();
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = int.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    model.confirm_time = int.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pay_time"].ToString() != "")
                {
                    model.pay_time = int.Parse(ds.Tables[0].Rows[0]["pay_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shipping_time"].ToString() != "")
                {
                    model.shipping_time = int.Parse(ds.Tables[0].Rows[0]["shipping_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pack_id"].ToString() != "")
                {
                    model.pack_id = int.Parse(ds.Tables[0].Rows[0]["pack_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["card_id"].ToString() != "")
                {
                    model.card_id = int.Parse(ds.Tables[0].Rows[0]["card_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bonus_id"].ToString() != "")
                {
                    model.bonus_id = int.Parse(ds.Tables[0].Rows[0]["bonus_id"].ToString());
                }
                model.invoice_no = ds.Tables[0].Rows[0]["invoice_no"].ToString();
                model.extension_code = ds.Tables[0].Rows[0]["extension_code"].ToString();
                //model.extension_id=ds.Tables[0].Rows[0]["extension_id"].ToString();
                model.to_buyer = ds.Tables[0].Rows[0]["to_buyer"].ToString();
                model.pay_note = ds.Tables[0].Rows[0]["pay_note"].ToString();
                if (ds.Tables[0].Rows[0]["agency_id"].ToString() != "")
                {
                    model.agency_id = int.Parse(ds.Tables[0].Rows[0]["agency_id"].ToString());
                }
                model.inv_type = ds.Tables[0].Rows[0]["inv_type"].ToString();
                if (ds.Tables[0].Rows[0]["tax"].ToString() != "")
                {
                    model.tax = decimal.Parse(ds.Tables[0].Rows[0]["tax"].ToString());
                }
                //if (ds.Tables[0].Rows[0]["is_separate"].ToString() != "")
                //{
                //    model.is_separate = int.Parse(ds.Tables[0].Rows[0]["is_separate"].ToString());
                //}
                //model.parent_id=ds.Tables[0].Rows[0]["parent_id"].ToString();
                if (ds.Tables[0].Rows[0]["discount"].ToString() != "")
                {
                    model.discount = decimal.Parse(ds.Tables[0].Rows[0]["discount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["send_status"].ToString() != "")
                {
                    model.send_status = int.Parse(ds.Tables[0].Rows[0]["send_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["actual_goods_amount"].ToString() != "")
                {
                    model.actual_goods_amount = decimal.Parse(ds.Tables[0].Rows[0]["actual_goods_amount"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion





    }//end class
}

