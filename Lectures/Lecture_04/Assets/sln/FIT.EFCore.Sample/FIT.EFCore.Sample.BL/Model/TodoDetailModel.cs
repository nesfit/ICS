using System;
using System.Text;

namespace FIT.EFCore.Sample.BL.Model
{
    public class TodoDetailModel
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public bool IsDone { get; set; }
        public PersonModel AssignedPerson { get; set; }
    }
}
