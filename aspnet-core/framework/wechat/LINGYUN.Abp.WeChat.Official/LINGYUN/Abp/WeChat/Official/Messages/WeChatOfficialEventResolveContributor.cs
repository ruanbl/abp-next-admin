﻿using LINGYUN.Abp.WeChat.Common.Messages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace LINGYUN.Abp.WeChat.Official.Messages;
/// <summary>
/// 微信公众号事件处理器
/// </summary>
public class WeChatOfficialEventResolveContributor : MessageResolveContributorBase
{
    public override string Name => "WeChat.Official.Event";

    public override Task ResolveAsync(IMessageResolveContext context)
    {
        var options = context.ServiceProvider.GetRequiredService<IOptions<AbpWeChatOfficialMessageResolveOptions>>().Value;
        var messageType = context.GetMessageData("MsgType");
        var eventName = context.GetMessageData("Event");
        if ("event".Equals(messageType, StringComparison.InvariantCultureIgnoreCase) && 
            !eventName.IsNullOrWhiteSpace() && 
            options.EventMaps.TryGetValue(eventName, out var eventFactory))
        {
            context.Message = eventFactory(context);
            context.Handled = true;
        }
        return Task.CompletedTask;
    }
}
