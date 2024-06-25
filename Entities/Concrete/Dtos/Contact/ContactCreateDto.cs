using Entities.Concrete.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class ContactCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsContacted { get; set; }

        public static Contact ToContact(ContactCreateDto dto)
        {
            Contact contact = new Contact()
            {
                Name = dto.Name,
                Email = dto.Email,
                Subject = dto.Subject,
                Message = dto.Message,
                IsContacted = dto.IsContacted,
            };
            return contact;
        }
    }
}
