using CefSharp;
using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.webbrower
{
    public delegate void DisposeMsgDelegate(int well_State_ID, string terminal_ID, CSPNType type);

    public class JsEvent
    {
        public static DisposeMsgDelegate disposeMsgDelegate;
        IWellInfoService wellInfoService = new WellInfoService();
        IWellStateService wellStateService = new WellStateService();
        WellInfo well = new WellInfo();
        WellStateInfo stateInfo = new WellStateInfo();

        List<WellInfo> list = null;
        string json = null;
        public string inputvalue { get; set; }
        public string terminal_ID { get; set; }
        public int well_State_ID { get; set; }
        public string menuPositon { get; set; }
        public string locationInfo { get; set; }

        public void Search(IJavascriptCallback javascriptCallback)
        {
            if (inputvalue == "")
            {
                UMessageBox.Show("请输入内容！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Task.Run(async () =>
           {

               using (javascriptCallback)
               {
                   list = wellInfoService.GetWellInfo_List(inputvalue);
                   json = JsonConvert.SerializeObject(list);
                   await javascriptCallback.ExecuteAsync(json);
               }
           });
        }
        public void AddMaker(IJavascriptCallback javascriptCallback)
        {
            EditWellInfoForm ef = new EditWellInfoForm(null, true, true, menuPositon);
            ef.ShowDialog();
            terminal_ID = ef.GetTerminal_ID();
            if (ef.DialogResult == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    using (javascriptCallback)
                    {
                        list = wellInfoService.GetWellInfo_List(terminal_ID);
                        json = JsonConvert.SerializeObject(list);
                        await javascriptCallback.ExecuteAsync(json);
                    }
                });
            }
        }
        public void UpdateContent(IJavascriptCallback javascriptCallback)
        {
            EditWellInfoForm ef = new EditWellInfoForm(terminal_ID, false, false, null);
            ef.ShowDialog();
            if (ef.DialogResult == DialogResult.OK)
            {
                Task.Run(async () =>
                {
                    using (javascriptCallback)
                    {
                        list = wellInfoService.GetWellInfo_List(terminal_ID);
                        json = JsonConvert.SerializeObject(list);
                        await javascriptCallback.ExecuteAsync(json);
                    }
                });
            }
        }
        public void DeleteContent()
        {
            if (UMessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (wellInfoService.DeleteWellInfo(terminal_ID) > 0 && wellStateService.DeleteWellCurrentStateInfo(terminal_ID) > 0 && wellInfoService.DeleteReportInfo(terminal_ID) > 0)
                {
                    UMessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WebBrower.webBrower.ExecuteScriptAsync("deleteMarker", terminal_ID);
                }
                else
                {
                    UMessageBox.Show("数据删除失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void DisposeAlarmMsg()
        {
            if (disposeMsgDelegate != null)
            {
                disposeMsgDelegate(well_State_ID, terminal_ID, CSPNType.AlarmInfo);
            }
        }
        public void DisposeMsgFinish()
        {
            if (disposeMsgDelegate != null)
            {
                disposeMsgDelegate(well_State_ID, terminal_ID, CSPNType.DisposeInfo);
            }
        }
        public void SaveLocationInfo()
        {
            ReadWriteXml.WriteXml("DefaultLocation", locationInfo);
            UMessageBox.Show("设置成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Reload(IJavascriptCallback javascriptCallback)
        {
            Task.Run(async () =>
            {
                using (javascriptCallback)
                {
                    list = wellInfoService.GetWellInfo_List(null);
                    json = JsonConvert.SerializeObject(list);
                    await javascriptCallback.ExecuteAsync(json);
                }
            });
        }
    }
}
