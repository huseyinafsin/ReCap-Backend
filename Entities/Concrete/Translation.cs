using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    [Table("Translation", Schema = "system")]
    public class Translation : BaseEntity
    {

        public Guid PageId { get; set; }
        public Guid LanguageId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual Page Page { get; set; }
        public virtual Language Language { get; set; }


    }
}