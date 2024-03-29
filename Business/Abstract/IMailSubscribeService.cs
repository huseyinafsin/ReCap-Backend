﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMailSubscribeService
    {
        IDataResult<List<MailSubscribe>> GetAllMails();
        IResult AddMail(MailSubscribe mailSubscribe);
        IResult DeleteMail(MailSubscribe mailSubscribe);
        IResult UpdateMail(MailSubscribe mailSubscribe);
        Task<IDataResult<MailSubscribe>> GetMailByIdAsync(Guid mailId);
    }
}
