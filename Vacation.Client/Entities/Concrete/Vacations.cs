using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Vacations:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
