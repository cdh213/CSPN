using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using CSPN.webbrower;
using CSPN.assistcontrol;
using Newtonsoft.Json;

namespace CSPN.sms
{
    public delegate void GetSMSEventHandler();

    public class GetSMS
    {
        public static event GetSMSEventHandler getSMSEventHandler;

        static IWellStateService wellStateService = new WellStateService();
        static IWellInfoService wellInfoService = new WellInfoService();
        static ILogService logService = new LogService();

        static WellCurrentStateInfo wellCurrentStateInfo = new WellCurrentStateInfo();
        static SystemLogInfo systemLogInfo = new SystemLogInfo();
        static ReportNumInfo reportNumInfo = new ReportNumInfo();
        static WellStateInfo wellStateInfo = new WellStateInfo();
        static WellInfo wellInfo = new WellInfo();
        static ReadWriteRegistry registry = new ReadWriteRegistry();

        public static void GetSMSHandle()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (CDMASMS.queue.Count > 0)
                    {
                        int num = CDMASMS.queue.Dequeue();
                        string sms = CDMASMS.ReadMsgByIndex(num);
                        if (sms != null)
                        {
                            string[] str = sms.Split(';');
                            wellInfo = wellInfoService.GetWellInfoByPhone(str[0].Trim());
                            wellCurrentStateInfo.Report_Time = DateTime.ParseExact(str[1].Trim(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd HH:mm:ss");
                            SMSAnalysis.MsgResult(str[2].Trim());
                            if (SMSAnalysis.isInvalid == true)
                            {
                                Process.GetCurrentProcess().CloseMainWindow();
                                return;
                            }
                            else if (SMSAnalysis.isInvalid == false)
                            {
                                Process.GetCurrentProcess().CloseMainWindow();
                                return;
                            }
                            else
                            {
                                //人井打开
                                if (SMSAnalysis.IsOpen)
                                {
                                    wellCurrentStateInfo.Well_State_ID = 2;
                                    UpdateWellCurrentState();
                                    InsertSystemLogInfo();
                                    UpdateMap(wellInfo.Terminal_ID);
                                    if (getSMSEventHandler != null)
                                    {
                                        getSMSEventHandler();
                                    }
                                    new MessageForm("有一条报警信息（人井非正常打开）！").Show();
                                }
                                else//人井关闭
                                {
                                    //终端低电量报警
                                    if (SMSAnalysis.IsElectricityAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 3;
                                        UpdateWellCurrentState();
                                        InsertSystemLogInfo();
                                        UpdateMap(wellInfo.Terminal_ID);
                                        if (getSMSEventHandler != null)
                                        {
                                            getSMSEventHandler();
                                        }
                                        new MessageForm("有一条状态信息（终端低电量报警）！").Show();
                                    }
                                    //烟感报警
                                    if (SMSAnalysis.IsSmokeAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 4;
                                        UpdateWellCurrentState();
                                        InsertSystemLogInfo();
                                        UpdateMap(wellInfo.Terminal_ID);
                                        if (getSMSEventHandler != null)
                                        {
                                            getSMSEventHandler();
                                        }
                                        new MessageForm("有一条状态信息（烟感报警）！").Show();
                                    }
                                    //烟感电量报警
                                    if (SMSAnalysis.IsSmoke_PowerAlarm)
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 5;
                                        UpdateWellCurrentState();
                                        InsertSystemLogInfo();
                                        UpdateMap(wellInfo.Terminal_ID);
                                        if (getSMSEventHandler != null)
                                        {
                                            getSMSEventHandler();
                                        }
                                        new MessageForm("有一条状态信息（烟感低电量报警）！").Show();
                                    }
                                    else
                                    {
                                        wellCurrentStateInfo.Well_State_ID = 1;
                                        UpdateWellCurrentState();
                                        InsertSystemLogInfo();
                                        UpdateMap(wellInfo.Terminal_ID);
                                    }
                                }
                                UpdateReportNum();
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
            IList<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
            string json = JsonConvert.SerializeObject(list);
            WebBrower.webBrower.ExecuteScriptAsync("updateMarker", json);
        }
        /// <summary>
        /// 更新人井当前状态信息表数据
        /// </summary>
        static void UpdateWellCurrentState()
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
        static void InsertSystemLogInfo()
        {
            systemLogInfo.Happen_Time = wellCurrentStateInfo.Report_Time;
            systemLogInfo.Terminal_ID = wellInfo.Terminal_ID;
            wellStateInfo = wellStateService.GetWellStateInfoByID(wellCurrentStateInfo.Well_State_ID);
            systemLogInfo.Well_State = wellStateInfo.State;
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
        static void UpdateReportNum()
        {
            wellInfoService.UpdateReportTimes(wellInfo.Terminal_ID);
        }
    }
}
