using CefSharp;
using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.control;
using CSPN.IBLL;
using CSPN.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CSPN.webbrower
{
    public class JsEvent
    {
        IWellInfoService wellInfoService = new WellInfoService();
        IWellStateService wellStateService = new WellStateService();
        WellInfo well = new WellInfo();
        WellStateInfo stateInfo = new WellStateInfo();

        string _locationInfo;

        public string inputvalue { get; set; }
        public string terminal_ID { get; set; }
        public int well_State_ID { get; set; }
        public string locationInfo
        {
            get { string str = ReadWriteConfig.ReadConfig("DefaultLocation"); return str; }
            set { _locationInfo = value; }
        }
        public string menuPositon { get; set; }

        public void Search(IJavascriptCallback javascriptCallback)
        {
            if (inputvalue == "")
            {
                MessageBox.Show("请输入内容！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Task.Run(async () =>
           {

               using (javascriptCallback)
               {
                   IList<WellInfo> list = wellInfoService.GetWellInfo_List(inputvalue);
                   string json = JsonConvert.SerializeObject(list);
                   await javascriptCallback.ExecuteAsync(json);
               }
           });
        }
        public void AddMaker(IJavascriptCallback javascriptCallback)
        {
            EditWellInfoForm ef = new EditWellInfoForm(null, true, true, menuPositon);
            ef.ShowDialog();
            terminal_ID = ef.GetTerminal_ID();
            if (ef.result == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    using (javascriptCallback)
                    {
                        IList<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
                        string json = JsonConvert.SerializeObject(list);
                        await javascriptCallback.ExecuteAsync(json);
                    }
                });
            }
        }
        public void UpdateContent(IJavascriptCallback javascriptCallback)
        {
            EditWellInfoForm ef = new EditWellInfoForm(terminal_ID, false, false, null);
            ef.ShowDialog();
            if (ef.result == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    using (javascriptCallback)
                    {
                        IList<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
                        string json = JsonConvert.SerializeObject(list);
                        await javascriptCallback.ExecuteAsync(json);
                    }
                });
            }
        }
        public void DeleteContent()
        {
            if (MessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (wellInfoService.DeleteWellInfo(terminal_ID) > 0 && wellStateService.DeleteWellCurrentStateInfo(terminal_ID) > 0 && wellInfoService.DeleteReportNumInfo(terminal_ID) > 0)
                {
                    MessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WebBrower.webBrower.ExecuteScriptAsync("deleteMarker", terminal_ID);
                }
                else
                {
                    MessageBox.Show("数据删除失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DisposeAlarmMsg()
        {
            PendingMsgControl pmc = new PendingMsgControl();
            pmc.DisposeMsg(well_State_ID,terminal_ID, true);
        }
        public void DisposeMsgFinish()
        {
            PendingMsgControl pmc = new PendingMsgControl();
            pmc.DisposeMsg(well_State_ID, terminal_ID, false);
        }
        public void SaveLocationInfo()
        {
            ReadWriteConfig.WriteConfig("DefaultLocation", _locationInfo);
            MessageBox.Show("设置成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Refresh()
        {
            WebBrower.webBrower.Reload(false);
        }
    }
}
