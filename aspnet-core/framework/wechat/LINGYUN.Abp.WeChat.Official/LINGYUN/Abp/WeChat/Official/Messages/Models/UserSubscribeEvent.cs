﻿using LINGYUN.Abp.WeChat.Common.Messages;
using Volo.Abp.EventBus;

namespace LINGYUN.Abp.WeChat.Official.Messages.Models;
/// <summary>
/// 用户关注事件
/// </summary>
[EventName("user_subscribe")]
public class UserSubscribeEvent : WeChatEventMessage
{
    public override WeChatMessageEto ToEto()
    {
        return new WeChatOfficialEventMessageEto<UserSubscribeEvent>(this);
    }
}
