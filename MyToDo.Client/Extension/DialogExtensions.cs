using MyToDo.Client.Common;
using MyToDo.Client.Common.Events;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Client.Extension
{
    public static class DialogExtensions
    {
        /// <summary>
        /// 询问窗口 扩展
        /// </summary>
        /// <param name="dialogHost">指定DialogHost 会话主机</param>
        /// <param name="title">标题</param>
        /// <param name="content">询问内容</param>
        /// <param name="dialogHostName">对话主机唯一名称</param>
        /// <returns></returns>
        public static async Task<IDialogResult> Question(this IDialogHostService dialogHost, string title, string content, string dialogHostName = "RootDialog")
        {
            DialogParameters @params = new DialogParameters();
            @params.Add("Title", title);
            @params.Add("Content", content);
            @params.Add("DialogHostName", dialogHostName);

            var dialogResult = await dialogHost.ShowDialog("MessageView", @params, dialogHostName);
            return dialogResult;
        }

        /// <summary>
        /// 推送等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 注册等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
        }

        /// <summary>
        /// 注册提示消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        /// <param name="filter">过滤器</param>
        public static void RegisterMessage(this IEventAggregator aggregator, Action<MessageModel> action, string filter = "Main")
        {
            aggregator.GetEvent<MessageEvent>().Subscribe(action, ThreadOption.PublisherThread, true, (m) => 
            {
                return m.Filter.Equals(filter);
            });
        }

        /// <summary>
        /// 发送提示消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="message"></param>
        public static void SendMessage(this IEventAggregator aggregator, string message, string filter = "Main")
        {
            aggregator.GetEvent<MessageEvent>().Publish(new MessageModel() 
            {
                Message = message,
                Filter = filter
            });
        }
    }
}
