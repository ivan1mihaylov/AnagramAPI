using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Contracts
{
    public interface IEntity
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        byte[] Version { get; set; }
    }
}
