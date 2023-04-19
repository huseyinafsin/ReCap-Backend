using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MailSubscribeManager : IMailSubscribeService
    {
        private IMailSubscriberDal _mailSubscriberDal;

        public MailSubscribeManager(IMailSubscriberDal mailSubscriberDal)
        {
            _mailSubscriberDal = mailSubscriberDal;
        }

        public IDataResult<List<MailSubscribe>> GetAllMails()
        {
            return new SuccessDataResult<List<MailSubscribe>>(_mailSubscriberDal.GetAll(), "Mails Listed");
        }

        public IResult AddMail(MailSubscribe mailSubscribe)
        {
            _mailSubscriberDal.Add(mailSubscribe);
            return new SuccessResult("Mail added");
        }

        public IResult DeleteMail(MailSubscribe mailSubscribe)
        {
            _mailSubscriberDal.Delete(mailSubscribe);
            return new SuccessResult("Mail deleted");
        }

        public IResult UpdateMail(MailSubscribe mailSubscribe)
        {
            _mailSubscriberDal.Update(mailSubscribe);
            return new SuccessResult("Mail updated");
        }

        public IDataResult<MailSubscribe> GetMailById(Guid mailId)
        {
            return new SuccessDataResult<MailSubscribe>(_mailSubscriberDal.Get(m=>m.Id==mailId));
        }
    }
}
