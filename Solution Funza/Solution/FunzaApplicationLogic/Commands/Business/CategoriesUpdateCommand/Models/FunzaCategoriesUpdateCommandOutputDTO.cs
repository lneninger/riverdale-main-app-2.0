using System;
using System.Collections.Generic;

namespace FunzaApplicationLogic.Commands.Funza.CategoriesUpdateCommand.Models
{
    public class FunzaCategoriesUpdateCommandOutputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ERPId { get; set; }
    }
}