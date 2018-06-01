using CefSharp;
using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using CSPN.webbrower;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace CSPN.sms
{
    public delegate void GetSMSDelegate();

    public class GetSMS
    {
        public static GetSMSDelegate getSMSDelegate;
        private static IWellStateService wellStateService = new WellStateService();
        private static IWellInfoService wellInfoService = new WellInfoService();
        private static ILogService logService = new LogService();

        private static WellCurrentStateInfo wellCurrentStateInfo = new WellCurrentStateInfo();
        private static SystemLogInfo systemLogInfo = new SystemLogInfo();
        private static ReportInfo reportNumInfo = new ReportInfo();
        private static WellInfo wellInfo = new WellInfo();

        public static void GetSMSHandle()
        {
            Task.Run(() =>
            {
                string num, sms;
                while (true)
                {
                    if (CDMASMS.queue.Count > 0)
                    {
                        num = CDMASMS.queue.Dequeue();
                        sms = CDMASMS.ReadMsgByIndex(num);
                        if (sms != null)
                        {
                            string[] str = sms.Split(';');
                            SMSAnalysis.MsgResult(str[2].Trim());
                            if (SMSAnalysis.isInvalid != null)
                            {
                                Process.GetCurrentProcess().CloseMainWindow();
                                return;
                            }
                            else
                            {
                                wellCurrentStateInfo.Report_Time = DateTime.ParseExact(str[1].Trim(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd HH:mm:ss");
                                wellInfo = wellInfoService.GetWellInfoByPhone(str[0].Trim());
                                //人井打开
                                if (SMSAnalysis.IsOpen)
                                {
                                    wellCurrentStateInfo.Well_State_ID = 2;
                                }
                                else//人井关闭
                                {
                                    //终端低电量报警
                                    if (SMSAnalysis.IsElectricityAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 3;
                                    }
                                    //烟感报警
                                    else if (SMSAnalysis.IsSmokeAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 4;
                                    }
                                    //烟感电量报警
                                    else if (SMSAnalysis.IsSmoke_PowerAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 5;
                                    }
                                    else
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 1;
                                    }
                                }
                                InsertSystemLogInfo();
                                UpdateReportNum();
                                if (wellInfo.WellCurrentStateInfo.Well_State_ID == 1)
                                {
                                    MessageForm.GetMessageForm().ShowForm();
                                    if (wellCurrentStateInfo.Well_State_ID == 2 || wellCurrentStateInfo.Well_State_ID == 3 || wellCurrentStateInfo.Well_State_ID == 4 || wellCurrentStateInfo.Well_State_ID == 5)
                                    {
                                        UpdateWellCurrentState();
                                        if (getSMSDelegate != null)
                                        {
                                            getSMSDelegate();
                                        }
                                    }
                                    else if (wellCurrentStateInfo.Well_State_ID == 1)
                                    {
                                        UpdateWellCurrentState();
                                    }
                                    UpdateMap(wellInfo.Terminal_ID);
                                }
                                else
                                {
                                    LogHelper.WriteLog("人井ID:" + wellInfo.Terminal_ID);
                                }
                            }
                        }
                        CDMASMS.DeleteMsgByIndex(num);
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            });
        }

        /// <summary>
        /// 更新地图数据
        /// </summary>
        /// <param name="well_Info_ID"></param>
        public static void UpdateMap(string terminal_ID)
        {
            Thread.Sleep(500);
            List<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
            string json = JsonConvert.SerializeObject(list);
            WebBrower.webBrower.ExecuteScriptAsync("updateMarker", json);
        }

        /// <summary>
        /// 更新人井当前状态信息表数据
        /// </summary>
        private static void UpdateWellCurrentState()
        {
            wellCurrentStateInfo.Terminal_ID = wellInfo.Terminal_ID;
            wellCurrentStateInfo.Electricity = SMSAnalysis.IsElectricityAlarm == true ? "终端低电量报警" : "终端电量正常";
            wellCurrentStateInfo.Signal_Strength = SMSAnalysis.Signal_Strength;
            wellCurrentStateInfo.Temperature = SMSAnalysis.Temperature;
            wellCurrentStateInfo.Humidity = SMSAnalysis.Humidity;
            if (SMSAnalysis.SmokeMsg)
            {
                wellCurrentStateInfo.Smoke_Detector = SMSAnalysis.IsSmokeAlarm == true ? "烟感报警" : "烟感无报警";
                wellCurrentStateInfo.Smoke_Power = SMSAnalysis.IsSmoke_PowerAlarm == true ? "烟感低电量报警" : "烟感电量正常";
            }
            else
            {
                wellCurrentStateInfo.Smoke_Detector = "无烟感数据";
                wellCurrentStateInfo.Smoke_Power = "无烟感电量数据";
            }
            wellStateService.UpdateWellCurrentStateInfo(wellCurrentStateInfo);
        }

        /// <summary>
        /// 插入系统日志信息表数据
        /// </summary>
        private static void InsertSystemLogInfo()
        {
            systemLogInfo.Happen_Time = wellCurrentStateInfo.Report_Time;
            systemLogInfo.Terminal_ID = wellInfo.Terminal_ID;
            systemLogInfo.Well_State_ID = wellCurrentStateInfo.Well_State_ID;
            systemLogInfo.Electricity = SMSAnalysis.IsElectricityAlarm == true ? "终端低电量报警" : "终端电量正常";
            systemLogInfo.Signal_Strength = SMSAnalysis.Signal_Strength;
            systemLogInfo.Temperature = SMSAnalysis.Temperature;
            systemLogInfo.Humidity = SMSAnalysis.Humidity;
            if (SMSAnalysis.SmokeMsg)
            {
                systemLogInfo.Smoke_Detector = SMSAnalysis.IsSmokeAlarm == true ? "烟感报警" : "烟感无报警";
                systemLogInfo.Smoke_Power = SMSAnalysis.IsSmoke_PowerAlarm == true ? "烟感低电量报警" : "烟感电量正常";
            }
            else
            {
                systemLogInfo.Smoke_Detector = "无烟感数据";
                systemLogInfo.Smoke_Power = "无烟感电量数据";
            }
            logService.InsertSystemLogInfo(systemLogInfo);
        }

        /// <summary>
        /// 更新人井上报次数表
        /// </summary>
        private static void UpdateReportNum()
        {
            wellInfoService.UpdateReportTimes(wellInfo.Terminal_ID);
            wellInfoService.Empty_NotReportNumInfo(wellInfo.Terminal_ID);
        }
    }
}